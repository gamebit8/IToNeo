import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { AuthService } from "../abstract/abstract-service/auth.service";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private router: Router, private authService: AuthService) {
    }

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(req).pipe(catchError((err) => this.handleError(err)));
    }

    private handleError(error: HttpErrorResponse) {
        if (error.status == 401) {
            this.authService.logout();
            this.router.navigate(['identity'])
        }

        if (error.error instanceof ErrorEvent) {
            console.error('Client side network error occurred:', error.error.message);
        } else {
            console.error('Backend - ' +
                `status: ${error.status}, ` +
                `statusText: ${error.statusText}, ` +
                `message: ${error.error.message}`);
        }

        return throwError(error || 'server error');
    }
}
