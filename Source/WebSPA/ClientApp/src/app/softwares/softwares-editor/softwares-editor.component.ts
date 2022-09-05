import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { finalize, takeUntil } from 'rxjs/operators';
import { EntitiesBaseEditorModalBuilder } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor-modal.builder';
import { EntitiesBaseEditorModal } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor.derective';
import { ResponseStatus } from '../../shared/enums/ResponseStatus';
import { FileRequets } from '../../shared/models/fileRequest.model';
import { SoftwareResponse } from '../shared/softwareResponse.model';
import { SoftwaresService } from '../softwares.service';

@Component({
    selector: 'softwares-editor',
    templateUrl: './softwares-editor.component.html'
})

export class SoftwaresEditorComponent extends EntitiesBaseEditorModal<SoftwareResponse> {
    private file: FileRequets = <FileRequets>{};

    constructor(private softwareService: SoftwaresService) {
        super()
    }

    protected ngOnInitBase(): void {
        if (this.entity?.id && this.entity?.file) {
            this.file = {
                equipmentId: this.entity.id,
                id: this.entity.file.id,
                name: this.entity.file.name,
            }
        }
    }

    protected onCreating(builder: EntitiesBaseEditorModalBuilder) {
        const form = this.getEntityForm();

        builder.setForm(form);
        builder.setSetFormValueFromEntityHandler(this.setFormValueHandler);
    }

    private getEntityForm(): FormGroup {
        const form = new FormGroup({
            id: new FormControl(null),
            name: new FormControl("",  Validators.maxLength(50)),
            typeId: new FormControl(null, [Validators.required]),
            count: new FormControl(null),
            licenseCode: new FormControl(""),
            softwareId: new FormControl(null, Validators.required),
            organizationId: new FormControl(null, Validators.required),
            note: new FormControl("", Validators.maxLength(100))
        })

        return form;
    }

    public setFormValueHandler(res: SoftwareResponse, form: FormGroup): FormGroup {
        res.id ? form.controls['id']?.setValue(res.id) : null;
        form.controls['name']?.setValue(res.name);
        form.controls['typeId']?.setValue(res.type.id);
        form.controls['count']?.setValue(res.count);
        form.controls['licenseCode']?.setValue(res.licenseCode);
        form.controls['softwareId']?.setValue(res.software.id);
        form.controls['organizationId']?.setValue(res.organization.id);
        form.controls['note']?.setValue(res.note);

        return form;
    }

    protected onSubmitForm(): void {
        this.isLoading = true;
        this.softwareService.addOrEditEntity(this.form)
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(
                res => {
                    if (res.status == ResponseStatus.Created)
                        this.createdEntity.emit(res.data);
                    if (res.status == ResponseStatus.Ok)
                        this.updatedEntity.emit();
                }
            );
    }
}
