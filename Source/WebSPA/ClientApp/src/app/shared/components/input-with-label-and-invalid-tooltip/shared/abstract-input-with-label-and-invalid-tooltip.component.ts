import { Directive, EventEmitter, Input, Output } from '@angular/core';
import { inputType } from '../../../enums/inputType';
import { InputModel } from '../../../models/input.model';

@Directive()
export abstract class AbstractInputFormcontrolWithLabelAndInvalidTooltipComponent<T> {
    @Input() input = <InputModel>{ type: inputType.text };
    @Input() inputValue: T;
    @Output() inputValueChange = new EventEmitter<T>();
    protected isRequired: boolean;

    constructor() { }

    ngOnInit() {
        this.checkIsRequired();
    }

    protected onValueChange() {

    }

    protected checkIsRequired() {

    }

    protected onClear() {

    }
}
