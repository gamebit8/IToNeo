import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MODULES_SETTINGS } from '../shared/constants/modulesSettings';
import { AppRoutes } from '../shared/enums/appRoutes';
import { UserRole } from '../shared/enums/userRole';
import { AuthGuard } from '../shared/guards/authGuard';
import { SharedModule } from '../shared/shared.module';
import { ProfileComponent } from './profile.component';
import { ProfileService } from './profile.service';

const moduleSettings = MODULES_SETTINGS.profile;

const routes: Routes = [
    { path: moduleSettings.path, component: ProfileComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] }
]


@NgModule({
    declarations: [ProfileComponent],
    imports: [
        SharedModule,
        RouterModule.forChild(routes),
    ],
    exports: [RouterModule],
    providers: [ProfileService]
})
export class ProfileModule { }
