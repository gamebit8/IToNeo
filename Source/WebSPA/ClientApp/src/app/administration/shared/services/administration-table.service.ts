import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { DataService } from '../../../shared/abstract/abstract-service/data.service';
import { MapperService } from '../../../shared/abstract/abstract-service/mapper.service';
import { UrlHelper } from '../../../shared/helpers/urlHelper';
import { BaseResponse } from '../../../shared/models/baseResponse.model';
import { BaseResponseWithHateos } from '../../../shared/models/baseResponseWithHateos.model';
import { Localization } from '../../../shared/models/localization.model';
import { Sorting } from '../../../shared/models/sorting.model';

@Injectable()
export class AdministrationTableService<TE> {
    private nextPageUrl: string;
    private urlHelper = new UrlHelper();

    constructor(private dataService: DataService, private mapperService: MapperService, private localization: Localization, private baseUrl: string) { }

    getLocalization(): Localization {
        return this.localization;
    }

    getEntities(sorting?: Sorting): Observable<BaseResponse<TE[]>> {
        if (sorting) {
            const params = this.mapperService.mapFilterToHttpParams(sorting);

            return this.dataService.get<TE[]>(this.baseUrl, params).pipe(map(res => {
                return this.baseResponseWithHateosHandler(res);
            }));
        }

        return this.dataService.get<TE[]>(this.baseUrl).pipe(map(res => {
            return this.baseResponseWithHateosHandler(res);
        }));
    }

    getNextPageEntities(): Observable<BaseResponse<TE[]>> {
        if (this.nextPageUrl) {
            return this.dataService.get<TE[]>(this.nextPageUrl).pipe(map(res => {
                return this.baseResponseWithHateosHandler(res);
            }));
        }

        return;
    }


    deleteEntity(id: string | number): Observable<BaseResponse<any>> {
        const url = this.urlHelper.RequestUrl(this.baseUrl, id);

        return this.dataService.delete(url);
    }

    private baseResponseWithHateosHandler(responseWithHateos: BaseResponseWithHateos<any>): BaseResponse<any> {
        this.nextPageUrl = this.mapperService.mapBaseResponseWithHateoasToNextPageUrl(responseWithHateos);
        return { data: responseWithHateos.data, status: responseWithHateos.status }
    }
}
