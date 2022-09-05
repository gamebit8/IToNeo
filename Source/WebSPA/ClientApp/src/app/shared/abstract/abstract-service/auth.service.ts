import { Observable } from 'rxjs';
import { AuthenticateResponse } from '../../models/authenticate-response.model';
import { BaseResponse } from '../../models/baseResponse.model';
import { BaseAuthService } from '../interfaces/baseAuthService';

export abstract class AuthService implements BaseAuthService {
    isAuthenticated: boolean;
    isAuthenticated$: Observable<any>;
    get authToken(): string { return };
    get username(): string { return  };
    get roles(): string[] { return };

    constructor() { }

    authenticate(username: string, password: string): Observable<BaseResponse<AuthenticateResponse>>{
        return
    }

    logout(): void { }

}
