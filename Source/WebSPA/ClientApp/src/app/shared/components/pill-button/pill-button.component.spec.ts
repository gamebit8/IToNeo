import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';
import { TEST_CONSTANTS } from '../../constants/testConstants';
import { PillButtonComponent } from './pill-button.component';

describe('PillButtonComponent', () => {
    let component: PillButtonComponent;
    let fixture: ComponentFixture<PillButtonComponent>;

    beforeEach(async () => {
        const csp = jasmine.createSpyObj('ConfigurationService', [], { isReady: true, localization: TEST_CONSTANTS.localization });
        await TestBed.configureTestingModule({
            declarations: [
                PillButtonComponent
            ],
            providers: [
                ChangeDetectorRef,
                { provide: ConfigurationService, useValue: csp }
            ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(PillButtonComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

