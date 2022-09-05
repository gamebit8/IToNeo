import { TestBed } from '@angular/core/testing';
import { UrlHelper } from './urlHelper';

describe('UrlHelper', () => {
    let helper: UrlHelper;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                UrlHelper
            ]
        });
        helper = TestBed.inject(UrlHelper);
    });

    it('should be created', () => {
        expect(helper).toBeTruthy();
    });

    it('should be return request url', () => {
        const baseUrl = 'testBaseUrl';
        const testEntityId = 'testEntityId';
        const testRequestUrl = baseUrl + '/' + testEntityId;

        expect(helper.RequestUrl(baseUrl, testEntityId)).toContain(testRequestUrl);
    });
});
