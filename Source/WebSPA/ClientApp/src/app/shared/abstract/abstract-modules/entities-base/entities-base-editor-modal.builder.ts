import { FormGroup } from "@angular/forms";
import { BaseWithNameModel } from "../../../models/baseWithName.model";
import { EntitiesBaseEditorModalSettings } from "./entities-base-editor-modal-settings.model";

export class EntitiesBaseEditorModalBuilder {
    private settings = new EntitiesBaseEditorModalSettings();

    setForm(form: FormGroup): void {
        this.settings.form = form;
    }

    setSetFormValueFromEntityHandler(handler: (entity: BaseWithNameModel, form: FormGroup) => FormGroup) {
        this.settings.setFormValueFromEntityHandler = handler;
    }

    getSettings(): EntitiesBaseEditorModalSettings {
        return this.settings;
    }
}
