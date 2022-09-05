import { Sorting } from "../../shared/models/sorting.model";
import { EquipmentBase } from "./equipmentBase.model";

export interface EquipmentsFilter extends EquipmentBase, Sorting {
    statusId: string;
    organizationId: string;
    typeId: string;
    equipmentId: string;
    placeId: string;
    employeeId: string;
    dateOfCreationFrom: Date;
    dateOfCreationTo: Date;
    dateOfInstallationFrom: Date;
    dateOfInstallationTo: Date;
}
