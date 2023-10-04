import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MetaData } from 'ng-event-bus/lib/meta-data';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { OperationComponentSettings } from '../../../components/operations-menu/operationsMenuSettings.model';
import { ResponseStatus } from '../../../enums/responseStatus';
import { UrlHelper } from '../../../helpers/urlHelper';
import { BaseResponse } from '../../../models/baseResponse.model';
import { BaseResponseWithHateos } from '../../../models/baseResponseWithHateos.model';
import { BaseWithNameModel } from '../../../models/baseWithName.model';
import { Hateoas } from '../../../models/hateoas.model';
import { Localization } from '../../../models/localization.model';
import { Sorting } from '../../../models/sorting.model';
import { UrlsConfiguration } from '../../../models/urlsConfiguration.model';
import { ConfigurationService } from '../../abstract-service/configuration.service';
import { DataService } from '../../abstract-service/data.service';
import { castKey, EventBusService } from '../../abstract-service/event-bus.service';
import { MapperService } from '../../abstract-service/mapper.service';
import { StorageService } from '../../abstract-service/storage.service';

@Injectable()
export class EntitiesBaseService<TEE, TF extends Sorting, TReq extends BaseWithNameModel, TRes extends BaseResponse<TEE[]>> {
    protected entitiesUrl: string;
    protected nextPageEntitiesUrl: string;
    protected urlHelper: UrlHelper = new UrlHelper();

    constructor(
        protected dataService: DataService,
        protected configurationService: ConfigurationService,
        protected eventBusService: EventBusService,
        protected storageService: StorageService,
        protected mapperService: MapperService
    ) {

    }

    public getLocalization(): Localization {
        return this.configurationService.localization;
    }

    public getUrls(): UrlsConfiguration {
        return this.configurationService.urls;
    }

    public getEntity(id: number | string): Observable<BaseResponse<TEE>> {
        return this.doGet<TEE>(this.entitiesUrl, id)
    }

    protected doGet<T>(baseUrl: string, id: number | string): Observable<BaseResponse<T>> {
        const url = this.urlHelper.RequestUrl(baseUrl, id);
        return this.dataService.get<T>(url).pipe(map(res => { return { status: res.status, data: res.data } }));
    }

    public getEntities(filter: TF): Observable<BaseResponse<TEE[]>> {
        const params = this.mapperService.mapFilterToHttpParams(filter);

        return this.dataService.get<TEE[]>(this.entitiesUrl, params).pipe(map(res => {
            return this.entitesResponseHandler(res);
        }));
    }

    private entitesResponseHandler(res: BaseResponseWithHateos<TEE[]>): BaseResponse<TEE[]> {
        this.nextPageEntitiesUrl = this.mapperService.mapBaseResponseWithHateoasToNextPageUrl(res);
        return { status: res.status, data: res.data };
    }

    public getNextPageEntities(): Observable<BaseResponse<TEE[]>> {
        if (this.nextPageEntitiesUrl) {
            return this.dataService.get<TEE[]>(this.nextPageEntitiesUrl).pipe(map(res => {
                return this.entitesResponseHandler(res);
            }));
        }
    }

    public addOrEditEntity(form: FormGroup): Observable<BaseResponse<any>> {
        const req = this.mapperService.mapFormToRequest(form);

        if (req.id)
            return this.doPut(this.entitiesUrl, req.id, req);

        return this.doPost(this.entitiesUrl, req);
    }

    protected doPut(baseUrl: string, id: number | string, req: any): Observable<BaseResponse<any>> {
        const url = this.urlHelper.RequestUrl(baseUrl, id);
        return this.dataService.put<any>(url, req).pipe<any>(tap(res => { return res }));
    }

    protected doPost(baseUrl: string, req: any): Observable<BaseResponse<any>> {
        return this.dataService
            .post<any>(baseUrl, req)
            .pipe<any>(map(res => {
                if (res.status == ResponseStatus.Created) {
                    const createdEntityId = this.getCreatedEntityIdFromHateoas(res.data);
                    return { status: ResponseStatus.Created, data: createdEntityId };
                }
                return res;
            }));
    }

    private getCreatedEntityIdFromHateoas(ih: Hateoas): number | string {
        const href = ih.href;
        const tempArray = href.split('/');
        const createdEntityId = tempArray[tempArray.length - 1];
        return createdEntityId;
    }


    public deleteEntity(id: number | string): Observable<BaseResponse<any>> {
        return this.doDelete(this.entitiesUrl, id);
    }

    protected doDelete(baseUrl: string, id: number | string): Observable<BaseResponse<any>> {
        const url = this.urlHelper.RequestUrl(baseUrl, id);

        return this.dataService.delete<any>(url).pipe<any>(tap(res => { return res }));
    }

    public saveEntityTableColomnsSettings(componentRoute: string, colomns: string[]): void {
        if(componentRoute)
            this.storageService.store(componentRoute, colomns);
    }

    public loadEntityTableColomnsSettings(componentRoute: string): string[] {
        return this.storageService.retrieve(componentRoute);
    }

    public operationComponentEvents(): Observable<MetaData> {
        return this.eventBusService.on(castKey.operationComponentEvents).pipe(meta => {
            return meta as Observable<MetaData>;
        });
    }

    public setOperationComponentConfiguration(settings: OperationComponentSettings): void {
        this.eventBusService.cast(castKey.operationСomponentConfiguration, settings)
    }
}
