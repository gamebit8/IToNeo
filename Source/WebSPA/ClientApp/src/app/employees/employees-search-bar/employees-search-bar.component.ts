import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntitiesBaseSearchBar } from '../../shared/abstract/abstract-modules/entities-base/entities-base-search-bar.directive';
import { Employee } from '../shared/employee.model';
import { EmploeesFilter } from '../shared/employeesFilter.model';

@Component({
    selector: 'employees-search-bar',
    templateUrl: './employees-search-bar.component.html',
})

export class EmployeesSearchBarComponent extends EntitiesBaseSearchBar<Employee, EmploeesFilter>{
    constructor(protected activeLink: ActivatedRoute, protected router: Router) {
        super(activeLink, router)
    }
}
