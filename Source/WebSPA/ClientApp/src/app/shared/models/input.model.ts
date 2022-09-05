import { inputType } from "../enums/inputType";

export interface InputModel {
    name: string;
    type: inputType;
    placeholder?: string;
    title?: string;
    readonly?: boolean;
    searchHelperUrl?: string;
}
