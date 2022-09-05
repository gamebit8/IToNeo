import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { APP_CONFIG, DI_CONFIG } from '../../../app.config';
import { TEST_CONSTANTS } from '../../constants/testConstants';
import { Localization } from '../../models/localization.model';
import { UrlsConfiguration } from '../../models/urlsConfiguration.model';
import { AppConfigurationService } from '../app-configuration.service';

describe('AppConfigurationService', () => {
    let service: AppConfigurationService;
    let appConfig = DI_CONFIG;
    let appHttpSpy: jasmine.SpyObj<HttpClient>
    let testLocalizationFile: Localization;
    let testUrlConfiguration: UrlsConfiguration;

    beforeEach(() => {
        const spy = jasmine.createSpyObj('HttpClient', ['get']);

        TestBed.configureTestingModule({
            providers: [
                AppConfigurationService,
                { provide: APP_CONFIG, useValue: DI_CONFIG },
                { provide: HttpClient, useValue: spy },
            ]
        });

        service = TestBed.inject(AppConfigurationService);
        appHttpSpy = TestBed.inject(HttpClient) as jasmine.SpyObj<HttpClient>;
        testLocalizationFile = TEST_CONSTANTS.localization;
        testUrlConfiguration = TEST_CONSTANTS.urls;
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should be localization and urls not null after call load()', (done: DoneFn) => {
        appHttpSpy.get.withArgs(appConfig.localizationFileUrl).and.returnValue(of(testLocalizationFile));
        appHttpSpy.get.withArgs(appConfig.urlsConfigurationUrl).and.returnValue(of(testUrlConfiguration));

        service.settingsLoaded$.subscribe(() => {
            expect(service.isReady).toBeTrue();
            expect(service.localization).toEqual(testLocalizationFile);
            expect(service.urls).toEqual(testUrlConfiguration);
            done();
        })

        service.load();
    });
})
