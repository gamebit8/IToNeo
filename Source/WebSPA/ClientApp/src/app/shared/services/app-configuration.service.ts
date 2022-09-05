import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from '@angular/core';
import { combineLatest, Observable, Subject } from 'rxjs';
import { APP_CONFIG } from "../../app.config";
import { BaseConfigurationService } from "../abstract/interfaces/baseConfigurationService";
import { AppConfig } from "../models/appConfig.model";
import { Localization } from "../models/localization.model";
import { UrlsConfiguration } from '../models/urlsConfiguration.model';

@Injectable()
export class AppConfigurationService implements BaseConfigurationService {
    urls: UrlsConfiguration = <UrlsConfiguration>{};
    localization: Localization = <Localization>{};
    isReady: boolean;
    private settingsLodaedSource = new Subject();
    private urlsIsReady: boolean;
    private localizationIsReady: boolean;
    settingsLoaded$ = this.settingsLodaedSource.asObservable();

    constructor(@Inject(APP_CONFIG)private appConfig: AppConfig, private http: HttpClient) {
    }

    load(): void {
        const urlsConfigurationUrl = this.appConfig.urlsConfigurationUrl;
        const localizationFileUrl = this.appConfig.localizationFileUrl;

        const urls = this.loadUrls(urlsConfigurationUrl);
        const local = this.loadLocalizations(localizationFileUrl);

        this.setUrlsAndLocalizations(urls, local).subscribe();
    }

    private loadUrls(url: string): Observable<UrlsConfiguration> {
        return this.http.get<UrlsConfiguration>(url);
    }

    private loadLocalizations(url: string): Observable<Localization> {
        return this.http.get<Localization>(url);
    }

    private setUrlsAndLocalizations(urls: Observable<UrlsConfiguration>, localization: Observable<Localization>):Observable<void> {
        return combineLatest(
            [urls, localization],
            (urls, localization) => {
                this.urls = urls;
                this.localization = localization;
                this.isReady = true;
                this.settingsLodaedSource.next();
            });
    }
}

