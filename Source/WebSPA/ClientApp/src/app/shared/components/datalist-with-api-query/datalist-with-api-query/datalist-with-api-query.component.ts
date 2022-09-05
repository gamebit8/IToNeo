import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { AbstractDatalistWithApiQueryComponent } from '../shared/abstract-datalist-with-api-query.component';
import { DatalistWithApiQueryService } from '../shared/datalist-with-api-query.service';

@Component({
    selector: 'datalist-with-api-query',
    templateUrl: './datalist-with-api-query.component.html',
    styleUrls: ['../shared/datalist-with-api-query.component.css'],
    providers: [DatalistWithApiQueryService],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class DatalistWithApiQueryComponent extends AbstractDatalistWithApiQueryComponent<number>{
    constructor(protected dataListWithApiQueryService: DatalistWithApiQueryService, protected cdr: ChangeDetectorRef) {
        super(dataListWithApiQueryService, cdr);
    }

    protected ngOnInitBase(): void {

    }

    protected onClear() {
        this.inputValue = null;
        this.onChange();
    }
}
