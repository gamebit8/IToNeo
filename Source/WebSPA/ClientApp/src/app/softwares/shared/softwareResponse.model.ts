import { Software } from "./software.model";
import { SoftwareEquipments } from "./softwaresEquipments.model";

export interface SoftwareResponse extends Software{
    equipments: SoftwareEquipments[];
}
