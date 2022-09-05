import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { faTimes, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { NavFragmentSettings } from '../../models/navFragmentSettings.model';

@Component({
    selector: 'modal-editor',
    templateUrl: './modal-editor.component.html',
    styleUrls: ['./modal-editor.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class ModalEditorComponent {
    @Input() activeNavFragment: string;
    @Input() navsSettings: NavFragmentSettings[] = new Array<NavFragmentSettings>();
    @Output() close = new EventEmitter();
    @Output() selectFragment = new EventEmitter<string>();
    private faTimes: IconDefinition = faTimes;

    constructor(private cdr: ChangeDetectorRef) { }

    private onClose(): void {
        this.close.emit();
    }

    private onSelectNav(fragment: string): void {
        this.selectFragment.emit(fragment);
    }
}
