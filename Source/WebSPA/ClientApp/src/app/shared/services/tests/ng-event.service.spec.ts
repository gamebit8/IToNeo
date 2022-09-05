import { TestBed } from '@angular/core/testing';
import { NgEventBus } from 'ng-event-bus';
import { NgEventBusService } from '../ng-event.service';

describe('NgEventBusService', () => {
    let service: NgEventBusService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                NgEventBusService,
                NgEventBus
            ],
        });
        service = TestBed.inject(NgEventBusService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should be return metadata after cast()', (done: DoneFn) => {
        const testEvent = { id: 'id', name: 'name' };
        const testEventKey = 'testKey';

        service.on(testEventKey).subscribe(meta => {
            expect(meta.data).toEqual(testEvent);
            done();
        });
        service.cast(testEventKey, testEvent);
    });
});
