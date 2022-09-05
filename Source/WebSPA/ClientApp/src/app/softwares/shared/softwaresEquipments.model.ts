import { BaseModel } from "../../shared/models/base.model";
import { BaseWithNameModel } from "../../shared/models/baseWithName.model";

export interface SoftwareEquipments extends BaseWithNameModel{
    serialNumber: string;
    inventoryNumber: string;
    organization: BaseModel;
    type: BaseModel;
    employee: BaseModel;
    place: BaseModel;
}
