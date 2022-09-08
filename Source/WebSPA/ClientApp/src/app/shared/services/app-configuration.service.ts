import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from '@angular/core';
import { combineLatest, Observable, Subject } from 'rxjs';
import { map } from "rxjs/operators";
import { APP_CONFIG } from "../../app.config";
import { BaseConfigurationService } from "../abstract/interfaces/baseConfigurationService";
import { AppConfig } from "../models/appConfig.model";
import { Localization } from "../models/localization.model";
import { PathsConfiguration } from "../models/pathsConfiguration.model";
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
        const urlsConfigurationUrl = this.appConfig.apiHost + this.appConfig.apiPathConfiguration;
        const localizationFileUrl = this.appConfig.localizationFileUrl;

        const urls = this.loadUrls(urlsConfigurationUrl);
        const local = this.loadLocalizations(localizationFileUrl);

        this.setUrlsAndLocalizations(urls, local).subscribe();
    }

    private loadUrls(url: string): Observable<UrlsConfiguration> {
        return this.http.get<PathsConfiguration>(url).pipe(map(res => this.mapPathsToUrls(res)));
    }

    private loadLocalizations(url: string): Observable<Localization> {
        return this.http.get<Localization>(url);
    }

    private setUrlsAndLocalizations(urls: Observable<UrlsConfiguration>, localization: Observable<Localization>): Observable<void> {
        return combineLatest(
            [urls, localization],
            (urls, localization) => {
                this.urls = urls;
                this.localization = localization;
                this.isReady = true;
                this.settingsLodaedSource.next();
            });
    }

    private mapPathsToUrls(paths: PathsConfiguration): UrlsConfiguration {
        return <UrlsConfiguration>{
            indentityUrl: this.appConfig.apiHost + paths.indentityPath,
            employeesUrl: this.appConfig.apiHost + paths.employeesPath,
            equipmentsUrl: this.appConfig.apiHost + paths.equipmentsPath,
            equipmentTypesUrl: this.appConfig.apiHost + paths.equipmentTypesPath,
            equipmentStatusesUrl: this.appConfig.apiHost + paths.equipmentStatusesPath,
            softwaresUrl: this.appConfig.apiHost + paths.softwaresPath,
            softwareDevelopersUrl: this.appConfig.apiHost + paths.softwareDevelopersPath,
            softwareLicensesUrl: this.appConfig.apiHost + paths.softwareLicensesPath,
            softwareLicenseTypesUrl: this.appConfig.apiHost + paths.softwareLicenseTypesPath,
            disposalsUrl: this.appConfig.apiHost + paths.disposalsPath,
            organizationsUrl: this.appConfig.apiHost + paths.organizationsPath,
            placesUrl: this.appConfig.apiHost + paths.placesPath,
            writeOffsUrl: this.appConfig.apiHost + paths.writeOffsPath,
            authenticateUrl: this.appConfig.apiHost + paths.authenticatePath,
            registerUrl: this.appConfig.apiHost + paths.registerPath,
            changePasswordUrl: this.appConfig.apiHost + paths.changePasswordPath,
            changePasswordAfterResetUrl: this.appConfig.apiHost + paths.changePasswordAfterResetPath,
            recoveryPasswordUrl: this.appConfig.apiHost + paths.recoveryPasswordPath,
            confirmEmailUrl: this.appConfig.apiHost + paths.confirmEmailPath,
            filesUrl: this.appConfig.apiHost + paths.filesPath,
            russianSettings: this.appConfig.apiHost + paths.russianSettings,
            employeeSearchHelperUrl: this.appConfig.apiHost + paths.employeeSearchHelperPath,
            organizationSearchHelperUrl: this.appConfig.apiHost + paths.organizationSearchHelperPath,
            equipmentSearchHelperUrl: this.appConfig.apiHost + paths.equipmentSearchHelperPath,
            equipmentTypeSearchHelperUrl: this.appConfig.apiHost + paths.equipmentTypeSearchHelperPath,
            equipmentStatusSearchHelperUrl: this.appConfig.apiHost + paths.equipmentStatusSearchHelperPath,
            placeSearchHelperUrl: this.appConfig.apiHost + paths.placeSearchHelperPath,
            equipmentsSoftwareLicensesUrl: this.appConfig.apiHost + paths.equipmentsSoftwareLicensesPath,
            usersUrl: this.appConfig.apiHost + paths.usersPath,
            userRolesUrl: this.appConfig.apiHost + paths.userRolesPath
        }
    }
}

