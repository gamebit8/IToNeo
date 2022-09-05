import { BaseModel } from "../../shared/models/base.model";
import { BaseWithNameModel } from "../../shared/models/baseWithName.model";

export interface EquipmentsSoftwareLicenses extends BaseWithNameModel {
    developer: BaseModel;
    software: BaseModel;
    type: BaseModel;
    organization: BaseModel;
    licenseCode: string;
    file: BaseModel;
}
