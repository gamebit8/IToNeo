import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntitiesBase } from '../shared/abstract/abstract-modules/entities-base/entities-base.directive';
import { EntitiesComponentBuilder } from '../shared/abstract/abstract-modules/entities-base/entities-component.builder';
import { OperationComponentSettings } from '../shared/components/operations-menu/operationsMenuSettings.model';
import { inputType } from '../shared/enums/inputType';
import { InputModel } from '../shared/models/input.model';
import { NavFragmentSettings } from '../shared/models/navFragmentSettings.model';
import { TableWithSortColumn } from '../shared/models/tableWithSortColumn.model';
import { EquipmentsDisposalComponent } from './equipments-disposal/equipments-disposal.component';
import { EqupmentsEditorComponent } from './equipments-editor/equipments-editor.component';
import { EqupmentsSearchBarComponent } from './equipments-search-block/equipments-search-bar.component';
import { EquipmentsSoftwareLicensesComponent } from './equipments-software-licenses/equipments-software-licenses.component';
import { EquipmentsWriteOffComponent } from './equipments-write-off/equipments-write-off.component';
import { EquipmentsService } from './equipments.service';
import { Equipment } from './shared/equipment.model';
import { EquipmentRequest } from './shared/equipmentRequest.model';
import { EquipmentsFilter } from './shared/equipmentsFilter.model';
import { EquipmentsResponse } from './shared/equipmentsResponse.model';

@Component({
    selector: 'equipments',
    templateUrl: '../shared/abstract/abstract-modules/entities-base/entities-base.component.html'
})

export class EquipmentsComponent extends EntitiesBase<Equipment, EquipmentsFilter, EquipmentRequest, EquipmentsResponse> {
    constructor(protected equipmentsService: EquipmentsService, protected activeLink: ActivatedRoute, protected router: Router) {
        super(equipmentsService, activeLink, router)

    }

    protected onCreating(builder: EntitiesComponentBuilder): void {
        const editorSettings = this.getEditorSetting();
        const operationButtonsSettings = this.getOperationButtonsSettings();
        const inputSettings = this.getEntityInput();
        const entityTalbeColumns = this.getReferenseEntityTableColumns();

        builder.addEntityEditor(editorSettings);
        builder.addSearchBar(EqupmentsSearchBarComponent);
        builder.setComponentTitle(this.localization.equipment);
        builder.setOperationButtons(operationButtonsSettings);
        builder.setEntityInput(inputSettings);
        builder.setReferenseEntityTableColumns(entityTalbeColumns);
    }

    private getEditorSetting(): { fragmentSettings: NavFragmentSettings[], defaultFragment: string } {
        return {
            fragmentSettings: [
                { title: this.localization.main, fragment: 'edit', component: EqupmentsEditorComponent },
                { title: this.localization.disposal, fragment: 'disposal', component: EquipmentsDisposalComponent },
                { title: this.localization.writeOff, fragment: 'writeOff', component: EquipmentsWriteOffComponent },
                { title: this.localization.software, fragment: 'softwareLicenses', component: EquipmentsSoftwareLicensesComponent },
            ],
            defaultFragment: 'edit'
        }
    }

    private getOperationButtonsSettings(): OperationComponentSettings {
        return {
            addOperation: true,
            deleteOperation: true,
            editOperation: true,
            searchOperation: true,
        }
    }

    private getEntityInput(): { [key: string]: InputModel } {
        return {
            status: {
                name: 'status.name',
                title: this.localization.status,
                searchHelperUrl: this.urls.equipmentStatusSearchHelperUrl,
                type: inputType.text
            },
            organization: {
                name: 'organization.name',
                title: this.localization.organization,
                searchHelperUrl: this.urls.organizationSearchHelperUrl,
                type: inputType.text
            },
            type: {
                name: 'type.name',
                title: this.localization.type,
                searchHelperUrl: this.urls.equipmentTypeSearchHelperUrl,
                type: inputType.text
            },
            place: {
                name: 'place.name',
                title: this.localization.place,
                searchHelperUrl: this.urls.placeSearchHelperUrl,
                type: inputType.text
            },
            name: {
                name: 'name',
                title: this.localization.equipment,
                type: inputType.text
            },
            inventoryNumber: {
                name: 'inventoryNumber',
                title: this.localization.inventoryNumber,
                type: inputType.text,
            },
            serialNumber: {
                name: 'serialNumber',
                title: this.localization.serialNumber,
                type: inputType.text
            },
            employee: {
                name: 'employee.name',
                title: this.localization.employee,
                searchHelperUrl: this.urls.employeeSearchHelperUrl,
                type: inputType.text
            },
            note: {
                name: 'note',
                title: this.localization.equipmentNote,
                type: inputType.text
            },
            dateOfCreation: {
                name: 'dateOfCreation',
                title: this.localization.dateOfCreation,
                type: inputType.date,
            },
            dateOfCreationFrom: {
                name: 'dateOfCreationFrom',
                title: '',
                type: inputType.date,
            },
            dateOfCreationTo: {
                name: 'dateOfCreationTo',
                title: '',
                type: inputType.date,
            },
            dateOfInstallation: {
                name: 'dateOfInstallation',
                title: this.localization.dateOfInstallation,
                type: inputType.date
            },
            dateOfInstallationFrom: {
                name: 'dateOfInstallationFrom',
                title: '',
                type: inputType.date
            },
            dateOfInstallationTo: {
                name: 'dateOfInstallationTo',
                title: '',
                type: inputType.date
            },
            writeOffName: {
                name: 'name',
                title: this.localization.writeOffName,
                type: inputType.text
            },
            writeOffLiquidationValue: {
                name: 'liquidationValue',
                title: this.localization.writeOffLiquidationValue,
                type: inputType.number
            },
            writeOffDate: {
                name: 'date',
                title: this.localization.writeOffDate,
                type: inputType.date
            },
            writeOffNote: {
                name: 'note',
                title: this.localization.writeOffNote,
                type: inputType.text
            },
            disposalName: {
                name: 'name',
                title: this.localization.disposalName,
                type: inputType.text
            },
            disposalResalePrice: {
                name: 'liquidationValue',
                title: this.localization.disposalResalePrice,
                type: inputType.number
            },
            disposalDate: {
                name: 'date',
                title: this.localization.disposalDate,
                type: inputType.date
            },
            disposalNote: {
                name: 'note',
                title: this.localization.disposalNote,
                type: inputType.text
            }
        }
    }

    private getReferenseEntityTableColumns(): TableWithSortColumn[] {
        return [
            { field: 'name', title: this.localization.equipment },
            { field: 'inventoryNumber', title: this.localization.inventoryNumber },
            { field: 'serialNumber', title: this.localization.serialNumber },
            { field: 'note', title: this.localization.equipmentNote },
            { field: 'dateOfCreation', title: this.localization.dateOfCreation },
            { field: 'dateOfInstallation', title: this.localization.dateOfInstallation },
            { field: 'status.name', title: this.localization.status },
            { field: 'organization.name', title: this.localization.organization },
            { field: 'type.name', title: this.localization.type },
            { field: 'employee.name', title: this.localization.employee }
        ]
    }
}

