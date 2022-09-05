import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
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
import { DisposalResponse } from './shared/disposalResponse.model';
import { Equipment } from './shared/equipment.model';
import { EquipmentRequest } from './shared/equipmentRequest.model';
import { EquipmentResponse } from './shared/equipmentResponse.model';
import { EquipmentsFilter } from './shared/equipmentsFilter.model';
import { EquipmentsResponse } from './shared/equipmentsResponse.model';
import { EquipmentsSoftwareLicenses } from './shared/equipmentsSoftwareLicenses.model';
import { EquipmentsSoftwareLicensesDeleteOrAdd } from './shared/equipmentsSoftwareLicensesDeleteOrAdd.model';
import { WriteOffResponse } from './shared/writeOffResponse.model';

@Injectable()
export class EquipmentsService extends EntitiesBaseService<Equipment, EquipmentsFilter, EquipmentRequest, EquipmentsResponse> {
    private writeOffsUrl: string = '';
    private disposalsUrl: string = '';
    private equipmentsSoftwareLicensesUrl: string = '';
    private softwareLicensesUrl: string = '';
    private nextPageSoftwareLicensesUrl: string = '';

    constructor(
        protected dataService: DataService,
        protected configurationService: ConfigurationService,
        protected eventBusService: EventBusService,
        protected router: Router,
        protected storageService: StorageService,
        protected mapperService: MapperService
    ) {
        super(dataService, configurationService, eventBusService, storageService, mapperService)
        this.entitiesUrl = this.configurationService.urls.equipmentsUrl;
        this.writeOffsUrl = this.configurationService.urls.writeOffsUrl;
        this.disposalsUrl = this.configurationService.urls.disposalsUrl;
        this.equipmentsSoftwareLicensesUrl = this.configurationService.urls.equipmentsSoftwareLicensesUrl;
        this.softwareLicensesUrl = this.configurationService.urls.softwareLicensesUrl;
    }

    public getEntity(id: number | string): Observable<BaseResponse<EquipmentResponse>> {
        return this.dataService.get<EquipmentResponse>(this.entitiesUrl + `/${id}`).pipe(map(res => {
            return { status: res.status, data: res.data };
        }));
    }

    public getWriteOff(id: number): Observable<BaseResponse<WriteOffResponse>> {
        return this.doGet<WriteOffResponse>(this.writeOffsUrl, id);
    }

    public addOrEditWriteOff(form: FormGroup): Observable<BaseResponse<any>> {
        const req = this.mapperService.mapFormToRequest(form);

        if (req.id) 
            return this.doPut(this.writeOffsUrl, req.id, req);

        return this.doPost(this.writeOffsUrl, req);
    }

    public deleteWriteOff(id: number): Observable<BaseResponse<any>> {
        return this.doDelete(this.writeOffsUrl, id);
    }

    public getDisposal(id: number): Observable<BaseResponse<DisposalResponse>> {
        return this.doGet<DisposalResponse>(this.disposalsUrl, id);
    }

    public addOrEditDisposal(form: FormGroup): Observable<BaseResponse<any>> {
        const req = this.mapperService.mapFormToRequest(form);

        if (req.id)
            return this.doPut(this.disposalsUrl, req.id, req);

        return this.doPost(this.disposalsUrl, req);
    }

    public deleteDisposal(id: number): Observable<BaseResponse<any>> {
        return this.doDelete(this.disposalsUrl, id);
    }

    public getSoftwareLicenses(sorting?: Sorting): Observable<BaseResponse<EquipmentsSoftwareLicenses[]>> {
        if (sorting) {
            const params = this.mapperService.mapFilterToHttpParams(sorting);

            return this.dataService.get<EquipmentsSoftwareLicenses[]>(this.softwareLicensesUrl, params).pipe(map(res => {
                this.nextPageSoftwareLicensesUrl = this.mapperService.mapBaseResponseWithHateoasToNextPageUrl(res);;
                return { status: res.status, data: res.data };
            }));
        } else {
            return this.dataService.get<EquipmentsSoftwareLicenses[]>(this.softwareLicensesUrl).pipe(map(res => {
                this.nextPageSoftwareLicensesUrl = this.mapperService.mapBaseResponseWithHateoasToNextPageUrl(res);
                return { status: res.status, data: res.data };
            }));
        }
    }

    public getNextPageSoftwareLicenses(): Observable<BaseResponse<EquipmentsSoftwareLicenses[]>> {
        if (this.nextPageSoftwareLicensesUrl) {
            return this.dataService.get<EquipmentsSoftwareLicenses[]>(this.nextPageSoftwareLicensesUrl).pipe(map(res => {
                this.nextPageSoftwareLicensesUrl = this.mapperService.mapBaseResponseWithHateoasToNextPageUrl(res);;
                return { status: res.status, data: res.data };
            }));
        }
    }

    public deleteEquipmentsSoftwareLicenses(esl: EquipmentsSoftwareLicensesDeleteOrAdd): Observable<BaseResponse<any>> {
        const params = new HttpParams().append('equipmentId', String(esl.equipmentId)).append('softwareLicense', String(esl.softwareLicenceId))

        return this.dataService.delete(this.equipmentsSoftwareLicensesUrl, params);
    }

    public addEquipmentsSoftwareLicenses(esl: EquipmentsSoftwareLicensesDeleteOrAdd) {
        return this.dataService.post(this.equipmentsSoftwareLicensesUrl, esl);
    }
}
