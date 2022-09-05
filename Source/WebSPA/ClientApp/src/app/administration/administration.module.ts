import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MODULES_SETTINGS } from '../shared/constants/modulesSettings';
import { AuthGuard } from '../shared/guards/authGuard';
import { SharedModule } from '../shared/shared.module';
import { AdministrationEquipmentStatusesEditorComponent } from './administration-equipment-statuses/administration-equipment-statuses-editor.component';
import { AdministrationEquipmentStatusesTableComponent } from './administration-equipment-statuses/administration-equipment-statuses-table.component';
import { AdministrationEquipmentTypesEditorComponent } from './administration-equipment-types/administration-equipment-types-editor.component';
import { AdministrationEquipmentTypesTableComponent } from './administration-equipment-types/administration-equipment-types-table.component';
import { AdministrationOrganizationsEditorComponent } from './administration-organizations/administration-organizations-editor.component';
import { AdministrationOrganizationsTableComponent } from './administration-organizations/administration-organizations-table.component';
import { AdministrationPlacesEditorComponent } from './administration-places/administration-places-editor.component';
import { AdministrationPlacesTableComponent } from './administration-places/administration-places-table.component';
import { AdministrationComponent } from './administration.component';
import { AdministrationEditorComponent } from './shared/components/administration-editor/administration-editor.component';
import { AdministrationTableHeaderComponent } from './shared/components/administration-table-header/administration-table-header.component';

const moduleSettings = MODULES_SETTINGS.administration;

const routes: Routes = [
    { path: moduleSettings.path, component: AdministrationComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] }
]

@NgModule({
    declarations: [
        AdministrationComponent,
        AdministrationEquipmentTypesTableComponent,
        AdministrationEquipmentTypesEditorComponent,
        AdministrationEquipmentStatusesTableComponent,
        AdministrationEquipmentStatusesEditorComponent,
        AdministrationOrganizationsTableComponent,
        AdministrationOrganizationsEditorComponent,
        AdministrationPlacesTableComponent,
        AdministrationPlacesEditorComponent,
        AdministrationEditorComponent,
        AdministrationTableHeaderComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class AdministrationModule { }
