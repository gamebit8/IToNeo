import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Output } from '@angular/core';
import { faMinus, faPen, faPlus, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { TableWithSortTitleButtonsDirective } from '../table-with-sort-title.directive';

@Component({
    selector: 'table-with-sort-title-buttons',
    templateUrl: './table-with-sort-title-buttons.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class TableWithSortTitleButtonsComponent extends TableWithSortTitleButtonsDirective{
    @Output() clickAdd = new EventEmitter<any>();
    @Output() clickDelete = new EventEmitter<any>();
    @Output() clickEdit = new EventEmitter<any>();
    private faMinus = faMinus;
    private faPlus = faPlus;
    private faPen = faPen;

    constructor(protected cdr: ChangeDetectorRef) {
        super(cdr)
    }

    private onSortTable(): void {
        this.sort.emit(this.table.sorting);
    } 

    public onClickEdit(): void {
        this.clickEdit.emit();
    }

    public onClickDelete(): void {
        this.clickDelete.emit();
    }

    public onClickAdd(): void {
        this.clickAdd.emit();
    }
}
