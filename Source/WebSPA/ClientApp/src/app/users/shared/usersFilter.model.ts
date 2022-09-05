import { Sorting } from '../../shared/models/sorting.model'
import { UserBase } from './userBase.model'

export interface UsersFilter extends UserBase, Sorting{
    roleId: string;
}
