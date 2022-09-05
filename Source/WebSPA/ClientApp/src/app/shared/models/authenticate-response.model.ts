export interface AuthenticateResponse {
    result: boolean;
    token: string;
    username: string;
    IsLockedOut: boolean;
    IsNotAllowed: boolean;
    RequiresTwoFactor: boolean;
    roles: string[];
}
