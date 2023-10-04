import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { finalize, first, takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../shared/enums/responseStatus';
import { inputType } from '../../shared/enums/inputType';
import { InputModel } from '../../shared/models/input.model';
import { CustomValidators } from '../../shared/validators/custom-validators';
import { IdentityService } from '../identity.service';
import { IdentityAbstract } from '../shared/identity-abstract.component';
import { IdentityComponentBuilder } from '../shared/identity-component-builder';
import { IdentityRegisterRequest } from '../shared/identity-register-request.model';

@Component({
    selector: 'Identity-register',
    templateUrl: './Identity-register.component.html',
})

export class IdentityRegisterComponent extends IdentityAbstract {
    private Registered: boolean

    constructor(protected identityService: IdentityService, protected router: Router) {
        super(identityService);
    }

    protected onCreateComponent(builder: IdentityComponentBuilder) {
        builder.useForm(this.getForm());
        builder.useInputSettings(this.getInputSettings());
    }

    private getForm(): FormGroup {
        return new FormGroup({
            'username': new FormControl('', Validators.required),
            'email': new FormControl('', Validators.compose([Validators.required, CustomValidators.email])),
            'password': new FormControl('', Validators.compose([
                Validators.required,
                CustomValidators.password,
                CustomValidators.passwordAndPasswordConfirmation
            ])),
            'passwordConfirmation': new FormControl('', Validators.compose([
                Validators.required,
                CustomValidators.password,
                CustomValidators.passwordAndPasswordConfirmation
            ]))
        });
    }

    private getInputSettings(): { [key: string]: InputModel } {
        return {
            'username': { name: 'username', placeholder: this.localization.username, type: inputType.text },
            'email': { name: 'email', placeholder: this.localization.email, type: inputType.email },
            'password': { name: 'password', placeholder: this.localization.password, type: inputType.password },
            'passwordConfirmation': {
                name: 'passwordConfirmation',
                placeholder: this.localization.passwordConfirmation,
                type: inputType.password
            },
        };
    }

    private onSubmitForm(): void {
        this.isLoading = true;
        const req = this.form.value as IdentityRegisterRequest
        this.identityService
            .register(req)
            .pipe(
                takeUntil(this.notifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok) {
                    this.Registered = true;
                }
            });
    }
}
