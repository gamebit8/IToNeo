import { ChangeDetectorRef, Directive, DoCheck, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { Sorting } from '../../models/sorting.model';
import { TableWithSort } from '../../models/tableWithSort.model';

@Directive()
export abstract class TableWithSortTitleButtonsDirective implements OnChanges, DoCheck {
    @Input() table = <TableWithSort<any>>{};
    @Output() tableChange = new EventEmitter<TableWithSort<any>>();
    @Output() sort = new EventEmitter<Sorting>();
    @Output() clickRow = new EventEmitter<number>();
    @Output() dblClickRow = new EventEmitter<number>();
    protected inFocus: boolean;
    protected tableAfterOnChanges: string;

    constructor(protected cdr: ChangeDetectorRef) {

    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes["table"])
            this.tableAfterOnChanges = JSON.stringify(this.table);
    }

    ngDoCheck(): void {
        if (this.checkTableHasChanged()) {
            this.cdr.detectChanges();
        }
    }

    private checkTableHasChanged(): boolean {
        const table = JSON.stringify(this.table);

        if (table !== this.tableAfterOnChanges) {
            this.tableAfterOnChanges = table;
            return true;
        }

        return false;
    }

    onSort(sortBy: string): void {
        let sorting = <Sorting>{};
        if (!this.table.sorting || this.table.sorting.sortBy != sortBy) {
            sorting.sortBy = sortBy;
            sorting.sortDescending = 'false';
            this.table.sorting = sorting;
        }
        else {
            sorting.sortDescending = this.table.sorting.sortDescending === 'false' ? 'true' : 'false';
            this.table.sorting.sortDescending = sorting.sortDescending;
        }
        this.onTableChange();
        this.sort.emit(this.table.sorting);
    }

    private onTableChange(): void {
        this.tableChange.emit(this.table);
    }

    public onDblClickRow(id: number): void {
        this.table.selectedRowId = id;
        this.onTableChange();
        this.dblClickRow.emit(id);
    }

    public onClickRow(id: number): void {
        this.table.selectedRowId = id;
        this.onTableChange();
        this.clickRow.emit(id);
    }
}
