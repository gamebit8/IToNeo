import { BaseWithNameModel } from "../../shared/models/baseWithName.model";

export interface WriteOffBase extends BaseWithNameModel {
    liquidationValue: number;
    note: string;
    equipmentId: string;
    date: Date;
}
