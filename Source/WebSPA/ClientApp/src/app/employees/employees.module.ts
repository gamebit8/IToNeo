import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MODULES_SETTINGS } from '../shared/constants/modulesSettings';
import { AuthGuard } from '../shared/guards/authGuard';
import { SharedModule } from '../shared/shared.module';
import { EmployeesEditorComponent } from './employees-editor/employees-editor.component';
import { EmployeesSearchBarComponent } from './employees-search-bar/employees-search-bar.component';
import { EmployeesComponent } from './employees.component';
import { EmployeesService } from './employees.service';

const moduleSettings = MODULES_SETTINGS.employees;

const routes: Routes = [
    { path: moduleSettings.path, component: EmployeesComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] },
    { path: `${moduleSettings.path}/:id`, component: EmployeesComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] }
]

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule],
    declarations: [
        EmployeesEditorComponent,
        EmployeesComponent,
        EmployeesSearchBarComponent
    ],
    providers: [EmployeesService]
})

export class EmployeesModule { }
