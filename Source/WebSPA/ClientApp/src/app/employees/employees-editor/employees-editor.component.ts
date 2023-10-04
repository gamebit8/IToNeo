import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { finalize, takeUntil } from 'rxjs/operators';
import { EntitiesBaseEditorModalBuilder } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor-modal.builder';
import { EntitiesBaseEditorModal } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor.derective';
import { ResponseStatus } from '../../shared/enums/responseStatus';
import { FileRequets } from '../../shared/models/fileRequest.model';
import { EmployeesService } from '../employees.service';
import { EmployeeResponse } from '../shared/employeeResponse.model';

@Component({
    selector: 'employees-editor',
    templateUrl: './employees-editor.component.html'
})

export class EmployeesEditorComponent extends EntitiesBaseEditorModal<EmployeeResponse> implements OnInit{
    private file: FileRequets = <FileRequets>{};

    constructor(private employeesService: EmployeesService) {
        super()
    }

    protected ngOnInitBase(): void {
        if (this.entity?.id && this.entity?.file) {
            this.file = {
                employeeId: this.entity.id,
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
        const form = new FormGroup({
            id: new FormControl(null),
            firstName: new FormControl("", [Validators.required, Validators.maxLength(50)]),
            lastName: new FormControl("", [Validators.required, Validators.maxLength(50)]),
            patronymicName: new FormControl("", [Validators.required, Validators.maxLength(50)]),
            username: new FormControl("", [Validators.maxLength(50)]),
            department: new FormControl("", [Validators.required, Validators.maxLength(50)]),
            position: new FormControl("", [Validators.required, Validators.maxLength(50)]),
            organizationId: new FormControl(null, Validators.required),
        })

        form.controls['username'].disable();

        return form;
    }

    public setFormValueHandler(res: EmployeeResponse, form: FormGroup): FormGroup {
        res.id ? form.controls['id']?.setValue(res.id) : null;
        form.controls['firstName']?.setValue(res.firstName);
        form.controls['lastName']?.setValue(res.lastName);
        form.controls['patronymicName']?.setValue(res.patronymicName);
        form.controls['username']?.setValue(res.username);
        form.controls['department']?.setValue(res.department);
        form.controls['position']?.setValue(res.position);
        form.controls['organizationId']?.setValue(res.organization.id);

        return form;
    }

    protected onSubmitForm(): void {
        this.isLoading = true;
        this.employeesService.addOrEditEntity(this.form)
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
