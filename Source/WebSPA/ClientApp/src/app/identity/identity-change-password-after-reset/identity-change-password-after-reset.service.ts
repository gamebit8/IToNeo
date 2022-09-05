import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseResponse } from '../../shared/models/baseResponse.model';
import { DataService } from '../../shared/abstract/abstract-service/data.service';
import { IdentityAbstractService } from '../shared/identity-abstract.service';
import { IdentityChangePasswordAfterResetRequest } from './identity-change-password-after-reset-request.model';
import { ConfigurationService } from '../../shared/abstract/abstract-service/configuration.service';

@Injectable()
export class IdentityChangePasswordAfterResetService extends IdentityAbstractService{
    private changePasswordAfterResetUrl: string;

    constructor(protected configurationService: ConfigurationService, protected dataService: DataService) {
        super(configurationService)
    }

    protected onCreateService(): void {
        if (this.configurationService?.urls)
            this.changePasswordAfterResetUrl = this.configurationService.urls.changePasswordAfterResetUrl;
    }

    changePassword(email: string, token: string, newPassword: string): Observable<BaseResponse<any>> {
        const params = new HttpParams().append('email', email).append('token', token)
        const req = <IdentityChangePasswordAfterResetRequest>{ newPassword: newPassword };
        return this.dataService.post<any>(this.changePasswordAfterResetUrl, req, params);
    }
}
