import { AppRoutes } from "../enums/appRoutes";
import { UserRole } from "../enums/userRole";

export interface ModuleSettings {
    path: string;
    allowedUserRoles: string[];
}

export class MODULES_SETTINGS {
    static administration: ModuleSettings = {
        path: AppRoutes.Administration,
        allowedUserRoles: [UserRole.Administrator]
    }
    static equipments: ModuleSettings = {
        path: AppRoutes.Equipments,
        allowedUserRoles: [UserRole.Administrator, UserRole.Operator]
    }
    static employees: ModuleSettings = {
        path: AppRoutes.Employees,
        allowedUserRoles: [UserRole.Administrator, UserRole.Operator]
    }
    static identity: ModuleSettings = {
        path: AppRoutes.Identity,
        allowedUserRoles: [UserRole.Anonymous]
    }
    static softwares: ModuleSettings = {
        path: AppRoutes.Softwares,
        allowedUserRoles: [UserRole.Administrator, UserRole.Operator]
    }
    static identityConfirmEmail: ModuleSettings = {
        path: AppRoutes.IdentityConfirmEmail,
        allowedUserRoles: [UserRole.Anonymous]
    }
    static identityChangePasswordAfterReset: ModuleSettings = {
        path: AppRoutes.IdentityChangePasswordAfterReset,
        allowedUserRoles: [UserRole.Anonymous]
    }
    static identityChangePassword: ModuleSettings = {
        path: AppRoutes.IdentityChangePassword,
        allowedUserRoles: [UserRole.Anonymous]
    }
    static users: ModuleSettings = {
        path: AppRoutes.Users,
        allowedUserRoles: [UserRole.Administrator, UserRole.Operator]
    }
    static profile: ModuleSettings = {
        path: AppRoutes.Profile,
        allowedUserRoles: [UserRole.Anonymous]
    }
}
