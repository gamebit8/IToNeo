import { BaseResponse } from '../../shared/models/baseResponse.model';
import { Equipment }     from './equipment.model'

export interface EquipmentsResponse extends BaseResponse<Equipment[]> {
}
