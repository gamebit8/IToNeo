import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { APP_CONFIG, DI_CONFIG } from '../../../app.config';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';
import { DataService } from '../../abstract/abstract-service/data.service';
import { TEST_CONSTANTS } from '../../constants/testConstants';
import { FileComponent } from './file.component';
import { FileService } from './file.service';

describe('FileComponent', () => {
    let component: FileComponent;
    let fixture: ComponentFixture<FileComponent>;

    beforeEach(async () => {
        const fss = jasmine.createSpyObj('FileService', ['getLocalization']);
        const dss = jasmine.createSpyObj('DataService', ['get']);
        const csp = jasmine.createSpyObj('ConfigurationService', ['get'], { isReady: true, localization: TEST_CONSTANTS.localization });
        await TestBed.configureTestingModule({
            declarations: [
                FileComponent,
            ],
            providers: [
                ChangeDetectorRef,
                { provide: APP_CONFIG, useValue: DI_CONFIG },
                { provide: FileService, useValue: fss },
                { provide: ConfigurationService, useValue: csp },
                { provide: DataService, useValue: dss },
            ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(FileComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

