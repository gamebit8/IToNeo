import { EquipmentBase } from './equipmentBase.model'

export interface EquipmentRequest extends EquipmentBase{
    statusId: string;
    organizationId: string;
    typeId: string;
    employeeId: string;
    placeId: string;
}
