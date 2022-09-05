import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AppRoutes } from './shared/enums/appRoutes';
import { UserRole } from './shared/enums/userRole';

export const routes: Routes = [
    { path: AppRoutes.Equipments, loadChildren: () => import('../app/equipments/equipments.module').then(m => m.EquipmentsModule) },
    { path: AppRoutes.Equipments, loadChildren: () => import('../app/equipments/equipments.module').then(m => m.EquipmentsModule) },
    { path: AppRoutes.Employees, loadChildren: () => import('../app/employees/employees.module').then(m => m.EmployeesModule) },
    { path: AppRoutes.Softwares, loadChildren: () => import('../app/softwares/softwares.module').then(m => m.SoftwaresModule) },
    { path: AppRoutes.Identity, loadChildren: () => import('../app/identity/identity.module').then(m => m.IdentityModule) },
    { path: AppRoutes.Users, loadChildren: () => import('../app/users/users.module').then(m => m.UsersModule) },
    { path: AppRoutes.Administration, loadChildren: () => import('../app/administration/administration.module').then(m => m.AdministrationModule) },
    { path: AppRoutes.Profile, loadChildren: () => import('../app/profile/profile.module').then(m => m.ProfileModule) },
    { path: '', component: HomeComponent, pathMatch: 'full', data: { roles: [UserRole.Anonymous] } }
]

export const routing = RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' });
