import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

@Component({
    selector: 'label-custom',
    templateUrl: './label-custom.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class LabelCustomComponent{
    @Input() title: string;
    @Input() field: string;
    @Input() isRequired: boolean;

    constructor(private cdr: ChangeDetectorRef) {

    }
}
