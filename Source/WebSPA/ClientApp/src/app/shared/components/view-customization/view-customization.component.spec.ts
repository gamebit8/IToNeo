import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';
import { TEST_CONSTANTS } from '../../constants/testConstants';
import { ViewCustomizationComponent } from './view-customization.component';

describe('ViewCustomizationComponent', () => {
    let component: ViewCustomizationComponent;
    let fixture: ComponentFixture<ViewCustomizationComponent>;

    beforeEach(async () => {
        const csp = jasmine.createSpyObj('ConfigurationService', [], { isReady: true, localization: TEST_CONSTANTS.localization });
        await TestBed.configureTestingModule({
            declarations: [
                ViewCustomizationComponent
            ],
            providers: [
                ChangeDetectorRef,
                { provide: ConfigurationService, useValue: csp }
            ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(ViewCustomizationComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

