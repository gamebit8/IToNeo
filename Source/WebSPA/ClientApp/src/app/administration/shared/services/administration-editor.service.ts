import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { DataService } from '../../../shared/abstract/abstract-service/data.service';
import { UrlHelper } from '../../../shared/helpers/urlHelper';
import { BaseModel } from '../../../shared/models/base.model';
import { BaseResponse } from '../../../shared/models/baseResponse.model';
import { Localization } from '../../../shared/models/localization.model';

@Injectable()
export class AdministrationEditorService<TE> {
    private urlHelper = new UrlHelper();

    constructor(private dataService: DataService, private localization: Localization, private baseUrl: string) { }

    getLocalization(): Localization {
        return this.localization;
    }

    getEntityById(id: string | number): Observable<BaseResponse<TE>> {
        const url:string = this.urlHelper.RequestUrl(this.baseUrl, id);

        return this.dataService.get<TE>(url).pipe(map(res => {
            return { status: res.status, data: res.data };
        }));
    }

    updateEntity(id: string | number, entity: BaseModel): Observable<BaseResponse<any>>  {
        const url = this.urlHelper.RequestUrl(this.baseUrl, id);

        return this.dataService.put(url, entity);
    }

    addEntity(entity: BaseModel): Observable<BaseResponse<any>> {
        return this.dataService.post(this.baseUrl, entity);
    }
}
