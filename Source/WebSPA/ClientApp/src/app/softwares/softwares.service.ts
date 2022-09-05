import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { EntitiesBaseService } from '../shared/abstract/abstract-modules/entities-base/entities-base.service';
import { ConfigurationService } from '../shared/abstract/abstract-service/configuration.service';
import { DataService } from '../shared/abstract/abstract-service/data.service';
import { EventBusService } from '../shared/abstract/abstract-service/event-bus.service';
import { MapperService } from '../shared/abstract/abstract-service/mapper.service';
import { StorageService } from '../shared/abstract/abstract-service/storage.service';
import { BaseResponse } from '../shared/models/baseResponse.model';
import { Sorting } from '../shared/models/sorting.model';
import { Software } from './shared/software.model';
import { SoftwareRequest } from './shared/softwareRequest.model';
import { SoftwareResponse } from './shared/softwareResponse.model';
import { SoftwareEquipments } from './shared/softwaresEquipments.model';
import { SoftwaresEquipmentsDeleteOrAdd } from './shared/softwaresEquipmentsDeleteOrAdd.model';
import { SoftwaresFilter } from './shared/softwaresFilter.model';
import { SoftwaresResoponse } from './shared/softwaresResponse.model';

@Injectable()
export class SoftwaresService extends EntitiesBaseService<Software, SoftwaresFilter, SoftwareRequest, SoftwaresResoponse> {
    private equipmentsUrl: string;
    private nextPageEquipmentsUrl: string;
    private softwaresEquipmentsUrl: string;

    constructor(
        protected dataService: DataService,
        protected configurationService: ConfigurationService,
        protected eventBusService: EventBusService,
        protected storageService: StorageService,
        protected mapperService: MapperService
    ) {
        super(dataService, configurationService, eventBusService, storageService, mapperService)
        this.entitiesUrl = this.configurationService.urls.softwareLicensesUrl;
        this.equipmentsUrl = this.configurationService.urls.equipmentsUrl;
        this.softwaresEquipmentsUrl = this.configurationService.urls.equipmentsSoftwareLicensesUrl
    }

    getEquipments(sorting?: Sorting): Observable<BaseResponse<SoftwareEquipments[]>> {
        if (sorting) {
            const params = this.mapperService.mapFilterToHttpParams(sorting);

            return this.dataService.get<SoftwareEquipments[]>(this.equipmentsUrl, params).pipe(map(res => {
                this.nextPageEquipmentsUrl = this.mapperService.mapBaseResponseWithHateoasToNextPageUrl(res);;
                return { status: res.status, data: res.data };
            }));
        }

        return this.dataService.get<SoftwareEquipments[]>(this.equipmentsUrl).pipe(map(res => {
            this.nextPageEquipmentsUrl = this.mapperService.mapBaseResponseWithHateoasToNextPageUrl(res);;
            return { status: res.status, data: res.data };
        }));
 
    }

    getNextPageEquipments(): Observable<BaseResponse<SoftwareEquipments[]>> {
        if (this.nextPageEquipmentsUrl) {
            return this.dataService.get<SoftwareEquipments[]>(this.nextPageEquipmentsUrl).pipe(map(res => {
                this.nextPageEquipmentsUrl = this.mapperService.mapBaseResponseWithHateoasToNextPageUrl(res);;
                return { status: res.status, data: res.data };
            }));
        }
    }

    getEntity(id: number | string): Observable<BaseResponse<SoftwareResponse>> {
        const url = this.urlHelper.RequestUrl(this.entitiesUrl, id);

        return this.dataService.get<SoftwareResponse>(url).pipe(map(res => {
            return { status: res.status, data: res.data };
        }));
    }

    deleteEquipmentsSoftwareLicenses(se: SoftwaresEquipmentsDeleteOrAdd): Observable<BaseResponse<any>> {
        const params = new HttpParams().append('equipmentId', String(se.equipmentId)).append('softwareLicenseId', String(se.softwareLicenceId))

        return this.dataService.delete(this.softwaresEquipmentsUrl, params);
    }

    addEquipmentsSoftwareLicenses(se: SoftwaresEquipmentsDeleteOrAdd): Observable<BaseResponse<any>> {
        return this.dataService.post(this.softwaresEquipmentsUrl, se);
    }
}
