import { BaseResponse } from "./baseResponse.model";
import { Hateoas } from "./hateoas.model";

export interface BaseResponseWithHateos<TD> extends BaseResponse<TD> {
    link: Hateoas[]
}
