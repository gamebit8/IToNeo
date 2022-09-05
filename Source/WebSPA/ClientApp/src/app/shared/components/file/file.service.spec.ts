import { TestBed } from '@angular/core/testing';
import { APP_CONFIG, DI_CONFIG } from '../../../app.config';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';
import { DataService } from '../../abstract/abstract-service/data.service';
import { TEST_CONSTANTS } from '../../constants/testConstants';
import { FileService } from './file.service';

describe('FileService', () => {
    let service: FileService;

    beforeEach(() => {
        const csp = jasmine.createSpyObj('ConfigurationService', [], { urls: TEST_CONSTANTS.urls });
        const dss = jasmine.createSpyObj('DataService', ['get']);

        TestBed.configureTestingModule({
            providers: [
                FileService,
                { provide: ConfigurationService, useValue: csp },
                { provide: DataService, useValue: dss },
                { provide: APP_CONFIG, useValue: DI_CONFIG },
            ]
        });
        service = TestBed.inject(FileService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
})
