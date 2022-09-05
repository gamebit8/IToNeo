import { ChangeDetectorRef, NO_ERRORS_SCHEMA, SimpleChange } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConfigurationService } from '../../../abstract/abstract-service/configuration.service';
import { Localization } from '../../../models/localization.model';
import { LabelWithInvalidTooltipComponent } from './label-with-invalid-tooltip.component';

describe('LabelCustomComponent', () => {
    let component: LabelWithInvalidTooltipComponent;
    let fixture: ComponentFixture<LabelWithInvalidTooltipComponent>;
    let configurationServiceSpy: jasmine.SpyObj<ConfigurationService>;
    let cdRef: ChangeDetectorRef;
    let localization: Localization;

    beforeEach(async () => {
        localization = <Localization>{ fieldNotFilled: 'Не заполнено поле' };
        const confSerSpy = jasmine.createSpyObj('ConfigurationService', [], { localization: localization });
        await TestBed.configureTestingModule({
            declarations: [LabelWithInvalidTooltipComponent],
            providers: [{
                provide: ConfigurationService, useValue: confSerSpy
            }],           
            schemas: [NO_ERRORS_SCHEMA],
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(LabelWithInvalidTooltipComponent);
        configurationServiceSpy = TestBed.inject(ConfigurationService) as jasmine.SpyObj<ConfigurationService>;
        component = fixture.componentInstance;
        cdRef = fixture.componentRef.injector.get(ChangeDetectorRef)
        cdRef.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should be textContent == fieldNotFilled + title', () => {
        component.field = 'testField';
        component.title = 'testTitle';
        const testToolpit = localization.fieldNotFilled + ' ' + component.title;

        component.ngOnChanges({
            field: new SimpleChange(null, component.field, true),
            title: new SimpleChange(null, component.title, true)
        });
        cdRef.detectChanges();
        const textContent = fixture.nativeElement.querySelector('.invalid-tooltip').textContent;

        expect(textContent).toContain(testToolpit);
    });
});
