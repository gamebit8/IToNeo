import { BaseWithNameModel } from "../../shared/models/baseWithName.model";

export interface Place extends BaseWithNameModel{
    address: string;
}
