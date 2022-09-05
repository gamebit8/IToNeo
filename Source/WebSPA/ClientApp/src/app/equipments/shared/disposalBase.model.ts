import { BaseWithNameModel } from "../../shared/models/baseWithName.model";

export interface DisposalBase extends BaseWithNameModel {
    resalePrice: number;
    date: Date;
    note: string;
    equipmentId: string;
}
