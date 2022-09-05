import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';
import { TEST_CONSTANTS } from '../../constants/testConstants';
import { OperationsMenuComponent } from './operations-menu.component';

describe('OperationsMenuComponent', () => {
    let component: OperationsMenuComponent;
    let fixture: ComponentFixture<OperationsMenuComponent>;

    beforeEach(async () => {
        const csp = jasmine.createSpyObj('ConfigurationService', [ ], { isReady: true, localization: TEST_CONSTANTS.localization });
        await TestBed.configureTestingModule({
            declarations: [
                OperationsMenuComponent
            ],
            providers: [
                ChangeDetectorRef,
                { provide: ConfigurationService, useValue: csp }
            ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(OperationsMenuComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

