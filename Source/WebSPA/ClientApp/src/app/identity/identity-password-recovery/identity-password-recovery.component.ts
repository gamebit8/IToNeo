import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faSlash } from '@fortawesome/free-solid-svg-icons';
import { finalize, first, takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../shared/enums/ResponseStatus';
import { inputType } from '../../shared/enums/inputType';
import { InputModel } from '../../shared/models/input.model';
import { CustomValidators } from '../../shared/validators/custom-validators';
import { IdentityService } from '../identity.service';
import { IdentityAbstract } from '../shared/identity-abstract.component';
import { IdentityComponentBuilder } from '../shared/identity-component-builder';
import { IdentityPasswordRecoveryRequest } from '../shared/identity-password-recovery-request.model';

@Component({
    selector: 'identity-password-recovery',
    templateUrl: './identity-password-recovery.component.html',
})

export class IdentityPasswordRecoveryComponent extends IdentityAbstract {
    private passwordReset: boolean

    constructor(protected identityService: IdentityService) {
        super(identityService)
    }

    protected onCreateComponent(builder: IdentityComponentBuilder) {
        builder.useForm(this.getForm());
        builder.useInputSettings(this.getInputSettings());
    }

    private getForm(): FormGroup {
        return new FormGroup({
            'email': new FormControl('', Validators.compose([Validators.required, CustomValidators.email]))
        });
    }

    private getInputSettings(): { [key: string]: InputModel } {
        return {
            'email': { name:'email', placeholder: this.localization.email, type: inputType.email },
        };
    }

    private onSubmitForm(): void {
        this.isLoading = true;
        const req = this.form.value as IdentityPasswordRecoveryRequest
        this.identityService
            .recoverPassword(req)
            .pipe(
                takeUntil(this.notifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok) {
                    this.passwordReset = true;
                }
            }
        );
    }
}
