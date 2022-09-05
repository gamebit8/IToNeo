import { BaseWithNameModel } from "./baseWithName.model";

export interface FileRequets extends BaseWithNameModel {
    equipmentId?: string | number;
    employeeId?: string | number;
    softwareLicenseId?: string | number;
}
