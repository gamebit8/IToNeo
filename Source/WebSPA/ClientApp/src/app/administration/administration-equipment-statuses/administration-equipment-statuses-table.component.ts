import { Component } from '@angular/core';
import { ConfigurationService } from '../../shared/abstract/abstract-service/configuration.service';
import { DataService } from '../../shared/abstract/abstract-service/data.service';
import { MapperService } from '../../shared/abstract/abstract-service/mapper.service';
import { TableWithSort } from '../../shared/models/tableWithSort.model';
import { AdministrationTableBuilder } from '../shared/administration-table.builder';
import { AdministrationStatusesTableServiceFactory } from '../shared/administration.service.provider';
import { AdministationTableDirective } from '../shared/directives/administation-table.directive';
import { AdministrationTableService } from '../shared/services/administration-table.service';
import { EquipmentStatus } from './equipmentStatus.model';

@Component({
    selector: 'administration-equipment-statuses-table',
    templateUrl: '../shared/administration-table.component.html',
    styleUrls: ['../administration.component.css'],
    providers: [{
        provide: AdministrationTableService,
        useFactory: AdministrationStatusesTableServiceFactory,
        deps: [DataService, MapperService, ConfigurationService]
    }]
})
export class AdministrationEquipmentStatusesTableComponent extends AdministationTableDirective<EquipmentStatus> {

    constructor(protected administrationTableService: AdministrationTableService<EquipmentStatus>) {
        super(administrationTableService)
    }

    onCreating(builder: AdministrationTableBuilder) {
        const titleTable = this.getTableTitle();
        const table = this.getTable();

        builder.setTitle(titleTable);
        builder.setTable(table);
    }

    private getTableTitle(): string {
        return this.localization.equipmentStatuses;
    }

    private getTable(): TableWithSort<any> {
        return <TableWithSort<any>>{
            colomns: [{ field: 'name', title: this.localization.status }]
        }
    }
}
