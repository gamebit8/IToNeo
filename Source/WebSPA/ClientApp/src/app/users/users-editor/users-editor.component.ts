import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { finalize, takeUntil } from 'rxjs/operators';
import { EntitiesBaseEditorModalBuilder } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor-modal.builder';
import { EntitiesBaseEditorModal } from '../../shared/abstract/abstract-modules/entities-base/entities-base-editor.derective';
import { CheckBoxItem } from '../../shared/components/checkbox-group/checkboxItem.model';
import { ResponseStatus } from '../../shared/enums/ResponseStatus';
import { UserResoponse } from '../shared/userResponse.model';
import { UsersService } from '../users.service';

@Component({
    selector: 'users-editor',
    templateUrl: './users-editor.component.html'
})

export class UsersEditorComponent extends EntitiesBaseEditorModal<UserResoponse> {
    private roleSettings: CheckBoxItem[] = new Array<CheckBoxItem>();
    constructor(private usersService: UsersService) {
        super()
    }

    protected onCreating(builder: EntitiesBaseEditorModalBuilder) {
        const form = this.getEntityForm();

        builder.setForm(form);
        builder.setSetFormValueFromEntityHandler(this.setFormValueHandler);
    }

    protected ngOnInitBase(): void {
        const userRoles = this.form.controls['roles'].value;

        this.usersService
            .getRoles()
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok) {
                    userRoles.forEach(us => {
                        res.data.find(rs => rs.value == us).checked = true
                    });

                    this.roleSettings = res.data;
                }
            });
    }

    private getEntityForm(): FormGroup {
        const form = new FormGroup({
            id: new FormControl(null),
            userName: new FormControl("", [Validators.required, Validators.maxLength(50)]),
            email: new FormControl("", [Validators.required, Validators.maxLength(50)]),
            phoneNumber: new FormControl("", [Validators.maxLength(50)]),
            roles: new FormControl("", [Validators.maxLength(50)]),
            employeeId: new FormControl("", [Validators.maxLength(36)])
        });

        return form;
    }

    public setFormValueHandler(res: UserResoponse, form: FormGroup): FormGroup {
        res.id ? form.controls['id']?.setValue(res.id) : null;
        form.controls['userName']?.setValue(res.userName);
        form.controls['email']?.setValue(res.email);
        form.controls['phoneNumber']?.setValue(res.phoneNumber);
        form.controls['employeeId']?.setValue(res.employeeId);
        form.controls['roles']?.setValue(res.roles);

        return form;
    }

    protected onSubmitForm(): void {
        this.isLoading = true;
        this.usersService.addOrEditEntity(this.form)
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
