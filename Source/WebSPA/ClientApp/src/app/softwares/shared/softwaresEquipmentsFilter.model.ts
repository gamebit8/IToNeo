import { EquipmentBase } from "../../equipments/shared/equipmentBase.model";
import { Sorting } from "../../shared/models/sorting.model";

export interface EquipmentsFilter extends EquipmentBase, Sorting {
    statusId: string;
    organizationId: string;
    typeId: string;
    equipmentId: string;
    placeId: string;
    employeeId: string;
}
