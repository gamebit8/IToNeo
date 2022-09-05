import { BaseResponse } from '../../shared/models/baseResponse.model';
import { User } from './user.model';

export interface UsersResoponse extends BaseResponse<User[]> {

}

