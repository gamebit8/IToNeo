import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntitiesBase } from '../shared/abstract/abstract-modules/entities-base/entities-base.directive';
import { EntitiesComponentBuilder } from '../shared/abstract/abstract-modules/entities-base/entities-component.builder';
import { OperationComponentSettings } from '../shared/components/operations-menu/operationsMenuSettings.model';
import { inputType } from '../shared/enums/inputType';
import { InputModel } from '../shared/models/input.model';
import { NavFragmentSettings } from '../shared/models/navFragmentSettings.model';
import { TableWithSortColumn } from '../shared/models/tableWithSortColumn.model';
import { EmployeesEditorComponent } from './employees-editor/employees-editor.component';
import { EmployeesSearchBarComponent } from './employees-search-bar/employees-search-bar.component';
import { EmployeesService } from './employees.service';
import { Employee } from './shared/employee.model';
import { EmployeeRequest } from './shared/employeeRequest.model';
import { EmploeesFilter } from './shared/employeesFilter.model';
import { EmployeesResoponse } from './shared/employeesResponse.model';

@Component({
    selector: 'employees',
    templateUrl: '../shared/abstract/abstract-modules/entities-base/entities-base.component.html',
})

export class EmployeesComponent extends EntitiesBase<Employee, EmploeesFilter, EmployeeRequest, EmployeesResoponse>{
    constructor(protected employeesService: EmployeesService, protected activeLink: ActivatedRoute, protected router: Router) {
        super(employeesService, activeLink, router)
    }

    protected onCreating(builder: EntitiesComponentBuilder): void {
        const editorSettings = this.getEditorSetting();
        const operationButtonsSettings = this.getOperationButtonsSettings();
        const inputSettings = this.getEntityInput();
        const entityTalbeColumns = this.getReferenseEntityTableColumns();

        builder.addEntityEditor(editorSettings);
        builder.addSearchBar(EmployeesSearchBarComponent);
        builder.setComponentTitle(this.localization.employees);
        builder.setOperationButtons(operationButtonsSettings);
        builder.setEntityInput(inputSettings);
        builder.setReferenseEntityTableColumns(entityTalbeColumns);
    }

    private getEditorSetting(): { fragmentSettings: NavFragmentSettings[], defaultFragment: string } {
        return {
            fragmentSettings: [
                { title: this.localization.main, fragment: 'edit', component: EmployeesEditorComponent }
            ],
            defaultFragment: 'edit'
        }
    }

    private getOperationButtonsSettings(): OperationComponentSettings {
        return {
            addOperation: true,
            deleteOperation: true,
            editOperation: true,
            searchOperation: true,
        }
    }

    private getEntityInput(): { [key: string]: InputModel } {
        return {
            name: {
                name: 'name',
                title: this.localization.employee,
                type: inputType.text
            },
            firstName: {
                name: 'firstName',
                title: this.localization.firstName,
                type: inputType.text
            },
            lastName: {
                name: 'lastName',
                title: this.localization.lastName,
                type: inputType.text
            },
            patronymicName: {
                name: 'patronymicName',
                title: this.localization.patronymicName,
                type: inputType.text
            },
            username: {
                name: 'username',
                title: this.localization.username,
                type: inputType.text,
            },
            department: {
                name: 'department',
                title: this.localization.department,
                type: inputType.text
            },
            position: {
                name: 'position',
                title: this.localization.position,
                type: inputType.text
            },
            organization: {
                name: 'organization.name',
                title: this.localization.organization,
                type: inputType.text,
                searchHelperUrl: this.urls.organizationSearchHelperUrl
            }
        }
    }

    private getReferenseEntityTableColumns(): TableWithSortColumn[] {
        return [
            { field: 'name', title: this.localization.employee },
            { field: 'username', title: this.localization.login },
            { field: 'department', title: this.localization.department },
            { field: 'position', title: this.localization.position },
            { field: 'organization.name', title: this.localization.organization }
        ];
    }
}


