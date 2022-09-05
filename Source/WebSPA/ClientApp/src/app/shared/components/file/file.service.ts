import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { APP_CONFIG } from '../../../app.config';
import { AppConfig } from '../../models/appConfig.model';
import { BaseResponse } from '../../models/baseResponse.model';
import { FileResponse } from '../../models/fileResponse.model';
import { Localization } from '../../models/localization.model';
import { DataService } from '../../abstract/abstract-service/data.service';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';

@Injectable()
export class FileService{
    private filesUrl: string = '';

    constructor(
        @Inject(APP_CONFIG) private appConfig: AppConfig,
        private dataService: DataService,
        private configurationService: ConfigurationService
    ) {
        this.filesUrl = this.configurationService.urls?.filesUrl;
    }

    getLocalization(): Localization {
        return this.configurationService.localization;
    }

    postFile(form: FormData): Observable<BaseResponse<any>> {
        return this.dataService.postFile(this.filesUrl, form);
    }

    getFile(id: number | string): Observable<BaseResponse<FileResponse>> {
        const url = this.generateUrlWithId(this.filesUrl, id);

        return this.dataService.getFile(url);
    }

    deleteFile(id: number | string): Observable<BaseResponse<any>> {
        const url = this.generateUrlWithId(this.filesUrl, id);

        return this.dataService.delete(url);
    }

    checkValidFile(file: Blob): boolean {
        const maximumUploadFileSize = this.appConfig.maximumUploadFileSize;

        return (file.size < maximumUploadFileSize);
    }

    private generateUrlWithId(baseUrl: string, id: number | string) {
        return baseUrl + `/${id}`;
    }
}
