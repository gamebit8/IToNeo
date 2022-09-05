import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseResponse } from '../../models/baseResponse.model';
import { BaseResponseWithHateos } from '../../models/baseResponseWithHateos.model';
import { FileResponse } from '../../models/fileResponse.model';
import { BaseDataService } from '../interfaces/baseDataService';

export abstract class DataService implements BaseDataService{


    get<TB>(url: string, params?: HttpParams): Observable<BaseResponseWithHateos<TB>> {
        return;
    }

    getFile(url: string): Observable<BaseResponse<FileResponse>> {
        return;
    }

    post<TB>(url: string, data?: any, params?: any): Observable<BaseResponse<TB>> {
        return;
    }

    postFile<TB>(url: string, form: FormData): Observable<BaseResponse<TB>> {
        return;
    }

    put<TB>(url: string, data?: any, params?: any): Observable<BaseResponse<TB>> {
        return;
    }

    delete<TB>(url: string, params?: any): Observable<BaseResponse<TB>> {
        return;
    }
}
