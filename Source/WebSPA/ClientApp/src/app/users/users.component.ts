import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntitiesBase } from '../shared/abstract/abstract-modules/entities-base/entities-base.directive';
import { EntitiesComponentBuilder } from '../shared/abstract/abstract-modules/entities-base/entities-component.builder';
import { OperationComponentSettings } from '../shared/components/operations-menu/operationsMenuSettings.model';
import { inputType } from '../shared/enums/inputType';
import { InputModel } from '../shared/models/input.model';
import { NavFragmentSettings } from '../shared/models/navFragmentSettings.model';
import { TableWithSortColumn } from '../shared/models/tableWithSortColumn.model';
import { User } from './shared/user.model';
import { UserRequest } from './shared/userRequest.model';
import { UsersFilter } from './shared/usersFilter.model';
import { UsersResoponse } from './shared/usersResponse.model';
import { UsersEditorComponent } from './users-editor/users-editor.component';
import { UsersSearchBlockComponent } from './users-search-bar/users-search-bar.component';
import { UsersService } from './users.service';

@Component({
    selector: 'users',
    templateUrl: '../shared/abstract/abstract-modules/entities-base/entities-base.component.html'
})

export class UsersComponent extends EntitiesBase<User, UsersFilter, UserRequest, UsersResoponse>{
    constructor(protected usersService: UsersService, protected activeLink: ActivatedRoute, protected router: Router) {
        super(usersService, activeLink, router)

    }

    protected onCreating(builder: EntitiesComponentBuilder): void {
        const editorSettings = this.getEditorSetting();
        const operationButtonsSettings = this.getOperationButtonsSettings();
        const inputSettings = this.getEntityInputs();
        const entityTalbeColumns = this.getReferenseEntityTableColumns();

        builder.addEntityEditor(editorSettings);
        builder.addSearchBar(UsersSearchBlockComponent);
        builder.setComponentTitle(this.localization.users);
        builder.setOperationButtons(operationButtonsSettings);
        builder.setEntityInput(inputSettings);
        builder.setReferenseEntityTableColumns(entityTalbeColumns);
    }

    private getEditorSetting(): { fragmentSettings: NavFragmentSettings[], defaultFragment: string } {
        return {
            fragmentSettings: [
                { title: this.localization.main, fragment: 'edit', component: UsersEditorComponent }
            ],
            defaultFragment: 'edit'
        }
    }

    private getOperationButtonsSettings(): OperationComponentSettings {
        return {
            addOperation: false,
            deleteOperation: true,
            editOperation: true,
            searchOperation: true,
        }
    }

    private getEntityInputs(): { [key: string]: InputModel } {
        return {
            userName: {
                name: 'userName',
                title: this.localization.username,
                type: inputType.text
            },
            email: {
                name: 'email',
                title: this.localization.email,
                type: inputType.email
            },
            phoneNumber: {
                name: 'phoneNumber',
                title: this.localization.phoneNumber,
                type: inputType.tel
            },
            roles: {
                name: 'roles',
                title: this.localization.roles,
                type: inputType.checkbox
            },
            role: {
                name: 'roleText',
                title: this.localization.roles,
                type: inputType.text,
                searchHelperUrl: this.urls.userRolesUrl
            },
            employee: {
                name: 'employeeId',
                title: this.localization.employee,
                type: inputType.text,
                searchHelperUrl: this.urls.employeeSearchHelperUrl
            }
        }
    }

    private getReferenseEntityTableColumns(): TableWithSortColumn[] {
        return [
            { field: 'userName', title: this.localization.username },
            { field: 'email', title: this.localization.email },
            { field: 'phoneNumber', title: this.localization.phoneNumber },
            { field: 'roles', title: this.localization.roles },
            { field: 'employeeId', title: this.localization.employee }
        ]
    }
}
