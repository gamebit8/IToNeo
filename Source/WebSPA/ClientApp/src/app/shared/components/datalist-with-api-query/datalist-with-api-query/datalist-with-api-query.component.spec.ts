import { ChangeDetectorRef, Component, EventEmitter, Input, Output } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConfigurationService } from '../../../abstract/abstract-service/configuration.service';
import { DataService } from '../../../abstract/abstract-service/data.service';
import { MapperService } from '../../../abstract/abstract-service/mapper.service';
import { TEST_CONSTANTS } from '../../../constants/testConstants';
import { DatalistWithApiQueryService } from '../shared/datalist-with-api-query.service';
import { DatalistWithApiQueryComponent } from './datalist-with-api-query.component';

@Component({
    selector: 'base-input-with-label-and-invalid-tooltip ',
    template: `<div>Fake BaseInputWithLabelAndInvalidTooltip</div>`
})
export class BaseInputWithLabelAndInvalidTooltip  {
    @Input() title: string;
    @Input() field: string;
    @Input() isRequired: boolean;
    @Output() clear = new EventEmitter<any>();
}

describe('DatalistWithApiQueryComponent', () => {
    let component: DatalistWithApiQueryComponent;
    let fixture: ComponentFixture<DatalistWithApiQueryComponent>;

    beforeEach(async () => {
        const dlss = jasmine.createSpyObj('DatalistWithApiQueryService', ['get']);
        const dss = jasmine.createSpyObj('DataService', ['get']);
        const csp = jasmine.createSpyObj('ConfigurationService', ['get'], { isReady: true, localization: TEST_CONSTANTS.localization });
        const mss = jasmine.createSpyObj('MapperService', ['mapBaseResponseWithHateoasToNextPageUrl']);
        await TestBed.configureTestingModule({
            declarations: [
                DatalistWithApiQueryComponent,
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
        fixture = TestBed.createComponent(DatalistWithApiQueryComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

