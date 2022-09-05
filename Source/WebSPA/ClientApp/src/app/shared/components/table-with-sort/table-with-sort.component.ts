import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { faSort, faSortDown, faSortUp, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { TableWithSortTitleButtonsDirective } from './table-with-sort-title.directive';

@Component({
    selector: 'table-with-sort',
    templateUrl: './table-with-sort.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class TableWithSortComponent extends TableWithSortTitleButtonsDirective{
    private faSort = faSort;
    private faSortUp = faSortUp;
    private faSortDown = faSortDown;

    constructor(protected cdr: ChangeDetectorRef) {
        super(cdr)
    }

    private getTitle(colomn: any[], row: string): string {
        let titles = row.split('.');
        if (titles.length <= 1)
            return colomn[titles[0]];
        try {
            return colomn[titles[0]][titles[1]]
        } catch {
            return null
        }
    }
}
