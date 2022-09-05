import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { timeout } from "rxjs/operators";
import { APP_CONFIG } from "../../app.config";
import { AppConfig } from "../models/appConfig.model";

@Injectable()
export class TimeoutInterceptor implements HttpInterceptor {

    constructor(@Inject(APP_CONFIG) private appConfig: AppConfig) {
    }

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const timeoutValue = req.headers.get('timeout') || this.appConfig.httpDefaultTimeout;
        const timeoutValueNumeric = Number(timeoutValue);

        return next.handle(req).pipe(timeout(timeoutValueNumeric));
    }
}
