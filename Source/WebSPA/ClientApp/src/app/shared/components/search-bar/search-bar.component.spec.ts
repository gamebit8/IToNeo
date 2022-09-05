import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';
import { TEST_CONSTANTS } from '../../constants/testConstants';
import { SearchBarComponent } from './search-bar.component';

describe('SearchBarComponent', () => {
    let component: SearchBarComponent;
    let fixture: ComponentFixture<SearchBarComponent>;

    beforeEach(async () => {
        const csp = jasmine.createSpyObj('ConfigurationService', ['get'], { isReady: true, localization: TEST_CONSTANTS.localization });
        await TestBed.configureTestingModule({
            declarations: [
                SearchBarComponent
            ],
            providers: [
                ChangeDetectorRef,
                { provide: ConfigurationService, useValue: csp }
            ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(SearchBarComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

