import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LabelCustomComponent } from './label-custom.component';

describe('LabelCustomComponent', () => {
    let component: LabelCustomComponent;
    let fixture: ComponentFixture<LabelCustomComponent>;
    let cdRef: ChangeDetectorRef;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [LabelCustomComponent],
            providers: [ChangeDetectorRef]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(LabelCustomComponent);
        component = fixture.componentInstance;
        cdRef = fixture.componentRef.injector.get(ChangeDetectorRef)
        cdRef.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should be span textContent == title', () => {
        component.title = 'testTitle';

        cdRef.detectChanges();
        const textContent = fixture.nativeElement.querySelector('span').textContent;

        expect(textContent).toContain(component.title);
    });

    it('should be * if is isRequired == true', () => {
        component.isRequired = true;

        cdRef.detectChanges();
        const textContent = fixture.nativeElement.querySelector('.text-danger').textContent;

        expect(textContent).toContain('*');
    });

    it('should be htmlFor == testField', () => {
        component.field = 'testField';

        cdRef.detectChanges();
        const htmlFor = fixture.nativeElement.querySelector('label').htmlFor;

        expect(component.field).toContain(htmlFor);
    });
});

