import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../shared/abstract/abstract-service/auth.service';
import { ConfigurationService } from '../shared/abstract/abstract-service/configuration.service';
import { DataService } from '../shared/abstract/abstract-service/data.service';
import { AuthenticateResponse } from '../shared/models/authenticate-response.model';
import { BaseResponse } from '../shared/models/baseResponse.model';
import { IdentityAbstractService } from './shared/identity-abstract.service';
import { IdentityPasswordRecoveryRequest } from './shared/identity-password-recovery-request.model';
import { IdentityRegisterRequest } from './shared/identity-register-request.model';

@Injectable()
export class IdentityService extends IdentityAbstractService{
    private registerUrl: string
    private recoveryPasswordUrl: string

    constructor(
        private authService: AuthService,
        protected dataServie: DataService,
        protected configurationService: ConfigurationService) {
            super(configurationService)
    }

    protected onCreateService(): void {
        this.registerUrl = this.configurationService.urls.registerUrl;
        this.recoveryPasswordUrl = this.configurationService.urls.recoveryPasswordUrl;
    }

    public authenticate(usename: string, password: string): Observable<BaseResponse<AuthenticateResponse>> {
        return this.authService.authenticate(usename, password);
    }

    public register(request: IdentityRegisterRequest): Observable<BaseResponse<any>> {
        return this.dataServie.post<any>(this.registerUrl, request)
    }

    public recoverPassword(request: IdentityPasswordRecoveryRequest): Observable<BaseResponse<any>> {
        return this.dataServie.post<any>(this.recoveryPasswordUrl, request)
    }
}
