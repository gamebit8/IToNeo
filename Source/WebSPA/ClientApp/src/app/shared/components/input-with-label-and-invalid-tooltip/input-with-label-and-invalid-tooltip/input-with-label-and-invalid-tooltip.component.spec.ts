import { ChangeDetectorRef, Component, EventEmitter, Input, Output } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InputWithLabelAndInvalidTooltipComponent } from './input-with-label-and-invalid-tooltip.component';

@Component({
    selector: 'base-input-with-label-and-invalid-tooltip ',
    template: `<div>Fake BaseInputWithLabelAndInvalidTooltip</div>`
})
export class BaseInputWithLabelAndInvalidTooltip {
    @Input() title: string;
    @Input() field: string;
    @Input() isRequired: boolean;
    @Output() clear = new EventEmitter<any>();
}

describe('InputWithLabelAndInvalidTooltipComponent', () => {
    let component: InputWithLabelAndInvalidTooltipComponent;
    let fixture: ComponentFixture<InputWithLabelAndInvalidTooltipComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
        declarations: [
            InputWithLabelAndInvalidTooltipComponent,
            BaseInputWithLabelAndInvalidTooltip
        ],
        providers: [
            ChangeDetectorRef
        ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(InputWithLabelAndInvalidTooltipComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

