import { Type } from '@angular/compiler/src/compiler_facade_interface';
import { Component, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { ConfigurationService } from '../shared/abstract/abstract-service/configuration.service';
import { EventBusService } from '../shared/abstract/abstract-service/event-bus.service';
import { OperationComponentSettings } from '../shared/components/operations-menu/operationsMenuSettings.model';
import { Localization } from '../shared/models/localization.model';
import { AdministrationEquipmentStatusesEditorComponent } from './administration-equipment-statuses/administration-equipment-statuses-editor.component';
import { AdministrationEquipmentStatusesTableComponent } from './administration-equipment-statuses/administration-equipment-statuses-table.component';
import { AdministrationEquipmentTypesEditorComponent } from './administration-equipment-types/administration-equipment-types-editor.component';
import { AdministrationEquipmentTypesTableComponent } from './administration-equipment-types/administration-equipment-types-table.component';
import { AdministrationOrganizationsEditorComponent } from './administration-organizations/administration-organizations-editor.component';
import { AdministrationOrganizationsTableComponent } from './administration-organizations/administration-organizations-table.component';
import { AdministrationPlacesEditorComponent } from './administration-places/administration-places-editor.component';
import { AdministrationPlacesTableComponent } from './administration-places/administration-places-table.component';
import { AdministrationService } from './administration.service';
import { AdministrationServiceFactory } from './shared/administration.service.provider';

@Component({
  selector: 'administration',
  templateUrl: './administration.component.html',
    styleUrls: ['./administration.component.css'],
    providers: [{
        provide: AdministrationService,
        useFactory: AdministrationServiceFactory,
        deps: [EventBusService, ConfigurationService]
    }]
})
export class AdministrationComponent implements OnInit{
    @Input() activeEditorComponent: Type;
    @ViewChild(AdministrationEquipmentStatusesTableComponent, { static: true }) statusesTable: AdministrationEquipmentStatusesTableComponent;
    @ViewChild(AdministrationEquipmentTypesTableComponent, { static: true }) typesTable: AdministrationEquipmentTypesTableComponent;
    @ViewChild(AdministrationOrganizationsTableComponent, { static: true }) organizationsTable: AdministrationOrganizationsTableComponent;
    @ViewChild(AdministrationPlacesTableComponent, { static: true }) placesTable: AdministrationOrganizationsTableComponent;
    @HostListener('document:keyup.esc', ['$event']) onKeyupEsc(event: any) { this.onHideEditor(); }
    private localization: Localization;
    private updatedEntityId: string | number = '';

    constructor(private administrationService: AdministrationService) { }

    ngOnInit(): void {
        this.localization = this.administrationService.getLocalization();
        this.sendOperationComponentConfiguration();
    }

    private sendOperationComponentConfiguration() {
        const operationComponentSettings = this.generateAndGetOperationComponentConfiguration();

        this.administrationService.sendOperationComponentConfiguration(operationComponentSettings);
    }

    private generateAndGetOperationComponentConfiguration(): OperationComponentSettings {
        return <OperationComponentSettings>{
            addOperation: false,
            deleteOperation: false,
            editOperation: false,
            searchOperation: false,
            title: this.localization.administration
        };
    }

    private onHideEditor(): void {
        switch (this.activeEditorComponent) {
            case (AdministrationEquipmentStatusesEditorComponent): {
                this.statusesTable.updateTableRows();
                break;
            }
            case (AdministrationEquipmentTypesEditorComponent): {
                this.typesTable.updateTableRows();
                break;
            }
            case (AdministrationOrganizationsEditorComponent): {
                this.organizationsTable.updateTableRows();
                break;
            }
            case (AdministrationPlacesEditorComponent): {
                this.placesTable.updateTableRows();
                break;
            }
        }

        this.activeEditorComponent = null;
        this.updatedEntityId = null;
    }

    private onEditStatus(id: string | number): void {
        this.onEdit(id, AdministrationEquipmentStatusesEditorComponent);
    }

    private onEdit(id: string | number, editorComponent: Type) {
        this.activeEditorComponent = editorComponent;
        this.updatedEntityId = id;
    }

    private onAddStatus(): void {
        this.onAdd(AdministrationEquipmentStatusesEditorComponent);
    }

    private onAdd(editorComponent: Type) {
        this.activeEditorComponent = editorComponent;
    }

    private onEditType(id: string | number): void {
        this.onEdit(id, AdministrationEquipmentTypesEditorComponent);
    }

    private onAddType(): void {
        this.onAdd(AdministrationEquipmentTypesEditorComponent);
    }

    private onEditOrganization(id: string | number): void {
        this.onEdit(id, AdministrationOrganizationsEditorComponent);
    }

    private onAddOrganization(): void {
        this.onAdd(AdministrationOrganizationsEditorComponent);
    }

    private onEditPlace(id: string | number): void {
        this.onEdit(id, AdministrationPlacesEditorComponent);
    }

    private onAddPlace(): void {
        this.onAdd(AdministrationPlacesEditorComponent);
    }
}
