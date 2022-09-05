import { EquipmentBase } from './equipmentBase.model'
import { BaseModel } from '../../shared/models/base.model'
import { BaseWithNameModel } from '../../shared/models/baseWithName.model'

export interface Equipment extends EquipmentBase{
    inventoryNumber: string;
    status: BaseModel;
    organization: BaseModel;
    type: BaseModel;
    employee: BaseModel;
    place: BaseModel;
    writeOff: BaseModel;
    disposal: BaseModel;
    file: BaseWithNameModel;
}
