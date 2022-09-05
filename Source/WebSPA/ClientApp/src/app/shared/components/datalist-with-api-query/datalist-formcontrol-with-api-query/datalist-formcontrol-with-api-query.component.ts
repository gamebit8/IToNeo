import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { AbstractDatalistWithApiQueryComponent } from '../shared/abstract-datalist-with-api-query.component';
import { DatalistWithApiQueryService } from '../shared/datalist-with-api-query.service';

@Component({
    selector: 'datalist-formcontrol-with-api-query',
    templateUrl: './datalist-formcontrol-with-api-query.component.html',
    styleUrls: ['../shared/datalist-with-api-query.component.css'],
    providers: [DatalistWithApiQueryService],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class DatalistFormcontrolWithApiQueryComponent extends AbstractDatalistWithApiQueryComponent<AbstractControl>{

    constructor(protected dataListWithApiQueryService: DatalistWithApiQueryService, protected cdr: ChangeDetectorRef) {
        super(dataListWithApiQueryService, cdr);
    }

    ngOnInitBase(): void {
        this.checkIsRequired();
    }

    protected onClear(): void {
        this.inputValue.setValue(null);
        this.onChange();
    }

    private checkIsRequired() {
        if (this.inputValue?.validator) {
            const validator = this.inputValue.validator({} as AbstractControl)
            this.isRequired = (validator && validator.required);
        }
        this.cdr.detectChanges();
    }
}
