import { FormGroup } from "@angular/forms";
import { InputModel } from "../../shared/models/input.model";
import { AdministrationEditorSettings } from "./models/administrationEditorComponentSettings.model";

export class AdministrationEditorBuilder {
    private componentSettings = new AdministrationEditorSettings();

    setInputs(inputSettings: { [key: string]: InputModel }): void {
        this.componentSettings.inputSettings = inputSettings;
    }

    setTitle(title: string): void {
        this.componentSettings.title = title;
    }

    setForm(form: FormGroup): void {
        this.componentSettings.form = form;
    }

    getSettings(): AdministrationEditorSettings {
        return this.componentSettings;
    }
}
