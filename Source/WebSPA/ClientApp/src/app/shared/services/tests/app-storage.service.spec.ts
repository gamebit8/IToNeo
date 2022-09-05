import { TestBed } from '@angular/core/testing';
import { AppStorageService } from '../app-storage.service';

describe('AppStorageService', () => {
    let service: AppStorageService;
    let testObj = { id: 1, name: 'name' };
    let testKey = 'testKey';

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                AppStorageService
            ]
        });
        service = TestBed.inject(AppStorageService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should be return object after store', () => {
        service.store(testKey, testObj);
        expect(service.retrieve(testKey)).toEqual(testObj);
    });

    it('should be undefined after remove object', () => {
        service.store(testKey, testObj);
        service.remove(testKey);
        expect(service.retrieve(testKey)).toEqual(undefined);
    });
});
