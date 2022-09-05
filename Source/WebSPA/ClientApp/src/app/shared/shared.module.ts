import { CommonModule } from '@angular/common';
import { HttpClientJsonpModule, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { InjectionToken, ModuleWithProviders, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgxdModule } from '@ngxd/core';
import { NgEventBus } from 'ng-event-bus';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { APP_CONFIG, DI_CONFIG } from '../app.config';
import { DatalistFormcontrolWithApiQueryComponent } from '../shared/components/datalist-with-api-query/datalist-formcontrol-with-api-query/datalist-formcontrol-with-api-query.component';
import { DatalistWithApiQueryComponent } from '../shared/components/datalist-with-api-query/datalist-with-api-query/datalist-with-api-query.component';
import { EntitiesBaseService } from './abstract/abstract-modules/entities-base/entities-base.service';
import { AuthService } from './abstract/abstract-service/auth.service';
import { ConfigurationService } from './abstract/abstract-service/configuration.service';
import { DataService } from './abstract/abstract-service/data.service';
import { EventBusService } from './abstract/abstract-service/event-bus.service';
import { MapperService } from './abstract/abstract-service/mapper.service';
import { StorageService } from './abstract/abstract-service/storage.service';
import { CheckboxGroupComponent } from './components/checkbox-group/checkbox-group.component';
import { FileComponent } from './components/file/file.component';
import { InputFormcontrolWithLabelAndInvalidTooltipComponent } from './components/input-with-label-and-invalid-tooltip/input-formcontrol-with-label-and-invalid-tooltip/input-formcontrol-with-label-and-invalid-tooltip.component';
import { InputWithLabelAndInvalidTooltipComponent } from './components/input-with-label-and-invalid-tooltip/input-with-label-and-invalid-tooltip/input-with-label-and-invalid-tooltip.component';
import { BaseInputWithLabelAndInvalidTooltipComponent } from './components/input-with-label-and-invalid-tooltip/shared/base-input-with-label-and-invalid-tooltip.component';
import { LabelCustomComponent } from './components/label/label-custom/label-custom.component';
import { LabelWithInvalidTooltipComponent } from './components/label/label-with-invalid-tooltip/label-with-invalid-tooltip.component';
import { ModalEditorComponent } from './components/modal-editor/modal-editor.component';
import { NavsFragmentComponent } from './components/navs-fragment/navs-fragment.component';
import { OperationsMenuComponent } from './components/operations-menu/operations-menu.component';
import { PillButtonComponent } from './components/pill-button/pill-button.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { TableWithSortTitleButtonsComponent } from './components/table-with-sort/table-with-sort-title-butttons/table-with-sort-title-buttons.component';
import { TableWithSortComponent } from './components/table-with-sort/table-with-sort.component';
import { ViewCustomizationComponent } from './components/view-customization/view-customization.component';
import { AuthGuard } from './guards/authGuard';
import { AuthInterceptor } from './http-interceptors/auth-interceptor';
import { ErrorInterceptor } from './http-interceptors/error-interceptor';
import { TimeoutInterceptor } from './http-interceptors/timeout-interceptor';
import { Localization } from './models/localization.model';
import { UrlsConfiguration } from './models/urlsConfiguration.model';
import { AppConfigurationService } from './services/app-configuration.service';
import { AppStorageService } from './services/app-storage.service';
import { JwtAuthService } from './services/jwt-auth.service';
import { AppMapperService } from './services/mapper.service';
import { NgEventBusService } from './services/ng-event.service';
import { RestDataService } from './services/rest-data.service';


export const URLS = new InjectionToken<UrlsConfiguration>('Urls')

export const LOCALIZATION = new InjectionToken<Localization>('Localization')

@NgModule({
    imports: [
        BrowserModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        HttpClientModule,
        HttpClientJsonpModule,
        FontAwesomeModule,
        NgSelectModule,
        InfiniteScrollModule,
        NgxdModule
    ],
    declarations: [
        InputFormcontrolWithLabelAndInvalidTooltipComponent,
        InputWithLabelAndInvalidTooltipComponent,
        OperationsMenuComponent,
        TableWithSortTitleButtonsComponent,
        TableWithSortComponent,
        ModalEditorComponent,
        SearchBarComponent,
        PillButtonComponent,
        LabelCustomComponent,
        LabelWithInvalidTooltipComponent,
        DatalistFormcontrolWithApiQueryComponent,
        DatalistWithApiQueryComponent,
        BaseInputWithLabelAndInvalidTooltipComponent,
        SearchBarComponent,
        NavsFragmentComponent,
        ViewCustomizationComponent,
        FileComponent,
        CheckboxGroupComponent,
    ],
    exports: [
        BrowserModule,
        NgxdModule,
        HttpClientModule,
        HttpClientJsonpModule,
        NgSelectModule,
        InfiniteScrollModule,
        FontAwesomeModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        InputFormcontrolWithLabelAndInvalidTooltipComponent,
        OperationsMenuComponent,
        TableWithSortTitleButtonsComponent,
        TableWithSortComponent,
        ModalEditorComponent,
        SearchBarComponent,
        PillButtonComponent,
        DatalistWithApiQueryComponent,
        InputWithLabelAndInvalidTooltipComponent,
        LabelCustomComponent,
        LabelWithInvalidTooltipComponent,
        DatalistFormcontrolWithApiQueryComponent,
        DatalistWithApiQueryComponent,
        BaseInputWithLabelAndInvalidTooltipComponent,
        NavsFragmentComponent,
        ViewCustomizationComponent,
        FileComponent,
        CheckboxGroupComponent
    ]
})

export class SharedModule {
    static forRoot(): ModuleWithProviders<SharedModule> {
        return {
            ngModule: SharedModule,
            providers: [
                EntitiesBaseService,
                NgEventBus,
                AuthGuard,
                { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
                { provide: HTTP_INTERCEPTORS, useClass: TimeoutInterceptor, multi: true },
                { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
                { provide: APP_CONFIG, useValue: DI_CONFIG },
                { provide: AuthService, useClass: JwtAuthService },
                { provide: DataService, useClass: RestDataService },
                { provide: EventBusService, useClass: NgEventBusService },
                { provide: MapperService, useClass: AppMapperService },
                { provide: StorageService, useClass: AppStorageService },
                { provide: ConfigurationService, useClass: AppConfigurationService }
            ]
        };
    }
}

