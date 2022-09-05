import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, OnChanges, Output, SimpleChanges }                  from '@angular/core';
import { faPlus, faMinus, faPen, faSearch } from '@fortawesome/free-solid-svg-icons';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';
import { Localization } from '../../models/localization.model';
import { OperationComponentSettings, OperationsMenuEvents } from './operationsMenuSettings.model'

@Component({
    selector: 'operations-menu',
    templateUrl: './operations-menu.component.html',
    styleUrls: ['./operations-menu.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class OperationsMenuComponent implements OnChanges{
    @Output() eventOperationMenu = new EventEmitter();
    @Input() buttons: OperationComponentSettings;
    private localization: Localization;
    private faPlus = faPlus;
    private faMinus = faMinus;
    private faPen = faPen;
    private faSearch = faSearch;

    constructor(private cdr: ChangeDetectorRef, private configService: ConfigurationService) {
        this.localization = this.configService.localization;
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['buttons'])
            this.cdr.detectChanges();
    }

    onClickAddButton(): void {
        this.eventOperationMenu.emit(OperationsMenuEvents.add);
    }

    onClickDeleteButton(): void{
        this.eventOperationMenu.emit(OperationsMenuEvents.delete);
    }

    onClickEditButton(): void {
        this.eventOperationMenu.emit(OperationsMenuEvents.edit);
    }

    onClickFiltersButton(): void {
        this.eventOperationMenu.emit(OperationsMenuEvents.search);
    }
}
