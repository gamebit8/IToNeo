import { BaseWithNameModel } from "../../shared/models/baseWithName.model";

export interface SoftwareBase extends BaseWithNameModel{
    count: number;
    usedLicenses: number;
    licenseCode: string;
    note: string;
}
