import { Component, EventEmitter, Input, OnChanges, OnDestroy, Output, SimpleChanges } from '@angular/core';
import { IconDefinition } from '@fortawesome/fontawesome-svg-core';
import { faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { EquipmentResponse } from '../../equipments/shared/equipmentResponse.model';
import { EntitiesBaseEditorModal } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor.derective';
import { ResponseStatus } from '../../shared/enums/responseStatus';
import { Localization } from '../../shared/models/localization.model';
import { Sorting } from '../../shared/models/sorting.model';
import { TableWithSort } from '../../shared/models/tableWithSort.model';
import { SoftwareResponse } from '../shared/softwareResponse.model';
import { SoftwareEquipments } from '../shared/softwaresEquipments.model';
import { SoftwaresEquipmentsDeleteOrAdd } from '../shared/softwaresEquipmentsDeleteOrAdd.model';
import { SoftwaresService } from '../softwares.service';

@Component({
    selector: 'softwares-equipments',
    templateUrl: './softwares-equipments.component.html'
})

export class SoftwaresEquipmentsComponent implements OnChanges, OnDestroy{
    @Input() entity: SoftwareResponse;
    @Output() updatedEntity = new EventEmitter<any>();
    private localization = <Localization>{};
    protected destroyNotifier = new Subject();
    private faPlus: IconDefinition = faPlus;
    private faMinus: IconDefinition = faMinus;
    private softwareEquipmentsTable = <TableWithSort<SoftwareEquipments>>{};
    private equipmentsTable = <TableWithSort<SoftwareEquipments>>{};
    private showEquipments: boolean;

    constructor(private softwareService: SoftwaresService) {
        this.localization = this.softwareService.getLocalization();
        this.softwareEquipmentsTable = this.getSoftwareEquipmentsTable();

        this.equipmentsTable.colomns = this.softwareEquipmentsTable.colomns;
        this.equipmentsTable.title = this.localization.availableEquipment;
    }

    ngOnDestroy(): void {
        this.destroyNotifier.next();
        this.destroyNotifier.complete();
    }

    private getSoftwareEquipmentsTable(): TableWithSort<SoftwareEquipments> {
        return <TableWithSort<SoftwareEquipments>>{
            colomns: [
                { field: 'type.name', title: this.localization.type },
                { field: 'name', title: this.localization.equipment },
                { field: 'inventoryNumber', title: this.localization.inventoryNumber },
                { field: 'serialNumber', title: this.localization.serialNumber },
                { field: 'organization.name', title: this.localization.organization },
                { field: 'employee.name', title: this.localization.employee },
                { field: 'place.name', title: this.localization.place },
            ],
            title: this.localization.installedOnEquipment,
            buttons: {
                add: true,
                delete: true,
                edit: false
            }
        }
    }

    public ngOnChanges(changes: SimpleChanges): void {
        if (changes['entity']) {
            this.softwareEquipmentsTable.rows = this.entity.equipments;
        }
    }

    private onSortSoftwareEquipmentsTableBy(): void {

    }

    private onSortEquipmentsTableBy(sotring: Sorting): void {
        this.softwareService
            .getEquipments(sotring)
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok) {
                    this.equipmentsTable.rows = res.data;
                }
            });
    }


    private onScrollEquipmentsTable(): void {
        this.softwareService
            .getNextPageEquipments()
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok) {
                    this.equipmentsTable.rows.push(...res.data);
                }
            });
    }

    private onCancel(): void {
        this.showEquipments = false;
    }

    private onAddSoftwareToEquipments(): void {
        if (this.equipmentsTable.selectedRowId && this.entity.id) {
            const req = <SoftwaresEquipmentsDeleteOrAdd>{
                equipmentId: this.equipmentsTable.selectedRowId,
                softwareLicenceId: this.entity.id
            }

            this.softwareService
                .addEquipmentsSoftwareLicenses(req)
                .pipe(takeUntil(this.destroyNotifier))
                .subscribe(res => {
                    if (res.status == ResponseStatus.Created) {
                        this.updatedEntity.emit(this.entity.id);
                        this.showEquipments = false;
                    }
                });
        }
    }

    private onShowEquipments(): void {
        this.softwareService
            .getEquipments()
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => {
                this.equipmentsTable.rows = res.data;
                this.showEquipments = true;
            })
    }

    private onDeleteEquipmentsSoftwareLicenses(): void {
        if (this.softwareEquipmentsTable.selectedRowId && this.entity.id && confirm(this.localization.confirmDelete)) {
            const req = <SoftwaresEquipmentsDeleteOrAdd>{
                equipmentId: this.softwareEquipmentsTable.selectedRowId,
                softwareLicenceId: this.entity.id
            };

            this.softwareService
                .deleteEquipmentsSoftwareLicenses(req)
                .pipe(takeUntil(this.destroyNotifier))
                .subscribe(res => {
                    if (res.status == ResponseStatus.NoContent)
                        this.updatedEntity.emit(this.entity.id);
                });
        }
    }
}

