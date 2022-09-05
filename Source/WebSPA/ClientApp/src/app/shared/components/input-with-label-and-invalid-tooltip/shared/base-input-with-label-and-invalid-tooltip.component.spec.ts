import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TEST_CONSTANTS } from '../../../constants/testConstants';
import { BaseInputWithLabelAndInvalidTooltipComponent } from './base-input-with-label-and-invalid-tooltip.component';

describe('BaseInputWithLabelAndInvalidTooltipComponent', () => {
    let component: BaseInputWithLabelAndInvalidTooltipComponent;
    let fixture: ComponentFixture<BaseInputWithLabelAndInvalidTooltipComponent>;

    beforeEach(async () => {
         await TestBed.configureTestingModule({
            declarations: [
                BaseInputWithLabelAndInvalidTooltipComponent,
            ],
            providers: [
                ChangeDetectorRef,
            ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(BaseInputWithLabelAndInvalidTooltipComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

