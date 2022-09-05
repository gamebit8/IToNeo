import { Observable } from "rxjs";
import { AuthenticateResponse } from "../../models/authenticate-response.model";
import { BaseResponse } from "../../models/baseResponse.model";

export interface BaseAuthService {
    authToken: string
    username: string
    roles: string[]
    isAuthenticated: boolean
    isAuthenticated$: Observable<any>
    authenticate(username: string, password: string): Observable<BaseResponse<AuthenticateResponse>>
    logout(): void
}
