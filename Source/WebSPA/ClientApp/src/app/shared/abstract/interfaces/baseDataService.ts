import { HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { BaseResponse } from "../../models/baseResponse.model";
import { BaseResponseWithHateos } from "../../models/baseResponseWithHateos.model";
import { FileResponse } from "../../models/fileResponse.model";

export interface BaseDataService {
    get<TB>(url: string, params?: HttpParams): Observable<BaseResponseWithHateos<TB>>
    getFile(url: string): Observable<BaseResponse<FileResponse>>
    post<TB>(url: string, data?: any, params?: any): Observable<BaseResponse<TB>>
    postFile<TB>(url: string, form: FormData): Observable<BaseResponse<TB>>
    put<TB>(url: string, data?: any, params?: any): Observable<BaseResponse<TB>>
    delete<TB>(url: string, params?: any): Observable<BaseResponse<TB>>
}
