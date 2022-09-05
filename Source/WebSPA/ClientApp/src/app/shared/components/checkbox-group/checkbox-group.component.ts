import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { AbstractControl, FormControl } from '@angular/forms';
import { inputType } from '../../enums/inputType';
import { InputModel } from '../../models/input.model';
import { CheckBoxItem } from './checkboxItem.model';

@Component({
    selector: 'checkbox-group',
    templateUrl: './checkbox-group.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class CheckboxGroupComponent implements OnChanges, OnInit {

    @Input() input: InputModel;
    @Input() settings = new Array<CheckBoxItem>();
    @Input() selectedItems: any;
    @Input() selectedItemsIsFormControl: boolean;
    @Output() selectedItemsChange = new EventEmitter<any>();
    private isRequired: any;

    constructor(private cdr: ChangeDetectorRef) {

    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes.selectedItems?.currentValue instanceof FormControl) {
            this.selectedItemsIsFormControl = true;

            this.checkIsRequired()
        }
    }

    ngOnInit(): void {

    }

    protected checkIsRequired() {
        if (this.selectedItems.validator) {
            const validator = this.selectedItems.validator({} as AbstractControl)
            this.isRequired = (validator && validator.required);
        }
    }

    public onToogle(): void {
        const checkedSettings = this.settings.filter(s => s.checked);
        const si = checkedSettings.map(cs => cs.value);

        if (this.selectedItemsIsFormControl == true) {
            const sifc = this.selectedItems as AbstractControl;
            sifc.setValue(si);
            sifc.markAsTouched();
            this.selectedItemsChange.emit(sifc);
        } else {
            this.selectedItemsChange.emit(si);
        }
    }
}
