import { HttpParams } from "@angular/common/http";
import { FormGroup } from "@angular/forms";
import { BaseResponseWithHateos } from "../../models/baseResponseWithHateos.model";
import { BaseWithNameModel } from "../../models/baseWithName.model";
import { Sorting } from "../../models/sorting.model";
import { BaseMapperService } from "../interfaces/baseMapperService";

export abstract class MapperService implements BaseMapperService {
    mapFilterToHttpParams(filter: Sorting): HttpParams { return }
    mapFormToRequest(form: FormGroup): BaseWithNameModel { return }
    mapBaseResponseWithHateoasToNextPageUrl(reponse: BaseResponseWithHateos<unknown>): string { return }
}
