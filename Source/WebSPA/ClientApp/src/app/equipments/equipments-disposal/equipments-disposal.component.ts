import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { finalize, takeUntil } from 'rxjs/operators';
import { EntitiesBaseEditorModalBuilder } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor-modal.builder';
import { EntitiesBaseEditorModal } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor.derective';
import { ResponseStatus } from '../../shared/enums/responseStatus';
import { EquipmentsService } from '../equipments.service';
import { EquipmentResponse } from '../shared/equipmentResponse.model';

@Component({
    selector: 'equipments-disposal',
    templateUrl: './equipments-disposal.component.html'
})

export class EquipmentsDisposalComponent extends EntitiesBaseEditorModal<EquipmentResponse> {

    constructor(private equipmentsService: EquipmentsService) {
        super()
    }

    protected onCreating(builder: EntitiesBaseEditorModalBuilder) {
        const form = this.getEntityForm();

        builder.setForm(form);
        builder.setSetFormValueFromEntityHandler(this.setFormValueHandler);
    }

    private getEntityForm(): FormGroup {
        return new FormGroup({
            id: new FormControl(null),
            name: new FormControl("", Validators.required),
            equipmentId: new FormControl(null),
            resalePrice: new FormControl(null, Validators.required),
            date: new FormControl(null, Validators.required),
            note: new FormControl(""),
        })
    }

    public setFormValueHandler(res: EquipmentResponse, form: FormGroup): FormGroup {
        const disposal = res.disposal;

        if (disposal) {
            res.id ? form.controls['id']?.setValue(disposal.id) : null;
            form.controls['name']?.setValue(disposal.name);
            form.controls['equipmentId']?.setValue(disposal.equipmentId);
            form.controls['resalePrice']?.setValue(disposal.resalePrice);
            form.controls['date']?.setValue(disposal.date);
            form.controls['note']?.setValue(disposal.note);
        } else {
            this.form.controls['equipmentId'].setValue(this.entity?.id);
        }

        return form;
    }

    protected onSubmitForm(): void {
        this.isLoading = true;
        this.equipmentsService
            .addOrEditDisposal(this.form).
            pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(
                res => {
                    if (res.status == ResponseStatus.Ok || res.status == ResponseStatus.Created) {

                    }
                }
            ); 
    }
}
