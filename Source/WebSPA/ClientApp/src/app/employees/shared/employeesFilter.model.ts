import { Sorting } from '../../shared/models/sorting.model'
import { EmployeeBase } from './employeeBase.model'

export interface EmploeesFilter extends EmployeeBase, Sorting{
    organizationId: string;
}
