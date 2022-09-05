import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output } from '@angular/core';
import { faTimes, IconDefinition } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'base-input-with-label-and-invalid-tooltip',
    templateUrl: './base-input-with-label-and-invalid-tooltip.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class BaseInputWithLabelAndInvalidTooltipComponent {
    @Input() title: string;
    @Input() field: string;
    @Input() isRequired: boolean;
    @Output() clear = new EventEmitter();
    private faTimes = faTimes;

    constructor(private cdr: ChangeDetectorRef) { }

    private onClear() {
        this.clear.emit();
        this.cdr.detectChanges();
    }
}
