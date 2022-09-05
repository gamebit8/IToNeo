import { FormGroup } from "@angular/forms";

export interface NavFragmentSettings {
    title: string;
    fragment: string;
    component: any;
    form?: FormGroup;
    hide?: boolean;
    submitFormHandler?: () => void;
}
