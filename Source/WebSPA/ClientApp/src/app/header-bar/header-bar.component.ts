import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivationEnd, Router } from '@angular/router';
import { faBars, faMinus, faPen, faPlus, faSearch, faUserAlt, faUserCircle, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { MetaData } from 'ng-event-bus/lib/meta-data';
import { Subject, Subscription } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { OperationComponentSettings } from '../shared/components/operations-menu/operationsMenuSettings.model';
import { castKey, EventBusService } from '../shared/abstract/abstract-service/event-bus.service';
import { HeaderBarService } from './header-bar.service';
import { HeaderBarTitles } from './headerBarTitles.model';


export const enum OperationsMenuEvents {
    add,
    delete,
    edit,
    search
};

@Component({
    selector: 'header-bar',
    templateUrl: './header-bar.component.html',
    styleUrls: ['./header-bar.component.css']
})

export class HeaderBarComponent {
    @Output() toogleDisplayNavMenuExtendedFromHeader: EventEmitter<any> = new EventEmitter();
    settings: OperationComponentSettings;
    @Input() appName: string = '';
    private faPlus: IconDefinition = faPlus
    private faMinus: IconDefinition = faMinus
    private faPen: IconDefinition = faPen
    private faSearch: IconDefinition = faSearch
    private faBars: IconDefinition = faBars
    private faUserCircle: IconDefinition = faUserCircle
    private title: string
    private operationMenusSettings: any
    private showUserDropdowMenu: boolean;
    private headerBarTitles: HeaderBarTitles;
    private activeComponent: any
    private notifier = new Subject();

    constructor(private headerBarService: HeaderBarService, private router: Router) { }

    ngOnInit(): void {
        this.subscribeToBusServiceEvents();
        this.subscribeToRouterEvents();
        this.setTitles();
    }

    ngOnDestroy(): void {
        this.notifier.next();
        this.notifier.complete();
    }

    private subscribeToBusServiceEvents(): void {
        this.headerBarService
            .onEvents()
            .pipe(takeUntil(this.notifier))
            .subscribe((meta: MetaData) => {
                this.settings = meta.data as OperationComponentSettings;
            })

    }

    private subscribeToRouterEvents(): void {
        this.router
            .events
            .pipe(takeUntil(this.notifier))
            .subscribe(res => {
                if (res instanceof ActivationEnd) {
                    if (this.activeComponent !== res?.snapshot?.routeConfig?.component?.name) {
                        this.activeComponent = res.snapshot.routeConfig.component.name;
                        this.settings = null;
                    }
                }
            })
    }

    private setTitles(): void {
        const localization = this.headerBarService.getLocalization();

        if (localization) {
            this.headerBarTitles = {
                navigationMenu: localization.navigationMenu,
                userMenu: localization.userMenu,
                add: localization.add,
                delete: localization.delete,
                edit: localization.edit,
                search: localization.search,
                returnToStartPage: localization.returnToStartPage,
                aboutMe: localization.aboutMe,
                exit: localization.exit
            }
        }
    }


    private onClickAddButton(): void {
        this.headerBarService.castEvents(castKey.operationComponentEvents, OperationsMenuEvents.add);
    }

    private onClickDeleteButton(): void {
        this.headerBarService.castEvents(castKey.operationComponentEvents, OperationsMenuEvents.delete);
    }

    private onClickEditButton(): void {
        this.headerBarService.castEvents(castKey.operationComponentEvents, OperationsMenuEvents.edit);
    }

    private onClickFiltersButton(): void {
        this.headerBarService.castEvents(castKey.operationComponentEvents, OperationsMenuEvents.search);
    }

    private onToogleDisplayNavMenuExtended(): void {
        this.toogleDisplayNavMenuExtendedFromHeader.emit(null);
    }

    private onToogleShowUserDropdowMenu(): void {
        this.showUserDropdowMenu = !this.showUserDropdowMenu;
    }

    private onHideUserDropdowMenu(): void {
        this.showUserDropdowMenu = false;
    }

    private logout(): void {
        this.headerBarService.logout();
    }
}
