import { Directive, EventEmitter, Output } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../../shared/enums/responseStatus';
import { BaseWithNameModel } from '../../../shared/models/baseWithName.model';
import { Localization } from '../../../shared/models/localization.model';
import { Sorting } from '../../../shared/models/sorting.model';
import { TableWithSort } from '../../../shared/models/tableWithSort.model';
import { AdministrationTableBuilder } from '../administration-table.builder';
import { AdministrationTableService } from '../services/administration-table.service';


@Directive()
export class AdministationTableDirective<TE extends BaseWithNameModel> {
    @Output() edit = new EventEmitter<string | number>();
    @Output() add = new EventEmitter<any>();
    protected componentTitle: string = '';
    protected entityTable: TableWithSort<BaseWithNameModel> = <TableWithSort<BaseWithNameModel>>{};
    protected localization: Localization;
    protected destroyNotifier = new Subject();

    constructor(protected administrationTableService: AdministrationTableService<TE>) {
        this.localization = this.administrationTableService.getLocalization();
        this.getEntityAndToTableRows(this.entityTable.sorting);

        const builder = new AdministrationTableBuilder();
        this.onCreating(builder);

        const res = builder.getSettings();

        this.entityTable = res.table;
        this.componentTitle = res.title;
    }

    ngOnDestroy(): void {
        this.destroyNotifier.next();
        this.destroyNotifier.complete();
    }

    updateTableRows(): void {
        this.getEntityAndToTableRows(this.entityTable.sorting);
    }

    protected onCreating(builder: AdministrationTableBuilder): void {

    }

    protected getEntityAndToTableRows(sorting: Sorting): void {
        this.administrationTableService
            .getEntities(sorting)
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok)
                    this.entityTable.rows = res.data;
            });
    }

    protected onScrolledTable(): void {
        this.getNextPageEntityAndAddToTableRows();
    }

    protected getNextPageEntityAndAddToTableRows(): void {
        this.administrationTableService
            .getNextPageEntities()
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok && res.data)
                    this.entityTable.rows.push(...res.data);
            });
    }

    protected onEditEntity(): void {
        const selectedEntityId = this.entityTable.selectedRowId;
        this.edit.emit(selectedEntityId);
    }

    protected onAddEntity(): void {
        this.add.emit();
    }

    protected onDeleteEntity(): void {
        const confirmDelete = confirm(this.localization.confirmDelete);
        const selectedEntityId = this.entityTable.selectedRowId;

        if (confirmDelete && selectedEntityId) {
            this.administrationTableService
                .deleteEntity(selectedEntityId)
                .pipe(takeUntil(this.destroyNotifier))
                .subscribe(res => {
                    if (res.status == ResponseStatus.NoContent) {
                        this.getEntityAndToTableRows(this.entityTable.sorting);
                    }
                });
        }
    }

    protected onSortEntitis(): void {
        this.getEntityAndToTableRows(this.entityTable.sorting);
    }
}
