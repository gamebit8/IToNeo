import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AppRoutes } from "../enums/appRoutes";
import { UserRole } from "../enums/userRole";
import { AuthService } from "../abstract/abstract-service/auth.service";

@Injectable()
export class AuthGuard implements CanActivate{
    constructor(private authService: AuthService, private router: Router) {

    }

    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        const userIsAuthenticated = this.authService.isAuthenticated;
        const allowRoles = route.data['roles'] || Array<string>();
        const userRoles = this.authService.roles || Array<string>();

        const AllowAnonymus = this.anonymousAllowed(allowRoles);
        const AllowUserRoles = this.userRolesAllowed(allowRoles, userRoles);

        if (AllowAnonymus || AllowUserRoles) {
            return true;
        }

        //The user is authenticated, but the user's role is not included in the allowed roles
        if (userIsAuthenticated) {
            this.router.navigate(['/'])
            return false;
        }

        //User is not authenticated, but user roles are not included in allowed roles
        this.router.navigate([AppRoutes.Identity]);
        return false;
    }

    private anonymousAllowed(allowRoles: string[]): boolean {
        return allowRoles.includes(UserRole.Anonymous);
    }

    private userRolesAllowed(allowRoles: string[], userRoles: string[]): boolean {
        return userRoles.some(ur => allowRoles.includes(ur))
    }
}
