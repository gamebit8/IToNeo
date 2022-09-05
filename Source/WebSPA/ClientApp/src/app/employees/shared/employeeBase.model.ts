import { BaseWithNameModel } from "../../shared/models/baseWithName.model";

export interface EmployeeBase extends BaseWithNameModel{
    username: string;
    department: string;
    position: string;
}
