import { InputModel } from "../../shared/models/input.model";

export interface IdentityInputs {
    username: InputModel
    password: InputModel
    email: InputModel
    oldPassword: InputModel
    newPassword: InputModel
    passwordConfirmation: InputModel
    confirmEmail: InputModel
    changePasswod: InputModel
}
