import { EmployeeBase } from "./employeeBase.model"

export interface EmployeeRequest extends EmployeeBase{
    organizationId: string;
}
