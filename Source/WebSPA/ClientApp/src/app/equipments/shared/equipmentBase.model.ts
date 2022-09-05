import { BaseWithNameModel } from "../../shared/models/baseWithName.model";

export interface EquipmentBase extends BaseWithNameModel{
    serialNumber: string;
    note: string;
    dateOfInstallation: Date;
    dateOfCreation: Date;
    writeOffId: string;
    disposalId: string;
}
