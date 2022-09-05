import { BaseWithNameModel } from '../../shared/models/baseWithName.model';
import { Employee } from './employee.model';

export interface EmployeeResponse extends Employee {
    organization: BaseWithNameModel;
    file: BaseWithNameModel;
}

