import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnChanges, OnDestroy, OnInit, SimpleChange, SimpleChanges } from '@angular/core';
import { IconDefinition } from '@fortawesome/fontawesome-svg-core';
import { faCloudDownloadAlt, faCloudUploadAlt, faSpinner, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { Subject, Subscriber, Subscription } from 'rxjs';
import { finalize, take, takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../enums/responseStatus';
import { BaseResponse } from '../../models/baseResponse.model';
import { FileRequets } from '../../models/fileRequest.model';
import { FileResponse } from '../../models/fileResponse.model';
import { Localization } from '../../models/localization.model';
import { FileService } from './file.service';

@Component({
    selector: 'file',
    templateUrl: './file.component.html',
    styleUrls: ['./file.component.css'],
    providers: [FileService],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class FileComponent implements OnInit, OnDestroy{
    @Input() file = <FileRequets>{};
    private localozation: Localization;
    private fileData: Blob;
    private isDeletingFile: boolean;
    private isDownloadingFile: boolean;
    private isUploadingFile: boolean;
    private faCloudUploadAlt = faCloudUploadAlt;
    private faCloudDownloadAlt = faCloudDownloadAlt;
    private faTrashAlt = faTrashAlt;
    private faSpinner = faSpinner;
    private destroyNotifier = new Subject();

    constructor(private fileService: FileService, private cdr: ChangeDetectorRef) {

    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['file'])
            this.cdr.detectChanges();
    }

    ngOnInit(): void {
        this.localozation = this.fileService.getLocalization();

        if (!this.file.name) {
            this.file.name = this.localozation.attachFile;
            this.cdr.detectChanges();
        }
    }

    ngOnDestroy(): void {
        this.destroyNotifier.next();
        this.destroyNotifier.complete();
    }

    private onChangeFile(event: any): void {
        const target = event.target || event.srcElement;
        const file = target.files[0];
        const fileIsValid = this.fileService.checkValidFile(file);

        if (fileIsValid) {
            this.fileData = file;
            this.file.name = file.name;
        }
    }

    private onUploadFile(): void {
        if (this.fileData) {
            let formData = new FormData();
            formData.append('Name', this.file.name);
            formData.append('EquipmentId', String(this.file.equipmentId));
            formData.append('SoftwareLicenseId', String(this.file.softwareLicenseId));
            formData.append('EmployeeId', String(this.file.employeeId));
            formData.append('Content', this.fileData);
            this.isUploadingFile = true;

            this.fileService
                .postFile(formData)
                .pipe(
                    takeUntil(this.destroyNotifier),
                    finalize(() => {
                        this.isUploadingFile = false;
                        this.cdr.detectChanges();
                    })
                )
                .subscribe(res => {
                    if (res.status == ResponseStatus.Created) {
                        const url = res.data as string;
                        this.file.id = url.split('/').pop();
                    }
                });
        }
    }

    private onDownloadFile(): void {
        if (this.file?.id) {
            this.isDownloadingFile = true;
            this.fileService
                .getFile(this.file.id)
                .pipe(
                    takeUntil(this.destroyNotifier),
                    finalize(() => {
                        this.isUploadingFile = false;
                        this.cdr.detectChanges();
                    })
                )
                .subscribe(res => this.dowloadFileHandler(res));

        } else {
            console.log(`Don't file id`)
        }
    }

    private dowloadFileHandler(res: BaseResponse<FileResponse>): void {
        let url = window.URL.createObjectURL(res.data?.data);
        let a = document.createElement('a');
        document.body.appendChild(a);
        a.setAttribute('style', 'display: none');
        a.href = url;
        a.download = res.data.name;
        a.click();
        window.URL.revokeObjectURL(url);
        a.remove;
    }

    private onDeleteFile(): void {
        if (this.file?.id) {
            this.isDeletingFile = true;
            this.fileService.
                deleteFile(this.file.id)
                .pipe(
                    takeUntil(this.destroyNotifier),
                    finalize(() => {
                        this.isUploadingFile = false;
                        this.cdr.detectChanges();
                    })
                )
                .subscribe(res => {
                    if (res.status == ResponseStatus.NoContent) {
                        this.file.id = null;
                        this.file.name = this.localozation.attachFile;
                        this.fileData = null;
                    }
                });
        } else {
            console.log(`Don't file id`)
        }
    }
}
