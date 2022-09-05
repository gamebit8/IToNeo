import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MODULES_SETTINGS } from '../shared/constants/modulesSettings';
import { AuthGuard } from '../shared/guards/authGuard';
import { SharedModule } from '../shared/shared.module';
import { UsersEditorComponent } from './users-editor/users-editor.component';
import { UsersSearchBlockComponent } from './users-search-bar/users-search-bar.component';
import { UsersComponent } from './users.component';
import { UsersService } from './users.service';

const moduleSettings = MODULES_SETTINGS.users;

const routes: Routes = [
    { path: moduleSettings.path, component: UsersComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] },
    { path: `${moduleSettings.path}/:id`, component: UsersComponent, data: { roles: moduleSettings.allowedUserRoles }, canActivate: [AuthGuard] }
]

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule],
    declarations: [
        UsersComponent,
        UsersEditorComponent,
        UsersSearchBlockComponent
    ],
    providers: [UsersService]
})


export class UsersModule { }
