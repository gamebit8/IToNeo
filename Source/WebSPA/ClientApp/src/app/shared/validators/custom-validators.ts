import { AbstractControl, FormControl, ValidationErrors } from "@angular/forms";

export class CustomValidators {
    constructor() { }

    static passwordConfirmation(matchPasswordControls: string): ValidationErrors | null {
        return (control: FormControl): ValidationErrors => {
            const password = control.parent?.controls[matchPasswordControls]?.value;
            const passwordConfirmation = control.value;
            return password === passwordConfirmation ? null : { passwordMismatch: true };
        }
    }

    static newPasswordAndPasswordConfirmation(control: AbstractControl): ValidationErrors | null {
        const newPassword = control.parent?.controls['newPassword']?.value;
        const passwordConfirmation = control.parent?.controls['passwordConfirmation']?.value;
        return newPassword === passwordConfirmation ? null : { passwordMismatch: true };
    }

    static passwordAndPasswordConfirmation(control: AbstractControl): ValidationErrors | null {
        const password = control.parent?.controls['password']?.value;
        const passwordConfirmation = control.parent?.controls['passwordConfirmation']?.value;
        return password === passwordConfirmation ? null : { passwordMismatch: true };
    }

    static newPasswordAndOldPassword(control: AbstractControl): ValidationErrors | null {
        const newPassword = control.parent?.controls['newPassword']?.value;
        const oldPassword = control.parent?.controls['oldPassword']?.value;
        return newPassword !== oldPassword ? null : { passwordMismatch: true };
    }

    static password(control: FormControl): ValidationErrors {
        const password = String(control.value);
        const valid = password.match(/^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{6,}$/);
        return valid ? null : { notValidPassword: true };
    }

    static email(control: FormControl) {
        const email = String(control.value);
        const valid = email.match(/(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/);
        return valid ? null : { notValidEmail: true };
    }
}
