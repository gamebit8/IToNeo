import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NavsFragmentComponent } from './navs-fragment.component';

describe('NavsFragmentComponent', () => {
    let component: NavsFragmentComponent;
    let fixture: ComponentFixture<NavsFragmentComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [
                NavsFragmentComponent
            ],
            providers: [
                ChangeDetectorRef
            ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(NavsFragmentComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

