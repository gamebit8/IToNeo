import { BaseModel } from "../../shared/models/base.model";
import { BaseWithNameModel } from "../../shared/models/baseWithName.model";
import { SoftwareBase } from "./softwareBase.model";

export interface Software extends SoftwareBase {
    type: BaseWithNameModel;
    software: BaseWithNameModel;
    organization: BaseWithNameModel;
    developer: BaseWithNameModel;
    file: BaseWithNameModel;
    note: string;
}
