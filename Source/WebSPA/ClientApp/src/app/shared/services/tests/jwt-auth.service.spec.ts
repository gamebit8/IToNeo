import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';
import { DataService } from '../../abstract/abstract-service/data.service';
import { StorageService } from '../../abstract/abstract-service/storage.service';
import { TEST_CONSTANTS } from '../../constants/testConstants';
import { AuthenticateResponse } from '../../models/authenticate-response.model';
import { BaseResponse } from '../../models/baseResponse.model';
import { UrlsConfiguration } from '../../models/urlsConfiguration.model';
import { JwtAuthService } from '../jwt-auth.service';

describe('JwtAuthService', () => {
    let service: JwtAuthService;
    let configurationServiceSpy: jasmine.SpyObj<ConfigurationService>;
    let dataServiceSpy: jasmine.SpyObj<DataService>;
    let storageServiceSpy: jasmine.SpyObj<StorageService>
    let testUrlConfiguration: UrlsConfiguration;

    beforeEach(() => {
        const csp = jasmine.createSpyObj('ConfigurationService', [], { isReady: true, urls: { authenticateUrl: 'authenticateUrl' } });
        const dss = jasmine.createSpyObj('DataService', ['post']);
        const sss = jasmine.createSpyObj('StorageService', ['retrieve', 'store', 'remove']);

        TestBed.configureTestingModule({
            providers: [
                JwtAuthService,
                { provide: ConfigurationService, useValue: csp },
                { provide: DataService, useValue: dss },
                { provide: StorageService, useValue: sss }
            ]
        });
        service = TestBed.inject(JwtAuthService);
        configurationServiceSpy = TestBed.inject(ConfigurationService) as jasmine.SpyObj<ConfigurationService>;
        dataServiceSpy = TestBed.inject(DataService) as jasmine.SpyObj<DataService>;
        storageServiceSpy = TestBed.inject(StorageService) as jasmine.SpyObj<StorageService>;
        testUrlConfiguration = TEST_CONSTANTS.urls;
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should be return isAuthenticated username roles in not null after call authenticate()', (done: DoneFn) => {
        const testUserRoles = ['testAdmin', 'testUser'];
        const testUserName = 'testUsername';
        const testPassword = 'testPassword';
        const response = <BaseResponse<AuthenticateResponse>>{
            status: 200,
            data: {
                token: 'testToken',
                username: testUserName,
                roles: testUserRoles
            }
        }
        dataServiceSpy.post
            .withArgs('authenticateUrl', { username: testUserName, password: testPassword })
            .and
            .returnValue(of(response));

        service.authenticate(testUserName, testPassword).subscribe(() => {
            expect(service.isAuthenticated).toBeTrue();
            expect(service.username).toContain(testUserName);
            expect(service.roles).toEqual(testUserRoles);
            done();
        });
    })

    it('should be isAuthenticated is false afterc call logout()', () => {
        setTimeout(() => {
            if (service.isAuthenticated) {
                service.logout();
                expect(service.isAuthenticated).toBeFalse();
            }
        }, 1000)
    });
})
