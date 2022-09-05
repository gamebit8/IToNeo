import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { error } from 'console';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { BaseDataService } from '../abstract/interfaces/baseDataService';
import { BaseResponse } from '../models/baseResponse.model';
import { BaseResponseWithHateos } from '../models/baseResponseWithHateos.model';
import { BodyHttpResponse } from '../models/bodyHttpResponse.model';
import { FileResponse } from '../models/fileResponse.model';

@Injectable()
export class RestDataService implements BaseDataService{
    private httpOptionsJson: HttpHeaders;
    private httpOptionDownloadFile: HttpHeaders;

    constructor(private http: HttpClient) {
        this.httpOptionsJson = this.getBaseHttpHeaders();
        this.httpOptionDownloadFile = this.getFileHttpHeader();
    }

    private getBaseHttpHeaders(): HttpHeaders {
        return new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8')
            .set('Access-Control-Allow-Origin', '*')
            .set('Access-Control-Allow-Methods', 'GET, POST, PATCH, PUT, DELETE, OPTIONS')
            .set('Access-Control-Allow-Headers', 'Origin, Content-Type, X-Auth-Token');
    }

    private getFileHttpHeader(): HttpHeaders {
        return new HttpHeaders().set('Accept', 'application/octet-stream');
    }

    get<TB>(url: string, params?: HttpParams): Observable<BaseResponseWithHateos<TB>> {
        return this.http.get(url, { headers: this.httpOptionsJson, params, observe: 'response' })
            .pipe(
                map((res: HttpResponse<BaseResponseWithHateos<TB>>) => {
                    const r = this.mapHttpResponseToBaseResponseWithHateos<TB>(res);
                    return r;
                })
            );
    }


    private mapHttpResponseToBaseResponseWithHateos<TB>(hr: HttpResponse<BodyHttpResponse<TB>>): BaseResponseWithHateos<TB> {
        return {
            status: hr.status,
            data: hr.body.data,
            link: hr.body.link
        }
    }

    getFile(url: string): Observable<BaseResponse<FileResponse>> {
        return this.http.get(url, { headers: this.httpOptionDownloadFile, observe: 'response', responseType: "blob" })
            .pipe(
                map((res: HttpResponse<Blob>) => {
                    const r = this.mapHttpResponseToBaseResponseFile(res);
                    return r;
                }),
            );
    }

    private mapHttpResponseToBaseResponseFile(hr: HttpResponse<Blob>): BaseResponse<FileResponse> {
        const fileName = hr.headers.get('content-disposition').split(';')[1].split('=')[1].replace(/\"/g, '');
        return {
            status: hr.status,
            data: { name: fileName, data: hr.body }
        }
    }

    post<TB>(url: string, data?: any, params?: any): Observable<BaseResponse<TB>> {

        return this.http.post(url, data, { params, observe: 'response' })
            .pipe(
                map((res: HttpResponse<TB>) => {
                    const r = this.mapHttpResponseToBaseResponse<TB>(res);
                    return r;
                }),
            );
    }

    private mapHttpResponseToBaseResponse<TB>(hr: HttpResponse<TB>): BaseResponse<TB> {
        return {
            status: hr.status,
            data: hr.body
        }
    }

    postFile<TB>(url: string, form: FormData): Observable<BaseResponse<TB>> {
        return this.http.post(url, form, { observe: 'response' })
            .pipe(
                map((res: HttpResponse<TB>) => {
                    const r = this.mapHttpResponseToBaseResponse<TB>(res);
                    return r;
                }),
            );
    }

    put<TB>(url: string, data?: any, params?: any): Observable<BaseResponse<TB>> {
        return this.http.put(url, data, { params, observe: 'response' })
            .pipe(
                map((res: HttpResponse<TB>) => {
                    const r = this.mapHttpResponseToBaseResponse<TB>(res);
                    return r;
                }),
            );
    }

    delete<TB>(url: string, params?: any): Observable<BaseResponse<TB>> {

        return this.http.delete(url, { params, observe: 'response' })
            .pipe(
                map((res: HttpResponse<TB>) => {
                    const r = this.mapHttpResponseToBaseResponse<TB>(res);
                    return r;
                }),
            );
    }
}
