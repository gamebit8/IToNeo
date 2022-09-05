import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { faTimes, IconDefinition } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'administration-editor',
    templateUrl: './administration-editor.component.html',
    styleUrls: ['./administration-editor.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AdministrationEditorComponent{
    @Input() title: string;
    @Output() close = new EventEmitter();
    private faTimes: IconDefinition = faTimes;

    constructor(private cdr: ChangeDetectorRef) { }

    private onClose(): void {
        this.close.emit();
    }
}
