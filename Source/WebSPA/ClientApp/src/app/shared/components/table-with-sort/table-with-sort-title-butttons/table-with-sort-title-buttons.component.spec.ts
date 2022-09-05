import { ChangeDetectorRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TableWithSortTitleButtonsComponent } from './table-with-sort-title-buttons.component';

describe('TableWithSortTitleButtonsComponent', () => {
    let component: TableWithSortTitleButtonsComponent;
    let fixture: ComponentFixture<TableWithSortTitleButtonsComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [
                TableWithSortTitleButtonsComponent,
            ],
            providers: [
                ChangeDetectorRef
            ]
        })
            .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(TableWithSortTitleButtonsComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

