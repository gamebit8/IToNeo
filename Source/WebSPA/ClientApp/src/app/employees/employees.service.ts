import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { EntitiesBaseService } from '../shared/abstract/abstract-modules/entities-base/entities-base.service';
import { ConfigurationService } from '../shared/abstract/abstract-service/configuration.service';
import { DataService } from '../shared/abstract/abstract-service/data.service';
import { EventBusService } from '../shared/abstract/abstract-service/event-bus.service';
import { MapperService } from '../shared/abstract/abstract-service/mapper.service';
import { StorageService } from '../shared/abstract/abstract-service/storage.service';
import { Employee } from './shared/employee.model';
import { EmployeeRequest } from './shared/employeeRequest.model';
import { EmploeesFilter } from './shared/employeesFilter.model';
import { EmployeesResoponse } from './shared/employeesResponse.model';

@Injectable()
export class EmployeesService extends EntitiesBaseService<Employee, EmploeesFilter, EmployeeRequest, EmployeesResoponse> {

    constructor(
        protected dataService: DataService,
        protected configurationService: ConfigurationService,
        protected eventBusService: EventBusService,
        protected router: Router,
        protected storageService: StorageService,
        protected mapperService: MapperService
    ) {
        super(dataService, configurationService, eventBusService, storageService, mapperService)
        this.entitiesUrl = this.configurationService.urls.employeesUrl;
    }
}
