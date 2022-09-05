import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ConfigurationService } from '../abstract/abstract-service/configuration.service';
import { DataService } from '../abstract/abstract-service/data.service';
import { StorageService } from '../abstract/abstract-service/storage.service';
import { BaseAuthService } from '../abstract/interfaces/baseAuthService';
import { AuthenticateResponse } from '../models/authenticate-response.model';
import { BaseResponse } from '../models/baseResponse.model';
import { User } from '../models/user.model';

@Injectable()
export class JwtAuthService implements BaseAuthService {
    get authToken(): string { return this._user.authToken };
    get username(): string { return this._user?.username };
    get roles(): string[] { return this._user?.roles };
    isAuthenticated: boolean;
    private subjectIsAuthenticated = new Subject<boolean>();
    isAuthenticated$ = this.subjectIsAuthenticated.asObservable();
    private authenticateUrl: string;
    private _user: User = <User>{};

    constructor(private configurationService: ConfigurationService, private dataService: DataService, private storageService: StorageService) {
        if (this.configurationService.isReady)
            this.initUrls();
        else
            this.configurationService.settingsLoaded$.subscribe(() => this.initUrls());

        this.checkJwtInStorage();
    }

    private initUrls(): void {
        if (this.configurationService?.urls) {
            this.authenticateUrl = this.configurationService.urls.authenticateUrl;
        }
    }

    private checkJwtInStorage(): void {
        const user = this.storageService.retrieve('user');
        if (user) {
            this._user = user;
            this.isAuthenticated = true;
        }

    }

    authenticate(username: string, password: string): Observable<BaseResponse<AuthenticateResponse>> {
        const response = { username: username, password: password };

        return this.dataService.post<AuthenticateResponse>(this.authenticateUrl, response).pipe(tap((res: BaseResponse<AuthenticateResponse>) => {
            if (res.data?.token) {
                this._user.authToken = res.data.token;
                this._user.username = res.data.username;
                this._user.roles = res.data.roles;
                this.isAuthenticated = true;
                this.subjectIsAuthenticated.next(true);
                this.storageService.store('user', this._user);
            }

            res.data = null;
            return res;
        }));
    }

    logout(): void {
        if (this.isAuthenticated) {
            this.subjectIsAuthenticated.next(false);
            this.storageService.remove('user');
            this._user = <User>{};
            this.isAuthenticated = false;
        }
    }
}
