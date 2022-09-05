import { FormGroup } from "@angular/forms";
import { InputModel } from "../../../shared/models/input.model";

export class AdministrationEditorSettings {
     inputSettings: { [key: string]: InputModel };
     form: FormGroup;
     title: string
}
