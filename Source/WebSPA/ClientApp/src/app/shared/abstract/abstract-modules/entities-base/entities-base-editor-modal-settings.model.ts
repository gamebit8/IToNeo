import { FormGroup } from "@angular/forms";
import { BaseWithNameModel } from "../../../models/baseWithName.model";

export class EntitiesBaseEditorModalSettings {
    form: FormGroup
    setFormValueFromEntityHandler: (entity: BaseWithNameModel, form: FormGroup) => FormGroup;
}
