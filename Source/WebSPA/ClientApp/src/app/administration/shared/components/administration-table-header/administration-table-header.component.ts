import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faMinus, faPen, faPlus, IconDefinition } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'administration-table-header',
    templateUrl: './administration-table-header.component.html',    
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AdministrationTableHeaderComponent {
    @Input() title: string = '';
    @Output() delete: EventEmitter<any> = new EventEmitter();
    @Output() edit: EventEmitter<any> = new EventEmitter();
    @Output() add: EventEmitter<any> = new EventEmitter();
    private faPen: IconDefinition = faPen;
    private faPlus: IconDefinition = faPlus;
    private faMinus: IconDefinition = faMinus;

    constructor(private cdr: ChangeDetectorRef) { }

    private onEditEntity(event: any) {
        this.edit.emit();
    }

    private onDeleteEntity(event: any) {
        this.delete.emit();
    }

    private onAddEntity(event: any) {
        this.add.emit();
    }
}
