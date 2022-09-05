import { ChangeDetectorRef, Component, EventEmitter, Input, Output } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BaseInputWithLabelAndInvalidTooltip } from '../input-with-label-and-invalid-tooltip/input-with-label-and-invalid-tooltip.component.spec';
import { InputFormcontrolWithLabelAndInvalidTooltipComponent } from './input-formcontrol-with-label-and-invalid-tooltip.component';

describe('InputFormcontrolWithLabelAndInvalidTooltipComponent', () => {
    let component: InputFormcontrolWithLabelAndInvalidTooltipComponent;
    let fixture: ComponentFixture<InputFormcontrolWithLabelAndInvalidTooltipComponent>;

    beforeEach(async () => {
         await TestBed.configureTestingModule({
            declarations: [
                InputFormcontrolWithLabelAndInvalidTooltipComponent,
                BaseInputWithLabelAndInvalidTooltip
            ],
            providers: [
                ChangeDetectorRef
            ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(InputFormcontrolWithLabelAndInvalidTooltipComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

