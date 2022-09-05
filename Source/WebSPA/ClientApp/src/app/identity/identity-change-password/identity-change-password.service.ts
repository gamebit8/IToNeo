import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { BaseResponse } from '../../shared/models/baseResponse.model';
import { DataService } from '../../shared/abstract/abstract-service/data.service';
import { IdentityAbstractService } from '../shared/identity-abstract.service';
import { IdentityChangePasswordRequest } from './identity-change-password-request.model';
import { ConfigurationService } from '../../shared/abstract/abstract-service/configuration.service';

@Injectable()
export class IdentityChangePasswordService extends IdentityAbstractService {
    private changePasswordUrl: string;

    constructor(protected configurationService: ConfigurationService, protected dataService: DataService) {
        super(configurationService)
    }

    changePassword(form: FormGroup): Observable<BaseResponse<any>> {
        const req = this.mapFormToRequest(form);
        return this.dataService.post<any>(this.changePasswordUrl, req)
    }

    private mapFormToRequest(form: FormGroup): IdentityChangePasswordRequest {
        const f = form.value as IdentityChangePasswordRequest;
        return {
            username: f.username,
            oldPassword: f.oldPassword,
            newPassword: f.newPassword
        }
    }
}
