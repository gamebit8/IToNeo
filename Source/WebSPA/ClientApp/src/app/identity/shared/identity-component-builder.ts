import { FormGroup, NgForm } from "@angular/forms";
import { InputModel } from "../../shared/models/input.model";

export class IdentityComponentBuilder {
    public get form(): FormGroup {
        return this._form
    }
    public get inputSettings(): any {
        return this._inputSettings
    }
    private _form: FormGroup
    private _inputSettings: {[key: string]: InputModel}

    public useForm(form: FormGroup): void {
        this._form = form;
    }

    public useInputSettings(inputSettings: { [key: string]: InputModel }): void{
        this._inputSettings = inputSettings;
    }
}
