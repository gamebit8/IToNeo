import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MODULES_SETTINGS } from '../shared/constants/modulesSettings';
import { AppRoutes } from '../shared/enums/appRoutes';
import { UserRole } from '../shared/enums/userRole';
import { AuthGuard } from '../shared/guards/authGuard';
import { SharedModule } from '../shared/shared.module';
import { IdentityChangePasswordAfterResetComponent } from './identity-change-password-after-reset/identity-change-password-after-reset.component';
import { IdentityChangePasswordAfterResetService } from './identity-change-password-after-reset/identity-change-password-after-reset.service';
import { IdentityChangePasswordComponent } from './identity-change-password/identity-change-password.component';
import { IdentityChangePasswordService } from './identity-change-password/identity-change-password.service';
import { IdentityConfirmEmailComponent } from './identity-confirm-email/identity-confirm-email.component';
import { IdentityConfirmEmailService } from './identity-confirm-email/identity-confirm-email.service';
import { IdentityLoginComponent } from './identity-login/identity-login.component';
import { IdentityPasswordRecoveryComponent } from './identity-password-recovery/identity-password-recovery.component';
import { IdentityRegisterComponent } from './identity-register/Identity-register.component';
import { IdentityComponent } from './identity.component';
import { IdentityService } from './identity.service';

const identityConfirmEmailSettings = MODULES_SETTINGS.identityConfirmEmail;
const identityChangePasswordAfterResetSettings = MODULES_SETTINGS.identityChangePasswordAfterReset;
const identityChangePasswordSettings = MODULES_SETTINGS.identityChangePassword;
const identitySettings = MODULES_SETTINGS.identity;

const routes: Routes = [
    { path: identityConfirmEmailSettings.path, component: IdentityConfirmEmailComponent, data: { roles: identityConfirmEmailSettings.allowedUserRoles } },
    { path: identityChangePasswordAfterResetSettings.path, component: IdentityChangePasswordAfterResetComponent, data: { roles: identityChangePasswordAfterResetSettings.allowedUserRoles }, canActivate: [AuthGuard] },
    { path: identityChangePasswordSettings.path, component: IdentityChangePasswordComponent, data: { roles: identityChangePasswordSettings.allowedUserRoles }, canActivate: [AuthGuard] },
    { path: identitySettings.path, component: IdentityComponent, data: { roles: identitySettings.allowedUserRoles }, canActivate: [AuthGuard] }
]

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule],
    declarations: [
        IdentityComponent,
        IdentityChangePasswordComponent,
        IdentityLoginComponent,
        IdentityRegisterComponent,
        IdentityPasswordRecoveryComponent,
        IdentityConfirmEmailComponent,
        IdentityChangePasswordAfterResetComponent
    ],
    providers: [
        IdentityService,
        IdentityChangePasswordService,
        IdentityConfirmEmailService,
        IdentityChangePasswordAfterResetService
    ]
})
export class IdentityModule {
}
