import { SoftwareBase } from "./softwareBase.model";

export interface SoftwareRequest extends SoftwareBase{
    typeId: string;
    softwareId: string;
    organizationId: string; 
}
