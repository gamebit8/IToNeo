import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams, HttpResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { ErrorInterceptor } from '../../http-interceptors/error-interceptor';
import { BaseResponse } from '../../models/baseResponse.model';
import { BaseResponseWithHateos } from '../../models/baseResponseWithHateos.model';
import { BaseWithNameModel } from '../../models/baseWithName.model';
import { RestDataService } from '../rest-data.service';

describe('RestDataService', () => {
    let service: RestDataService;
    let appHttpSpy: jasmine.SpyObj<HttpClient>;
    let baseHttpHeaders: HttpHeaders;
    let fileHttpHeaders: HttpHeaders;

    beforeEach(() => {
        const spyHttp = jasmine.createSpyObj('HttpCliet', ['get', 'put', 'delete', 'post'])
        TestBed.configureTestingModule({
            providers: [
                RestDataService,
                { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
                { provide: HttpClient, useValue: spyHttp },
            ]
        });
        service = TestBed.inject(RestDataService);
        appHttpSpy = TestBed.inject(HttpClient) as jasmine.SpyObj<HttpClient>;
        baseHttpHeaders = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8')
            .set('Access-Control-Allow-Origin', '*')
            .set('Access-Control-Allow-Methods', 'GET, POST, PATCH, PUT, DELETE, OPTIONS')
            .set('Access-Control-Allow-Headers', 'Origin, Content-Type, X-Auth-Token');
        fileHttpHeaders = new HttpHeaders().set('Accept', 'application/octet-stream');
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should be return baseHttpHeaders after call getBaseHttpHeaders()', () => {
        //@ts-ignore
        expect(service.getBaseHttpHeaders()).toEqual(baseHttpHeaders);
    });

    it('should be return fileHttpHeaders after call getFileHttpHeader()', () => {
        //@ts-ignore
        expect(service.getFileHttpHeader()).toEqual(fileHttpHeaders);
    });

    it('should be return BaseResponseWithHateos<BaseWithNameModel> after call get()', (done: DoneFn) => {
        const testGetUrl = 'testGetUrl';
        const testModel = <BaseWithNameModel>{ id: 'id', name: 'name' }
        const testAppResponse = <BaseResponseWithHateos<BaseWithNameModel>>{ status: 200, data: testModel, link: [{ rel: 'rel', href: 'href' }] }
        const testHttpParams = new HttpParams().set('name', 'name').set('id', 'id');
        const testResponse = new HttpResponse({ body: testAppResponse, status: 200, url: testGetUrl + testHttpParams.toString })

        //@ts-ignore
        appHttpSpy.get.withArgs(testGetUrl, { headers: baseHttpHeaders, params: testHttpParams, observe: 'response' }).and.returnValue(of(testResponse));

        service.get(testGetUrl, testHttpParams).subscribe(res => {
            expect(res).toEqual(testAppResponse);
            done();
        });
    });

    it('should be return file after call getFile()', (done: DoneFn) => {
        const testGetUrl = 'testGetUrl';
        const testFileName = 'test.txt';
        const testBlob = new Blob(['testBlob'], { type: 'text/plain' });
        const testAppHeaders = new HttpHeaders().append('content-disposition', `attachment; filename ="${testFileName}"`);
        const appResponse = { status: 200, data: { name: testFileName, data: testBlob } }
        const testResponse = new HttpResponse({ body: testBlob, status: 200, url: testGetUrl, headers: testAppHeaders })

        //@ts-ignore
        appHttpSpy.get.withArgs(testGetUrl, { headers: fileHttpHeaders, observe: 'response', responseType: 'blob' }).and.returnValue(of(testResponse));

        service.getFile(testGetUrl).subscribe(res => {
            expect(res).toEqual(appResponse);
            done();
        });
    });

    it('should be return created model after call post()', (done: DoneFn) => {
        const testGetUrl = 'testGetUrl';
        const testModel = <BaseWithNameModel>{ id: 'id', name: 'name' };
        const testAppResponse = <BaseResponse<BaseWithNameModel>>{ status: 201, data: testModel };
        const testHttpParams = new HttpParams();
        const testResponse = new HttpResponse({ body: testModel, status: 201, url: testGetUrl });

        //@ts-ignore
        appHttpSpy.post.withArgs(testGetUrl, testModel, { params: testHttpParams, observe: 'response' }).and.returnValue(of(testResponse));

        service.post(testGetUrl, testModel, testHttpParams).subscribe(res => {
            expect(res).toEqual(testAppResponse);
            done();
        });
    });

    it('should be return model after postFile()', (done: DoneFn) => {
        const testGetUrl = 'testGetUrl';
        const testFileName = 'test.txt';
        const testFormData = new FormData();
        testFormData.append(testFileName, 'testText');
        const testModel = <BaseWithNameModel>{ id: 'id', name: 'name' };
        const testAppResponse = <BaseResponse<BaseWithNameModel>>{ status: 201, data: testModel };
        const testResponse = new HttpResponse({ body: testModel, status: 201, url: testGetUrl });

        //@ts-ignore
        appHttpSpy.post.withArgs(testGetUrl, testFormData, { observe: 'response' }).and.returnValue(of(testResponse));

        service.postFile(testGetUrl, testFormData).subscribe(res => {
            expect(res).toEqual(testAppResponse);
            done();
        });
    });

    it('should be return model after call put()', (done: DoneFn) => {
        const testGetUrl = 'testGetUrl';
        const testModel = <BaseWithNameModel>{ id: 'id', name: 'name' };
        const testAppResponse = <BaseResponse<BaseWithNameModel>>{ status: 200, data: testModel };
        const testHttpParams = new HttpParams();
        const testResponse = new HttpResponse({ body: testModel, status: 200, url: testGetUrl });

        //@ts-ignore
        appHttpSpy.put.withArgs(testGetUrl, testModel, { params: testHttpParams, observe: 'response' }).and.returnValue(of(testResponse));

        service.put(testGetUrl, testModel, testHttpParams).subscribe(res => {
            expect(res).toEqual(testAppResponse);
            done();
        });
    });

    it('should be return delete code after call delete()', (done: DoneFn) => {
        const testGetUrl = 'testGetUrl';
        const testModel = <BaseWithNameModel>{ id: 'id', name: 'name' };
        const testAppResponse = <BaseResponse<BaseWithNameModel>>{ status: 204, data: testModel };
        const testHttpParams = new HttpParams();
        const testResponse = new HttpResponse({ body: testModel, status: 204, url: testGetUrl });

        //@ts-ignore
        appHttpSpy.delete.withArgs(testGetUrl, { params: testHttpParams, observe: 'response' }).and.returnValue(of(testResponse));

        service.delete(testGetUrl, testHttpParams).subscribe(res => {
            expect(res).toEqual(testAppResponse);
            done();
        });
    });
});
