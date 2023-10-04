import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { finalize, takeUntil } from 'rxjs/operators';
import { EntitiesBaseEditorModalBuilder } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor-modal.builder';
import { EntitiesBaseEditorModal } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor.derective';
import { ResponseStatus } from '../../shared/enums/responseStatus';
import { FileRequets } from '../../shared/models/fileRequest.model';
import { EquipmentsService } from '../equipments.service';
import { Equipment } from '../shared/equipment.model';
import { EquipmentResponse } from '../shared/equipmentResponse.model';

@Component({
    selector: 'equipments-editor',
    templateUrl: './equipments-editor.component.html'
})

export class EqupmentsEditorComponent extends EntitiesBaseEditorModal<EquipmentResponse> {
    private file: FileRequets = <FileRequets>{};

    constructor(private equipmentsService: EquipmentsService) {
        super()
    }

    protected ngOnInitBase(): void {
        if (this.entity?.id && this.entity?.file) {
            this.file = {
                equipmentId: this.entity.id, 
                id: this.entity.file.id,
                name: this.entity.file.name,
            }
        }
    }

    protected onCreating(builder: EntitiesBaseEditorModalBuilder) {
        const form = this.getEntityForm();
            
        builder.setForm(form);
        builder.setSetFormValueFromEntityHandler(this.setFormValueHandler);
    }

    private getEntityForm(): FormGroup {
        const form =  new FormGroup({
            id: new FormControl(null),
            name: new FormControl("", [Validators.required, Validators.maxLength(200)]),
            inventoryNumber: new FormControl("", [Validators.maxLength(50)]),
            serialNumber: new FormControl("", [Validators.maxLength(50)]),
            note: new FormControl("", [Validators.maxLength(100)]),
            dateOfCreation: new FormControl(new Date()),
            statusId: new FormControl(null, [Validators.required]),
            organizationId: new FormControl(null, [Validators.required]),
            typeId: new FormControl(null, [Validators.required]),
            employeeId: new FormControl(null),
            placeId: new FormControl(null, [Validators.required]),
            dateOfInstallation: new FormControl(null),
            disposalId: new FormControl(null),
            writeOffId: new FormControl(null),
        })

        form.controls['dateOfCreation'].disable();
        form.controls['inventoryNumber'].disable();

        return form;
    }

    public setFormValueHandler(res: Equipment, form: FormGroup): FormGroup {
        res.id ? form.controls['id']?.setValue(res.id) : null;
        form.controls['name']?.setValue(res.name);
        form.controls['inventoryNumber']?.setValue(res.inventoryNumber);
        form.controls['serialNumber']?.setValue(res.serialNumber);
        form.controls['note']?.setValue(res.note);
        form.controls['dateOfInstallation']?.setValue(res.dateOfInstallation);
        form.controls['dateOfCreation']?.setValue(res.dateOfCreation);
        form.controls['writeOffId']?.setValue(res.writeOff?.id);
        form.controls['disposalId']?.setValue(res.disposal?.id);
        form.controls['statusId']?.setValue(res.status?.id);
        form.controls['organizationId']?.setValue(res.organization?.id);
        form.controls['typeId']?.setValue(res.type?.id);
        form.controls['employeeId']?.setValue(res.employee?.id);
        form.controls['placeId']?.setValue(res.place?.id);

        return form;
    }

    protected onSubmitForm(): void {
        this.isLoading = true;
        this.equipmentsService.addOrEditEntity(this.form)
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(
                res => {
                    if (res.status == ResponseStatus.Created)
                        this.createdEntity.emit(res.data);
                    if (res.status == ResponseStatus.Ok)
                        this.updatedEntity.emit();
                }
            );
    }
}
