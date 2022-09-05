import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { finalize, takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../shared/enums/ResponseStatus';
import { inputType } from '../../shared/enums/inputType';
import { InputModel } from '../../shared/models/input.model';
import { CustomValidators } from '../../shared/validators/custom-validators';
import { IdentityAbstract } from '../shared/identity-abstract.component';
import { IdentityComponentBuilder } from '../shared/identity-component-builder';
import { IdentityChangePasswordService } from './identity-change-password.service';

@Component({
    selector: 'identity-change-password',
    templateUrl: './identity-change-password.component.html',
})

export class IdentityChangePasswordComponent extends IdentityAbstract{
    private passwordChanged: boolean

    constructor(protected identityChangePasswordService: IdentityChangePasswordService) {
        super(identityChangePasswordService);
    }

    protected onCreateComponent(builder: IdentityComponentBuilder) {
        builder.useForm(this.getForm());
        builder.useInputSettings(this.getInputSettings());
    }

    private getForm(): FormGroup {
        return new FormGroup({
            'username': new FormControl('', Validators.required),
            'oldPassword': new FormControl('', Validators.compose([
                Validators.required,
                CustomValidators.password,
                CustomValidators.newPasswordAndOldPassword])
            ),
            'newPassword': new FormControl('', Validators.compose([
                Validators.required,
                CustomValidators.password,
                CustomValidators.newPasswordAndOldPassword,
                CustomValidators.newPasswordAndPasswordConfirmation])
            ),
            'passwordConfirmation': new FormControl('', Validators.compose([
                Validators.required,
                CustomValidators.password,
                CustomValidators.newPasswordAndPasswordConfirmation])
            )
        });
    } 

    protected getInputSettings(): { [key: string]: InputModel } {
        return {
            'username': { name:'username', placeholder: this.localization.username, type: inputType.text },
            'oldPassword': { name: 'oldPassword', placeholder: this.localization.oldPassword, type: inputType.password },
            'newPassword': { name: 'newPassword', placeholder: this.localization.newPassword, type: inputType.password },
            'passwordConfirmation': { name: 'passwordConfirmation', placeholder: this.localization.passwordConfirmation, type: inputType.password }
        };
    }

    private onSubmitForm(): void {
        if (this.form.valid) {
            this.isLoading = true;
            this.identityChangePasswordService
                .changePassword(this.form)
                .pipe(
                    takeUntil(this.notifier),
                    finalize(() => this.isLoading = false)
                )
                .subscribe(res => {
                    if (res.status == ResponseStatus.Ok)
                        this.passwordChanged = true;
                }
            );
        }
    }
}
