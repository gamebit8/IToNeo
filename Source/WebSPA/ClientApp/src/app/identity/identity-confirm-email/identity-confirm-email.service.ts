import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseResponse } from '../../shared/models/baseResponse.model';
import { DataService } from '../../shared/abstract/abstract-service/data.service';
import { IdentityAbstractService } from '../shared/identity-abstract.service';
import { ConfigurationService } from '../../shared/abstract/abstract-service/configuration.service';

@Injectable()
export class IdentityConfirmEmailService extends IdentityAbstractService{
    private confirmEmailUrl: string;

    constructor(protected configurationService: ConfigurationService, protected dataService: DataService) {
        super(configurationService)
    }

    protected onCreateService(): void {
        if (this.configurationService?.urls)
            this.confirmEmailUrl = this.configurationService.urls.confirmEmailUrl;
    }

    confirmEmail(email: string, token: string): Observable<BaseResponse<any>> {
        const params = new HttpParams().append('email', email).append('token', token);
        return this.dataService.post<any>( this.confirmEmailUrl, null, params)
    }
}
