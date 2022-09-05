import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MODULES_SETTINGS } from '../shared/constants/modulesSettings';
import { AuthGuard } from '../shared/guards/authGuard';
import { SharedModule } from '../shared/shared.module';
import { EquipmentsDisposalComponent } from './equipments-disposal/equipments-disposal.component';
import { EqupmentsEditorComponent } from './equipments-editor/equipments-editor.component';
import { EqupmentsSearchBarComponent } from './equipments-search-block/equipments-search-bar.component';
import { EquipmentsSoftwareLicensesComponent } from './equipments-software-licenses/equipments-software-licenses.component';
import { EquipmentsWriteOffComponent } from './equipments-write-off/equipments-write-off.component';
import { EquipmentsComponent } from './equipments.component';
import { EquipmentsService } from './equipments.service';

const moduleSettings = MODULES_SETTINGS.equipments;

const routes: Routes = [
    { path: moduleSettings.path, component: EquipmentsComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] },
    { path: `${moduleSettings.path}/:id`, component: EquipmentsComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] }
]

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule],
    declarations: [
        EquipmentsComponent,
        EqupmentsEditorComponent,
        EqupmentsSearchBarComponent,
        EquipmentsWriteOffComponent,
        EquipmentsDisposalComponent,
        EquipmentsSoftwareLicensesComponent
    ],
    providers: [EquipmentsService]
})

export class EquipmentsModule { }
