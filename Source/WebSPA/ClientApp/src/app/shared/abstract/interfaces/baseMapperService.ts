import { HttpParams } from "@angular/common/http";
import { FormGroup } from "@angular/forms";
import { BaseResponseWithHateos } from "../../models/baseResponseWithHateos.model";
import { BaseWithNameModel } from "../../models/baseWithName.model";
import { Sorting } from "../../models/sorting.model";

export interface BaseMapperService {
    mapFilterToHttpParams(filter: Sorting): HttpParams 
    mapFormToRequest(form: FormGroup): BaseWithNameModel
    mapBaseResponseWithHateoasToNextPageUrl(reponse: BaseResponseWithHateos<unknown>): string
}
