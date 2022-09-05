import { NO_ERRORS_SCHEMA } from '@angular/compiler';
import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConfigurationService } from '../../../abstract/abstract-service/configuration.service';
import { DataService } from '../../../abstract/abstract-service/data.service';
import { MapperService } from '../../../abstract/abstract-service/mapper.service';
import { TEST_CONSTANTS } from '../../../constants/testConstants';
import { BaseInputWithLabelAndInvalidTooltip } from '../datalist-with-api-query/datalist-with-api-query.component.spec';
import { DatalistWithApiQueryService } from '../shared/datalist-with-api-query.service';
import { DatalistFormcontrolWithApiQueryComponent } from './datalist-formcontrol-with-api-query.component';

describe('DatalistWithApiQueryComponent', () => {
    let component: DatalistFormcontrolWithApiQueryComponent;
    let fixture: ComponentFixture<DatalistFormcontrolWithApiQueryComponent>;

    beforeEach(async () => {
        const dlss = jasmine.createSpyObj('DatalistWithApiQueryService', ['get']);
        const dss = jasmine.createSpyObj('DataService', ['get']);
        const csp = jasmine.createSpyObj('ConfigurationService', ['get'], { isReady: true, localization: TEST_CONSTANTS.localization });
        const mss = jasmine.createSpyObj('MapperService', ['mapBaseResponseWithHateoasToNextPageUrl']);
        await TestBed.configureTestingModule({
            declarations: [
                DatalistFormcontrolWithApiQueryComponent,
                BaseInputWithLabelAndInvalidTooltip
            ],
            providers: [
                ChangeDetectorRef,
                { provide: DatalistWithApiQueryService, useValue: dlss },
                { provide: ConfigurationService, useValue: csp },
                { provide: DataService, useValue: dss },
                { provide: MapperService, useValue: mss }
            ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(DatalistFormcontrolWithApiQueryComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

