import { DisposalBase } from './disposalBase.model';
import { Equipment } from './equipment.model';
import { EquipmentsSoftwareLicenses } from './equipmentsSoftwareLicenses.model';
import { WriteOffBase } from './writeOffBase.model';

export interface EquipmentResponse extends Equipment {
    writeOff: WriteOffBase;
    disposal: DisposalBase;
    softwareLicenses: EquipmentsSoftwareLicenses[];
}
