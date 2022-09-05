import { Component, EventEmitter, Input, OnChanges, OnDestroy, Output, SimpleChanges } from '@angular/core';
import { IconDefinition } from '@fortawesome/fontawesome-svg-core';
import { faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';
import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../shared/enums/ResponseStatus';
import { Localization } from '../../shared/models/localization.model';
import { Sorting } from '../../shared/models/sorting.model';
import { TableWithSort } from '../../shared/models/tableWithSort.model';
import { SoftwaresEquipmentsDeleteOrAdd } from '../../softwares/shared/softwaresEquipmentsDeleteOrAdd.model';
import { EquipmentsService } from '../equipments.service';
import { EquipmentResponse } from '../shared/equipmentResponse.model';
import { EquipmentsSoftwareLicenses } from '../shared/equipmentsSoftwareLicenses.model';
import { EquipmentsSoftwareLicensesDeleteOrAdd } from '../shared/equipmentsSoftwareLicensesDeleteOrAdd.model';

@Component({
    selector: 'equipments-software-licenses',
    templateUrl: './equipments-software-licenses.component.html',
})

export class EquipmentsSoftwareLicensesComponent implements OnDestroy, OnChanges{
    @Input() entity: EquipmentResponse;
    @Output() updatedEntity: EventEmitter<any> = new EventEmitter<any>();
    protected isLoading: boolean;
    protected destroyNotifier = new Subject();
    private localization: Localization;
    private faPlus: IconDefinition = faPlus;
    private faMinus: IconDefinition = faMinus;
    private equipmentsSoftwareLicensesTable = <TableWithSort<EquipmentsSoftwareLicenses>>{};
    private softwareLicensesTable = <TableWithSort<EquipmentsSoftwareLicenses>>{};
    private showSoftwareLicenses: boolean;

    constructor(private equipmentsService: EquipmentsService) {

        this.localization = this.equipmentsService.getLocalization();
        this.equipmentsSoftwareLicensesTable = this.getEquipmentsSoftwareLicensesTable();
        this.softwareLicensesTable = this.getSoftwareLicensesTable();
    }

    ngOnDestroy(): void {
        this.destroyNotifier.next();
        this.destroyNotifier.complete();
    }

    private getEquipmentsSoftwareLicensesTable(): TableWithSort<EquipmentsSoftwareLicenses> {
        return <TableWithSort<EquipmentsSoftwareLicenses>>{
            colomns: [
                { field: 'developer.name', title: this.localization.developer },
                { field: 'software.name', title: this.localization.software },
                { field: 'name', title: this.localization.license },
                { field: 'type.name', title: this.localization.licenseType },
                { field: 'licenseCode', title: this.localization.licenseCode }
            ],
            title: this.localization.installedSoftwares,
            buttons: {
                add: true,
                delete: true,
                edit: false
            }
        };
    }

    private getSoftwareLicensesTable(): TableWithSort<EquipmentsSoftwareLicenses> {
        return <TableWithSort<EquipmentsSoftwareLicenses>>{
            colomns: [
                { field: 'developer.name', title: this.localization.developer },
                { field: 'software.name', title: this.localization.software },
                { field: 'name', title: this.localization.license },
                { field: 'type.name', title: this.localization.licenseType },
                { field: 'licenseCode', title: this.localization.licenseCode },
                { field: 'count', title: this.localization.licenseCount },
                { field: 'usedLicenses', title: this.localization.usedLicenses }
            ],
            title: this.localization.availableSoftwares
        };
    }

    public ngOnChanges(changes: SimpleChanges): void {
        if (changes['entity']) {
            this.equipmentsSoftwareLicensesTable.rows = this.entity.softwareLicenses || null;
        }
    }

    private onSortEquipmentsSoftwareLicensesTableBy(sotring: Sorting): void {
  
    }

    private onSortSoftwareLicensesTableBy(sotring: Sorting): void {
        this.isLoading = true;

        this.equipmentsService
            .getSoftwareLicenses(sotring)
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok) {
                    this.softwareLicensesTable.rows = res.data;
                }
            });
    }


    private onScrollSoftwareLicensesTable(): void {
        this.isLoading = true;

        this.equipmentsService
            .getNextPageSoftwareLicenses()
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok) {
                    this.softwareLicensesTable.rows.push(...res.data);
                }
        })
    }

    private onCancel(): void {
        this.showSoftwareLicenses = false;
    }

    private onSoftwareLicenseToAddEquipments(): void {
        if (this.softwareLicensesTable.selectedRowId && this.entity.id) {
            const req = <EquipmentsSoftwareLicensesDeleteOrAdd>{
                softwareLicenceId: this.softwareLicensesTable.selectedRowId,
                equipmentId: this.entity.id
            }

            this.isLoading = true;

            this.equipmentsService
                .addEquipmentsSoftwareLicenses(req)
                .pipe(
                    takeUntil(this.destroyNotifier),
                    finalize(() => this.isLoading = false)
                )
                .subscribe(res => {
                    if (res.status == ResponseStatus.Created) {
                        this.updatedEntity.emit(this.entity.id);
                        this.showSoftwareLicenses = false;
                    }
                });

        }
    }

    private onShowSoftwareLicenses(): void {
        this.isLoading = true;

        this.equipmentsService
            .getSoftwareLicenses()
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(res => {
                this.softwareLicensesTable.rows = res.data;
            });
        this.showSoftwareLicenses = true;
    }

    private onDeleteEquipmentsSoftwareLicenses(): void {

        if (this.equipmentsSoftwareLicensesTable.selectedRowId && this.entity.id && confirm(this.localization.confirmDelete)) {
            const req = <SoftwaresEquipmentsDeleteOrAdd>{
                softwareLicenceId: this.softwareLicensesTable.selectedRowId,
                equipmentId: this.entity.id
            };

            this.isLoading = true;

            this.equipmentsService
                .deleteEquipmentsSoftwareLicenses(req)
                .pipe(
                    takeUntil(this.destroyNotifier),
                    finalize(() => this.isLoading = false)
                )
                .subscribe(res => {
                    if (res.status == ResponseStatus.NoContent)
                        this.updatedEntity.emit(this.entity.id);
                })
        }
    }
}
