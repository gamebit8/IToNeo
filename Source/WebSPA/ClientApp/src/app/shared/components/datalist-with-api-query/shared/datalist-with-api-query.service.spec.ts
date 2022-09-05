import { HttpParams } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { ConfigurationService } from '../../../abstract/abstract-service/configuration.service';
import { DataService } from '../../../abstract/abstract-service/data.service';
import { MapperService } from '../../../abstract/abstract-service/mapper.service';
import { TEST_CONSTANTS } from '../../../constants/testConstants';
import { BaseResponseWithHateos } from '../../../models/baseResponseWithHateos.model';
import { BaseWithNameModel } from '../../../models/baseWithName.model';
import { Localization } from '../../../models/localization.model';
import { UrlsConfiguration } from '../../../models/urlsConfiguration.model';
import { DatalistWithApiQueryService } from './datalist-with-api-query.service';

describe('DatalistWithApiQueryService', () => {
    let service: DatalistWithApiQueryService;
    let configurationServiceSpy: jasmine.SpyObj<ConfigurationService>;
    let dataServiceSpy: jasmine.SpyObj<DataService>;
    let mapperServiceSpy: jasmine.SpyObj<MapperService>
    let testUrlConfiguration: UrlsConfiguration;
    let testEntitiesUrl;
    let testLocalizationFile: Localization;

    beforeEach(() => {
        testLocalizationFile = TEST_CONSTANTS.localization;

        const csp = jasmine.createSpyObj('ConfigurationService', [], { isReady: true, localization: testLocalizationFile });
        const dss = jasmine.createSpyObj('DataService', ['get']);
        const mss = jasmine.createSpyObj('MapperService', ['mapBaseResponseWithHateoasToNextPageUrl']);

        TestBed.configureTestingModule({
            providers: [
                DatalistWithApiQueryService,
                { provide: ConfigurationService, useValue: csp },
                { provide: DataService, useValue: dss },
                { provide: MapperService, useValue: mss }
            ]
        });
        service = TestBed.inject(DatalistWithApiQueryService);
        configurationServiceSpy = TestBed.inject(ConfigurationService) as jasmine.SpyObj<ConfigurationService>;
        dataServiceSpy = TestBed.inject(DataService) as jasmine.SpyObj<DataService>;
        mapperServiceSpy = TestBed.inject(MapperService) as jasmine.SpyObj<MapperService>;
        testEntitiesUrl = 'testEntitiesUrl';
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('set entitiesUrl', () => {
        service.setEntitiesUrl(testEntitiesUrl);

        //@ts-ignore
        expect(service.entitiesUrl).toBeTruthy(testEntitiesUrl);
    });

    it('should be return entities with arg name', (done: DoneFn) => {
        const nameFilter = 'testNameFilter';
        const nextPageUrl = 'nextPageUrl'
        const testHttpParamm = new HttpParams().set('name', nameFilter)
        const responseData = [{ id: 'id1', name: 'name1' }, { id: 'id2', name: 'name1' }];
        const responseLink = [{ rel: 'NextPage', href: nextPageUrl }]
        const repsponse = <BaseResponseWithHateos<BaseWithNameModel[]>>{ status: 200, data: responseData, link: responseLink }

        dataServiceSpy.get.withArgs(testEntitiesUrl, testHttpParamm).and.returnValue(of(repsponse));
        dataServiceSpy.get.withArgs(testEntitiesUrl).and.returnValue(of(repsponse));
        mapperServiceSpy.mapBaseResponseWithHateoasToNextPageUrl.and.returnValue(nextPageUrl);
        service.setEntitiesUrl(testEntitiesUrl);

        service.getEntities(nameFilter).subscribe((res) => {
            expect(res).toEqual(responseData);
            done();
        })
    });

    it('should be return entities without arg name', (done: DoneFn) => {
        const nextPageUrl = 'nextPageUrl'
        const responseData = [{ id: 'id3', name: 'name3' }, { id: 'id4', name: 'name4' }];
        const responseLink = [{ rel: 'NextPage', href: nextPageUrl }]
        const repsponse = <BaseResponseWithHateos<BaseWithNameModel[]>>{ status: 200, data: responseData, link: responseLink }

        dataServiceSpy.get.withArgs(testEntitiesUrl).and.returnValue(of(repsponse));
        mapperServiceSpy.mapBaseResponseWithHateoasToNextPageUrl.and.returnValue(nextPageUrl);
        service.setEntitiesUrl(testEntitiesUrl);

        service.getEntities().subscribe((res) => {
            expect(res).toEqual(responseData);
            done();
        })
    });

    it('should be return entities next page', (done: DoneFn) => {
        const nextPageUrl = 'nextPageUrl'
        const responseData = [{ id: 'id5', name: 'name5' }, { id: 'id6', name: 'name6' }];
        const responseLink = [{ rel: 'NextPage', href: nextPageUrl }]
        const repsponse = <BaseResponseWithHateos<BaseWithNameModel[]>>{ status: 200, data: responseData, link: responseLink }

        dataServiceSpy.get.withArgs(nextPageUrl).and.returnValue(of(repsponse));
        mapperServiceSpy.mapBaseResponseWithHateoasToNextPageUrl.and.returnValue(nextPageUrl);
        service.setEntitiesUrl(testEntitiesUrl);
        //@ts-ignore
        service.nextPageEntitiesUrl = nextPageUrl;

        service.getNextPageEntities().subscribe((res) => {
            expect(res).toEqual(responseData);
            done();
        })
    });

    it('should be return Localization', () => {
        expect(service.getLocalization()).toEqual(testLocalizationFile);
    })
})
