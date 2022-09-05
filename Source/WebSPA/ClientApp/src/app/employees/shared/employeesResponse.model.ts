import { BaseResponse } from '../../shared/models/baseResponse.model';
import { Employee } from './employee.model';

export interface EmployeesResoponse extends BaseResponse<Employee[]> {

}

