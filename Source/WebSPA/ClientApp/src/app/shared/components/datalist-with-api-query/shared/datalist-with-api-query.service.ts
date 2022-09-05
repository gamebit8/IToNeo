import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { BaseResponseWithHateos } from '../../../models/baseResponseWithHateos.model';
import { BaseWithNameModel } from '../../../models/baseWithName.model';
import { DataService } from '../../../abstract/abstract-service/data.service'
import { MapperService } from '../../../abstract/abstract-service/mapper.service';
import { Localization } from '../../../models/localization.model';
import { ConfigurationService } from '../../../abstract/abstract-service/configuration.service';

@Injectable()
export class DatalistWithApiQueryService {
    private nextPageEntitiesUrl: string;
    private entitiesUrl: string;

    constructor(private dataService: DataService, private configService: ConfigurationService, private mapService: MapperService) { }

    public getLocalization(): Localization {
        return this.configService.localization;
    }

    public getEntities(name?: string): Observable<BaseWithNameModel[]>{
        if (name) {
            let params = new HttpParams().set('name', name)
            return this.dataService.get<BaseWithNameModel[]>(this.entitiesUrl, params).pipe(map(res => {
                return this.entitesRequestHandler(res)
            }))
        }

        return this.dataService.get(this.entitiesUrl).pipe<BaseWithNameModel[]>(map((res: any) => {
            return this.entitesRequestHandler(res);
        }))
    }

    public getNextPageEntities(): Observable<BaseWithNameModel[]> {
        if (this.nextPageEntitiesUrl) {
            return this.dataService.get(this.nextPageEntitiesUrl).pipe<any>(map((res: any) => {
                return this.entitesRequestHandler(res);
            }))
        }

        return;
    }

    public setEntitiesUrl(url: string):void {
        this.entitiesUrl = url;
    }

    protected entitesRequestHandler(res: BaseResponseWithHateos<BaseWithNameModel[]>): BaseWithNameModel[] {
        this.nextPageEntitiesUrl = this.mapService.mapBaseResponseWithHateoasToNextPageUrl(res);
        return res.data;
    }
}
