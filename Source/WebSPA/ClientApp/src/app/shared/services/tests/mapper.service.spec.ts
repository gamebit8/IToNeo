import { HttpParams } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { FormControl, FormGroup } from '@angular/forms';
import { BaseResponseWithHateos } from '../../models/baseResponseWithHateos.model';
import { BaseWithNameModel } from '../../models/baseWithName.model';
import { Sorting } from '../../models/sorting.model';
import { AppMapperService } from '../mapper.service';

describe('AppMapperService', () => {
    let service: AppMapperService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                AppMapperService
            ]
        });
        service = TestBed.inject(AppMapperService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should be return HttpParams after call mapFilterToHttpParams()', () => {
        const filter = <Sorting>{ sortBy: 'sortBy', sortDescending: 'true', name: 'name' };
        const httpParams = new HttpParams().append('sortBy', 'sortBy').append('sortDescending', 'true').append('name', 'name')

        expect(service.mapFilterToHttpParams(filter)).toEqual(httpParams);
    });

    it('should be return Request after mapFormToRequest()', () => {
        const form = new FormGroup({
            id: new FormControl('id'),
            name: new FormControl('name'),
            count: new FormControl('count')
        });
        const request = <BaseWithNameModel>{
            id: 'id',
            name: 'name',
            count: 'count'
        };

        expect(service.mapFormToRequest(form)).toEqual(request)
    });

    it('should be return NextPage after mapBaseResponseWithHateoasToNextPageUrl()', () => {
        const testNextPageUrl = 'testNextPageUrl';
        const testResponse = <BaseResponseWithHateos<unknown>>{
            status: 200,
            data: 'testData',
            link: [{ rel: 'NextPage', href: testNextPageUrl }]
        };

        expect(service.mapBaseResponseWithHateoasToNextPageUrl(testResponse)).toContain(testNextPageUrl);
    })
});
