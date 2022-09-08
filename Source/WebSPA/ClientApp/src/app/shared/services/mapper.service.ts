import { HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { ConfigurationService } from "../abstract/abstract-service/configuration.service";
import { BaseMapperService } from "../abstract/interfaces/baseMapperService";
import { BaseResponseWithHateos } from "../models/baseResponseWithHateos.model";
import { BaseWithNameModel } from "../models/baseWithName.model";
import { Sorting } from "../models/sorting.model";

@Injectable()
export class AppMapperService implements BaseMapperService {
    constructor(private configurationService: ConfigurationService) { }

    mapFilterToHttpParams(filter: Sorting): HttpParams {
        let params = new HttpParams();

        Object.keys(filter).forEach(key => {
            if (filter[key])
                params = params.append(key, filter[key]);
        });

        return params;
    }

    mapFormToRequest(form: FormGroup): BaseWithNameModel {
        let req = <BaseWithNameModel>{};

        Object.keys(form.value).forEach(x => {
            req[x] = form.controls[x].value;
        })

        return req;
    }

    mapBaseResponseWithHateoasToNextPageUrl(response: BaseResponseWithHateos<unknown>): string {
        return this.configurationService.apiHost + response.link?.find(x => x.rel == 'NextPage')?.href;
    }
}
