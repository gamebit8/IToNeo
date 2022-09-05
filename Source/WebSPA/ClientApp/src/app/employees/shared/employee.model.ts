import { BaseModel } from "../../shared/models/base.model";
import { EmployeeBase } from "./employeeBase.model";

export interface Employee extends EmployeeBase {
    firstName: string;
    lastName: string;
    patronymicName: string;
}
