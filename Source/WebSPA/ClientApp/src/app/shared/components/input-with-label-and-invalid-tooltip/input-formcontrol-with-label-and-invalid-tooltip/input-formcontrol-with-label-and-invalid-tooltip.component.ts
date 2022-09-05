import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { inputType } from '../../../enums/inputType';
import { AbstractInputFormcontrolWithLabelAndInvalidTooltipComponent } from '../shared/abstract-input-with-label-and-invalid-tooltip.component';

@Component({
    selector: 'input-formcontrol-with-label-and-invalid-tooltip',
    templateUrl: './input-formcontrol-with-label-and-invalid-tooltip.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class InputFormcontrolWithLabelAndInvalidTooltipComponent extends AbstractInputFormcontrolWithLabelAndInvalidTooltipComponent<AbstractControl> implements OnInit{

    constructor(private cdr: ChangeDetectorRef) {
        super()
    }

    ngOnInit() {
        this.checkIsRequired();
    }

    protected onValueChange() {
        let value = this.inputValue.value;

        if (this.input.type == inputType.number)
            this.inputValue.setValue(Number(value));

        this.inputValueChange.emit(this.inputValue);
    }

    protected checkIsRequired() {
        if (this.inputValue?.validator) {
            const validator = this.inputValue.validator({} as AbstractControl)
            this.isRequired = (validator && validator.required);
        }
    }

    protected onClear() {
        this.inputValue.reset();
        this.inputValue.markAsUntouched();

        this.cdr.detectChanges();
    }
}
