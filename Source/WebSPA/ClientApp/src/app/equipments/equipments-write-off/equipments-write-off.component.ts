import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { finalize, takeUntil } from 'rxjs/operators';
import { EntitiesBaseEditorModalBuilder } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor-modal.builder';
import { EntitiesBaseEditorModal } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor.derective';
import { ResponseStatus } from '../../shared/enums/responseStatus';
import { EquipmentsService } from '../equipments.service';
import { EquipmentResponse } from '../shared/equipmentResponse.model';

@Component({
    selector: 'equipments-write-off',
    templateUrl: './equipments-write-off.component.html'
})
export class EquipmentsWriteOffComponent extends EntitiesBaseEditorModal<EquipmentResponse>{

    constructor(protected equipmentsService: EquipmentsService) {
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
            liquidationValue: new FormControl(null, Validators.required),
            date: new FormControl(null, Validators.required),
            note: new FormControl("")
        })
    }

    public setFormValueHandler(res: EquipmentResponse, form: FormGroup): FormGroup {
        const writeOff = res.writeOff;

        if (writeOff) {
            res.id ? form.controls['id']?.setValue(writeOff.id) : null;
            form.controls['name']?.setValue(writeOff.name);
            form.controls['equipmentId']?.setValue(writeOff.equipmentId);
            form.controls['liquidationValue']?.setValue(writeOff.liquidationValue);
            form.controls['date']?.setValue(writeOff.date);
            form.controls['note']?.setValue(writeOff.note);
        } else {
            this.form.controls['equipmentId'].setValue(this.entity?.id);
        }

        return form;
    }

    protected onSubmitForm(): void {

        this.isLoading = true;
        this.equipmentsService
            .addOrEditWriteOff(this.form).
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

    //public ngOnInit(): void {
    //    this.setWriteOffForm();
    //    if (this.writeOff)
    //        this.equipmentsService.mapResponseToForm(this.writeOff, this.writeOffForm);
    //}

    //private setWriteOffForm(): void {
    //    this.writeOffForm = new FormGroup({
    //        id: new FormControl(null),
    //        name: new FormControl("", Validators.required),
    //        equipmentId: new FormControl(null),
    //        liquidationValue: new FormControl(null, Validators.required),
    //        date: new FormControl(null, Validators.required),
    //        note: new FormControl("")
    //    })
    //}


    //private onSubmitForm(): void {
    //    if (this.entity?.id) 
    //        this.writeOffForm.controls['equipmentId'].setValue(this.entity?.id);

    //    this.isLoading = true;
    //    this.equipmentsService
    //        .addOrEditWriteOff(this.writeOffForm)
    //        .pipe(
    //            takeUntil(this.notifier),
    //            finalize(() => this.isLoading = false)
    //        )
    //        .subscribe(res => {
    //            if (res.status == ResponseStatus.Ok || res.status == ResponseStatus.Created) {

    //            }
    //        });
    //}
}
