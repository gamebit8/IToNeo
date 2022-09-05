import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { finalize, takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../shared/enums/ResponseStatus';
import { inputType } from '../../shared/enums/inputType';
import { InputModel } from '../../shared/models/input.model';
import { CustomValidators } from '../../shared/validators/custom-validators';
import { IdentityAbstract } from '../shared/identity-abstract.component';
import { IdentityComponentBuilder } from '../shared/identity-component-builder';
import { IdentityChangePasswordAfterResetService } from './identity-change-password-after-reset.service';

@Component({
    selector: 'identity-change-password-after-reset',
    templateUrl: './identity-change-password-after-reset.component.html',
})

export class IdentityChangePasswordAfterResetComponent extends IdentityAbstract implements OnInit{
    private email: string
    private token: string
    private passwordChanged: boolean

    constructor(protected identityChangePasswordAfterResetService: IdentityChangePasswordAfterResetService, private activeLink: ActivatedRoute) {
        super(identityChangePasswordAfterResetService)
    }

    ngOnInit(): void {
        this.subscribeActivatedRoute();
    }

    protected onCreateComponent(builder: IdentityComponentBuilder) {
        builder.useForm(this.getForm());
        builder.useInputSettings(this.getInputSettings());
    }

    private getForm(): FormGroup {
        return new FormGroup({
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
            'newPassword': { name: 'username', placeholder: this.localization.newPassword, type: inputType.password },
            'passwordConfirmation': { name: 'passwordConfirmation', placeholder: this.localization.passwordConfirmation, type: inputType.password }
        };
    }

    private subscribeActivatedRoute(): void {
        this.activeLink
            .queryParams
            .pipe(takeUntil(this.notifier))
            .subscribe(query => {
                this.email = query['email'];
                this.token = query['token'];
            })
    }

    private onSubmitForm(): void {
        if (this.form.valid && this.email && this.token) {
            this.isLoading = true;
            this.identityChangePasswordAfterResetService
                .changePassword(this.email, this.token, this.form.controls['newPassword'].value)
                .pipe(
                    takeUntil(this.notifier),
                    finalize(() => this.isLoading = false)
                )
                .subscribe(res => {
                    if (res.status == ResponseStatus.Ok)
                        this.passwordChanged = true;
                });
        }
    }
}
