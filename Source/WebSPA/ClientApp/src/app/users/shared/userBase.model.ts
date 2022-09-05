import { BaseWithNameModel } from "../../shared/models/baseWithName.model";

export interface UserBase extends BaseWithNameModel{
    id: string;
    userName: string;
    email: string;
    phoneNumber: string;
    employeeId: string;
    roles: string[];
}
