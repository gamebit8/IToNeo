import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MODULES_SETTINGS } from '../shared/constants/modulesSettings';
import { AuthGuard } from '../shared/guards/authGuard';
import { SharedModule } from '../shared/shared.module';
import { SoftwaresEditorComponent } from './softwares-editor/softwares-editor.component';
import { SoftwaresEquipmentsComponent } from './softwares-equipments/softwares-equipments.component';
import { SoftwaresSearchBarComponent } from './softwares-search-bar/softwares-search-bar.component';
import { SoftwaresComponent } from './softwares.component';
import { SoftwaresService } from './softwares.service';

const moduleSettings = MODULES_SETTINGS.softwares;

const routes: Routes = [
    { path: moduleSettings.path, component: SoftwaresComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] },
    { path: `${moduleSettings.path}/:id`, component: SoftwaresComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] }
]

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes),
    ],
    exports: [RouterModule],
    declarations: [
        SoftwaresEditorComponent,
        SoftwaresComponent,
        SoftwaresSearchBarComponent,
        SoftwaresEquipmentsComponent
    ],
    providers: [SoftwaresService]
})

export class SoftwaresModule {

}
