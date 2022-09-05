import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { AdministrationModule } from './administration/administration.module';
import { AppComponent } from './app.component';
import { routing } from './app.route';
import { AppService } from './app.service';
import { EmployeesModule } from './employees/employees.module';
import { EquipmentsModule } from './equipments/equipments.module';
import { HeaderBarModule } from './header-bar/header-bar.module';
import { HomeComponent } from './home/home.component';
import { IdentityModule } from './identity/identity.module';
import { NavBarExtendedComponent } from './nav-bar-extended/nav-bar-extended.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { ProfileModule } from './profile/profile.module';
import { SharedModule } from './shared/shared.module';
import { SoftwaresModule } from './softwares/softwares.module';
import { UsersModule } from './users/users.module';

@NgModule({
    declarations: [
        AppComponent,
        NavBarComponent,
        HomeComponent,
        NavBarExtendedComponent,
    ],
    imports: [
        EmployeesModule,
        SoftwaresModule,
        HeaderBarModule,
        SharedModule.forRoot(),
        EquipmentsModule,
        IdentityModule,
        UsersModule,
        AdministrationModule,
        ProfileModule,
        routing,
    ],
    providers: [AppService],
    bootstrap: [AppComponent],
    schemas: [NO_ERRORS_SCHEMA],
  })

export class AppModule { }


