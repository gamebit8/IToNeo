import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { finalize, takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../shared/enums/ResponseStatus';
import { inputType } from '../../shared/enums/inputType';
import { InputModel } from '../../shared/models/input.model';
import { CustomValidators } from '../../shared/validators/custom-validators';
import { IdentityService } from '../identity.service';
import { IdentityAbstract } from '../shared/identity-abstract.component';
import { IdentityComponentBuilder } from '../shared/identity-component-builder';
import { IdentityLoginRequest } from '../shared/identity-login-request.model';

@Component({
    selector: 'identity-login',
    templateUrl: './identity-login.component.html'
})

export class IdentityLoginComponent extends IdentityAbstract{
    private showAlert: boolean;
    private alertMessage: string;

    constructor(protected identityService: IdentityService, private router: Router) {
        super(identityService);
    }

    protected onCreateComponent(builder: IdentityComponentBuilder) {
        builder.useForm(this.getForm());
        builder.useInputSettings(this.getInputSettings());
        this.alertMessage = this.localization.wrongLoginOrPassword;
    }

    private getForm(): FormGroup {
        return new FormGroup({
            'username': new FormControl('', Validators.required),
            'password': new FormControl('', Validators.compose([Validators.required, CustomValidators.password]))
        });
    }

    private getInputSettings(): { [key: string]: InputModel } {
        return {
            'username': { name: 'username', placeholder: this.localization.username, type: inputType.text },
            'password': { name: 'password', placeholder: this.localization.password, type: inputType.password }
        };
    }

    private onSubmitForm(): void {
        const response = this.form.value as IdentityLoginRequest;
        this.isLoading = true;
        this.identityService
            .authenticate(response.username, response.password)
            .pipe(
                takeUntil(this.notifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(
                res => {
                    if (res.status == ResponseStatus.Ok) {
                        this.navigateToRoot();
                }},
                err => {
                    this.showAlert = true;
                    console.log(err)
                }
            );
    }

    private navigateToRoot(): void {
        this.router.navigate(['']);
    }
}
