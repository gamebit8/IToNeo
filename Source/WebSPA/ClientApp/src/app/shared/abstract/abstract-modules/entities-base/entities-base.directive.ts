import { Directive, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IconDefinition } from '@fortawesome/fontawesome-svg-core';
import { faEllipsisH } from '@fortawesome/free-solid-svg-icons';
import { combineLatest, Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { OperationComponentSettings, OperationsMenuEvents } from '../../../components/operations-menu/operationsMenuSettings.model';
import { ResponseStatus } from '../../../enums/responseStatus';
import { BaseResponse } from '../../../models/baseResponse.model';
import { BaseWithNameModel } from '../../../models/baseWithName.model';
import { InputModel } from '../../../models/input.model';
import { Localization } from '../../../models/localization.model';
import { NavFragmentSettings } from '../../../models/navFragmentSettings.model';
import { Sorting } from '../../../models/sorting.model';
import { TableWithSort } from '../../../models/tableWithSort.model';
import { TableWithSortColumn } from '../../../models/tableWithSortColumn.model';
import { UrlsConfiguration } from '../../../models/urlsConfiguration.model';
import { EntitiesBaseService } from './entities-base.service';
import { EntitiesComponentBuilder } from './entities-component.builder';
import { EntitiesTiltes } from './entitiesTitles.model';

@Directive()
export abstract class EntitiesBase<TE extends BaseWithNameModel, TEF extends Sorting, TRes extends BaseWithNameModel, TReq extends BaseResponse<TE[]>>
    implements OnInit, OnDestroy{

    @Input() entity = <TE>{};
    @Input() entityIdsDescription: TE;
    @Input() entityFilter = <TEF>{};
    @Input() htmlInputs: { [key: string]: InputModel };
    @Output() updatedEntity = new EventEmitter<any>();
    @Output() createdEntity = new EventEmitter<any>();
    protected destroyNotifier = new Subject();
    protected showViewCustomization: boolean;
    protected showEditor: boolean;
    protected showSearchBar: boolean;
    protected searchBarComponent: any;
    protected editorComponent: any;
    protected faEllipsisH: IconDefinition = faEllipsisH;
    protected urls: UrlsConfiguration;
    protected activeEditorComponent: NavFragmentSettings;
    protected defaultModalComponentFragment = '';
    protected operationComponentSettings: OperationComponentSettings;
    protected entityEditorNavsSettings = new Array<NavFragmentSettings>();
    protected entitiesTable = <TableWithSort<TE>>{};
    protected titles = <EntitiesTiltes>{};
    protected componentPath: string;
    protected localization = <Localization>{};
    protected isLoading: boolean;
    protected viewCustomization = { allItems: Array<string>(), selectedItems: Array<string>() };
    protected referenseEntityTableColumns: TableWithSortColumn[];

    constructor(
        protected entityService: EntitiesBaseService<TE, TEF, TRes, TReq>,
        protected activeLink: ActivatedRoute,
        protected router: Router
    ) {

    }

    ngOnDestroy(): void {
        this.destroyNotifier.next();
        this.destroyNotifier.complete();
    }

    ngOnInit(): void {
        this.localization = this.entityService.getLocalization();
        this.urls = this.entityService.getUrls();
        this.componentPath = this.activeLink.snapshot.url[0].path;
        this.subscribeToEvents();

        const builder = new EntitiesComponentBuilder();
        this.onCreating(builder);
        this.handleBuilder(builder);

        this.setEntitiesTableColomns();
        this.setDefaultModalComponent();
    }

    protected subscribeToEvents() {
        this.subscribeActiveLink();
        this.subscribeUpdatedEntity();
        this.subscribeCreatedEntity();
        this.subscribeOperationMenuEvents();
    }

    private subscribeActiveLink(): void {
        combineLatest(this.activeLink.params, this.activeLink.queryParams, this.activeLink.fragment)
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(([params, queryParams, fragment]) => {
                if (params['id'] && this.entitiesTable.selectedRowId != params['id']) {
                    this.entitiesTable.selectedRowId = params['id'];
                    this.getEntity(params['id']);
                }

                if (fragment) {
                    this.entityEditorNavsSettings.forEach(set => {
                        if (set.fragment == fragment) {
                            this.setSelectedModalComponent(set);
                        }
                    })
                }

                if (queryParams && !params['id']) {
                    Object.keys(queryParams).forEach(key => {
                        this.entityFilter[key] = (typeof this.entityFilter[key] == 'number') ? Number(queryParams[key]) : this.entityFilter[key] = queryParams[key];
                    })

                    this.getEntities(this.entityFilter);
                }

                if (fragment == 'new') {
                    this.entityEditorNavsSettings.forEach(x => { x.hide = true });
                    this.displayEditor();
                }
            });
    }

    protected subscribeUpdatedEntity(): void {
        this.updatedEntity
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => { this.getEntity(this.entity.id) });
    }

    protected subscribeCreatedEntity(): void {
        this.createdEntity
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => {
                this.navigateToEntityEditor(res);
            })
    }

    protected subscribeOperationMenuEvents(): void {
        this.entityService
            .operationComponentEvents()
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(metaData => this.onEventOperationMenu(metaData.data));
    }

    protected onCreating(builder: EntitiesComponentBuilder): void {

    }

    protected handleBuilder(builder: EntitiesComponentBuilder): void {
        const settting = builder.getSettings();

        this.searchBarComponent = settting.searchBarComponent;
        this.titles.component = settting.title;
        this.titles.beforeDeletingAletMessage = this.localization.beforeDeletingAletMessage;
        this.titles.loadingDataAletMessage = this.localization.loadingDataAletMessage;
        this.entityEditorNavsSettings = settting.entityEditorSettings.fragmentSettings;
        this.defaultModalComponentFragment = settting.entityEditorSettings.defaultFragment;
        this.htmlInputs = settting.inputs;
        this.referenseEntityTableColumns = settting.referenseEntityTableColumns;
        this.operationComponentSettings = {
            addOperation: settting.operationButtonsSettings.addOperation,
            deleteOperation: settting.operationButtonsSettings.deleteOperation,
            editOperation: settting.operationButtonsSettings.editOperation,
            searchOperation: settting.operationButtonsSettings.searchOperation,
            title: settting.title
        }
  
        this.entityService.setOperationComponentConfiguration(this.operationComponentSettings);
    }

    protected setEntitiesTableColomns(): void {
        this.loadEntityTableColomnsSettings();
        this.generateViewCustomizationItems();
    }

    protected loadEntityTableColomnsSettings(): void {
        const colomnTitles = this.entityService.loadEntityTableColomnsSettings(this.componentPath);

        if (colomnTitles) {
            const colomns = this.generateEntityTableColomnsFromColomnTitles(colomnTitles);

            this.entitiesTable.colomns = colomns;
            this.viewCustomization.selectedItems = colomnTitles;
        } else {
            this.entitiesTable.colomns = this.referenseEntityTableColumns;
        }
    }

    protected generateViewCustomizationItems(): void {
        this.referenseEntityTableColumns.forEach(c => {
            this.viewCustomization.allItems.push(c.title);
        })

        if (this.viewCustomization.selectedItems.length == 0)
            this.viewCustomization.selectedItems = this.viewCustomization.allItems;
    }

    protected setDefaultModalComponent(component?: NavFragmentSettings): void {
        if (component) {
            this.setSelectedModalComponent(component);
        } else {
            this.setSelectedModalComponent(this.entityEditorNavsSettings[0]);
        }
    }

    protected submitViewCustomizationChanges(colomnTitles: string[]): void {
        this.entityService.saveEntityTableColomnsSettings(this.componentPath, colomnTitles);

        const colomns = this.generateEntityTableColomnsFromColomnTitles(colomnTitles);
        this.entitiesTable.colomns = colomns;
    }

    private generateEntityTableColomnsFromColomnTitles(colomnTitles: string[]): TableWithSortColumn[] {
        const colomns = Array<TableWithSortColumn>();

        colomnTitles.forEach(ct => {
            this.referenseEntityTableColumns.forEach(rc => {
                if (rc.title == ct)
                    colomns.push(rc);
            })
        })

        return colomns;
    }

    protected onSelectNav(fragment: string): void {
        const navComponent = this.entityEditorNavsSettings.find(x => x.fragment == fragment);
        this.editorComponent = navComponent.component;
        this.activeEditorComponent = navComponent;
    }

    protected onSelectFragment(fragment: string): void {
        this.router.navigate([this.componentPath, this.entitiesTable.selectedRowId], { fragment: fragment })
    }

    protected toogleShowViewCustomization(): void {
        this.showViewCustomization = !this.showViewCustomization;
    }

    protected onCloseViewCustomization(): void {
        this.showViewCustomization = false;
    }

    protected onScroll(): void {
        this.isLoading = true;
        this.entityService
            .getNextPageEntities()
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok)
                    this.entitiesTable.rows = this.entitiesTable.rows.concat(res.data);
            });
    }

    protected displayEditor(): void {
        this.showEditor = true;
    }

    protected onHideEditor(): void {
        this.showEditor = (this.isLoading && !confirm(this.titles.loadingDataAletMessage)) ? true : false;
        this.navigateToRoot();
    }

    protected getEntities(filter: TEF): void {
        this.isLoading = true;
        this.entityService
            .getEntities(filter)
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok) {
                    this.entitiesTable.rows = res.data;
                    this.entityIdsDescription = res.data[0];
                }
            });
    }

    protected getEntity(id: string | number): void {
        this.entityService
            .getEntity(id)
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok) {
                    this.entity = res.data;
                    this.showEditor = true;
                }
            });
    }

    private onDeleteEntity(): void {
        if (this.entitiesTable.selectedRowId && confirm(this.titles.beforeDeletingAletMessage)) {
            this.entityService
                .deleteEntity(this.entitiesTable.selectedRowId)
                .pipe(takeUntil(this.destroyNotifier))
                .subscribe(() => {
                    this.entitiesTable.selectedRowId = null;
                    this.getEntities(this.entityFilter);
                });
        }
    }

    protected onSortTableBy(sotring: Sorting): void {
        this.entityFilter.sortBy = sotring.sortBy;
        this.entityFilter.sortDescending = sotring.sortDescending;
        this.router.navigate([], { relativeTo: this.activeLink, queryParams: this.entityFilter })
    }

    private setSelectedEntityId(id: number): void {
        this.entitiesTable.selectedRowId = id;
    }

    private toogleShowSearchBar(): void {
        this.showSearchBar = !this.showSearchBar;
    }

    private navigateToNew(): void {
        this.router.navigate([this.componentPath], { fragment: 'new' })
    }

    private navigateToRoot(): void {
        this.router.navigate([this.componentPath])
    }

    private navigateToEntityEditor(id: number | string): void {
        this.router.navigate([this.componentPath, id], { fragment: this.defaultModalComponentFragment });
    }


    private onEventOperationMenu(event: any): void {
        switch (event) {
            case OperationsMenuEvents.add:
                this.navigateToNew();
                break;

            case OperationsMenuEvents.delete:
                this.onDeleteEntity();
                break;

            case OperationsMenuEvents.edit:
                this.navigateToEntityEditor(this.entitiesTable.selectedRowId);
                break;

            case OperationsMenuEvents.search:
                this.toogleShowSearchBar();
                break;
        }
    }

    private setSelectedModalComponent(set: NavFragmentSettings): void {
        this.editorComponent = set.component;
        this.activeEditorComponent = set;
    }
}
