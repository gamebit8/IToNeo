import { Component, HostListener, Inject, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faCubes, faDesktop, faIdCardAlt, faTools, faUsers } from '@fortawesome/free-solid-svg-icons';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { APP_CONFIG } from './app.config';
import { AppService } from './app.service';
import { AuthService } from './shared/abstract/abstract-service/auth.service';
import { ConfigurationService } from './shared/abstract/abstract-service/configuration.service';
import { MODULES_SETTINGS } from './shared/constants/modulesSettings';
import { AppRoutes } from './shared/enums/appRoutes';
import { AppConfig } from './shared/models/appConfig.model';
import { Localization } from './shared/models/localization.model';
import { NavBarSetting } from './shared/models/navBarSetting.model';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
    private appName = '';
    private configurationIsLoad: boolean;
    private isAuthenticated: boolean;
    private localization: Localization;
    private navBar: boolean;
    private navBarExtended: boolean;
    private displayNavMenuExtended: boolean;
    private displayNavMenu: boolean;
    private navBarSettings = Array<NavBarSetting>();
    private destroyNotifer = new Subject();

    constructor(
        @Inject(APP_CONFIG) private config: AppConfig,
        private configurationService: ConfigurationService,
        private authService: AuthService,
        private appService: AppService,
        private router: Router
    ) { }

    @HostListener('window:resize', ['event']) onResize(event) {
        this.checkWindowWidth();
    }

    ngOnDestroy(): void {
        this.destroyNotifer.next();
        this.destroyNotifer.complete();
    }


    ngOnInit(): void{
        this.appName = this.config.appName;
        this.loadConfiguration();
        this.checkAuthenticated();
        this.subscribeisAuthenticated();
        this.checkWindowWidth();
    }

    private subscribeisAuthenticated(): void {
        this.authService
            .isAuthenticated$
            .pipe(takeUntil(this.destroyNotifer))
            .subscribe(res => {
                this.isAuthenticated = res;
                if (res)
                    this.generateNavBarSettings(this.authService.roles);
                else
                    this.router.navigate([AppRoutes.Identity]);
            })
    }

    private checkWindowWidth(): void {
        const windth: number = window.innerWidth;
        if (windth < 960)
            this.displayNavMenu = false;
        else
            this.displayNavMenu = true;
    }

    private loadConfiguration(): void {
        this.configurationService.load();
        this.configurationService
            .settingsLoaded$
            .pipe(takeUntil(this.destroyNotifer))
            .subscribe(() => {
                this.configurationIsLoad = true;
                this.localization = this.configurationService.localization;
                this.generateNavBarSettings(this.authService.roles);
            
            });
    }

    private generateNavBarSettings(userRoles: string[]): void {
        const modulesSettings = MODULES_SETTINGS;
        const referensNavBarSettings = this.getReferensNavBarSettings();
        const navBarSettings = Array<NavBarSetting>();

        referensNavBarSettings.forEach(rnvs => {
            Object.keys(modulesSettings).forEach(ms => {
                if (rnvs.path == modulesSettings[ms].path) {
                    if(modulesSettings[ms].allowedUserRoles.includes(...userRoles))
                        navBarSettings.push(rnvs);
                }
            });

        })

        this.navBarSettings = navBarSettings;
    }

    private checkAuthenticated(): void {
        this.isAuthenticated = this.authService.isAuthenticated;

        if (!this.isAuthenticated)
            this.router.navigate([AppRoutes.Identity]);
    }

    private getReferensNavBarSettings(): Array<NavBarSetting> {
        return [
            {
                icon: faDesktop,
                path: AppRoutes.Equipments,
                title: this.localization.equipment
            },
            {
                icon: faIdCardAlt,
                path: AppRoutes.Employees,
                title: this.localization.employees
            },
            {
                icon: faCubes,
                path: AppRoutes.Softwares,
                title: this.localization.software
            },
            {
                icon: faUsers,
                path: AppRoutes.Users,
                title: this.localization.users
            },
            {
                icon: faTools,
                path: AppRoutes.Administration,
                title: this.localization.administration
            }
        ]
    }

    private onToogleDisplayNavMenuExtended(event: any): void {
        this.displayNavMenuExtended = !this.displayNavMenuExtended;
    }
}
