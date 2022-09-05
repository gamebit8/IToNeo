import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { inputType } from '../../../enums/inputType';
import { AbstractInputFormcontrolWithLabelAndInvalidTooltipComponent } from '../shared/abstract-input-with-label-and-invalid-tooltip.component';

@Component({
    selector: 'input-with-label-and-invalid-tooltip',
    templateUrl: './input-with-label-and-invalid-tooltip.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class InputWithLabelAndInvalidTooltipComponent extends AbstractInputFormcontrolWithLabelAndInvalidTooltipComponent<any>{

    constructor(private cdr: ChangeDetectorRef) {
        super()
    }

    protected onValueChange() {
        let value = this.inputValue;

        if (this.input.type == inputType.number)
            this.inputValue = Number(value);

        this.inputValueChange.emit(this.inputValue);
    }
        
    protected onClear() {
        this.inputValue = null;
        this.onValueChange();

        this.cdr.detectChanges();
    }
}
