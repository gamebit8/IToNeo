//import { CommonModule } from '@angular/common';
//import { ChangeDetectorRef, Component, Input } from '@angular/core';
//import { ComponentFixture, TestBed } from '@angular/core/testing';
//import { FormsModule } from '@angular/forms';
//import { By } from '@angular/platform-browser';
//import { inputType } from '../../enums/inputType';
//import { InputModel } from '../../models/input.model';
//import { CheckboxGroupComponent } from './checkbox-group.component';

//@Component({
//    selector: 'label-with-invalid-tooltip',
//    template: `<div>Fake LabelWithInvalidTooltipComponent</div>`
//})
//export class FakeLabelWithInvalidTooltipComponent {
//    @Input() title: string;
//    @Input() field: string;
//    @Input() isRequired: boolean;
//}

//describe('CheckboxGroupComponent', () => {
//    let component: CheckboxGroupComponent;
//    let checkboxGroupFixture: ComponentFixture<CheckboxGroupComponent>;
///*    let fixture: ComponentFixture<FakeLabelWithInvalidTooltipComponent>;*/
///*    let cdRef: ChangeDetectorRef;*/

//    beforeEach(async () => {
//        await TestBed.configureTestingModule({
//            declarations: [
//                CheckboxGroupComponent,
//                FakeLabelWithInvalidTooltipComponent
//            ],
//            providers: [
///*                ChangeDetectorRef,*/
//            ],
//            imports: [FormsModule, CommonModule]
//        })
//        .compileComponents();
//    });

//    beforeEach(() => {
//        checkboxGroupFixture = TestBed.createComponent(CheckboxGroupComponent);
//        component = checkboxGroupFixture.componentInstance;
///*        fixture = TestBed.createComponent(FakeLabelWithInvalidTooltipComponent);*/
///*        cdRef = checkboxGroupFixture.componentRef.injector.get(ChangeDetectorRef)*/
//        checkboxGroupFixture.detectChanges();
//    });

//    it('should create', () => {
//        expect(component).toBeTruthy();
//    });

//    it('', () => {
//        component.settings.push({ title: 'user', value: 'user', checked: true });
//        component.settings.push({ title: 'admin', value: 'admin', checked: true });

//        component.input = <InputModel>{
//            name: 'roles',
//            type: inputType.checkbox,
//            title: 'роли',
//            readonly: false
//        }

//        checkboxGroupFixture.detectChanges();

//        checkboxGroupFixture.whenStable().then(() => {
//            const el1 = checkboxGroupFixture.debugElement.query(By.css(`#${component.settings[0].value}`));
//            const el2 = checkboxGroupFixture.debugElement.query(By.css(`#${component.settings[1].value}`));
//            console.log(checkboxGroupFixture);
//            console.log(el2);
//            expect(component).toBeTruthy();
//        })

//        //fixture.debugElement.query(Be.css())
         
//    })
//    //it('should be span textContent == title', () => {
//    //    component.title = 'testTitle';

//    //    cdRef.detectChanges();
//    //    const textContent = fixture.nativeElement.querySelector('span').textContent;

//    //    expect(textContent).toContain(component.title);
//    //});

//    //it('should be * if is isRequired == true', () => {
//    //    component.isRequired = true;

//    //    cdRef.detectChanges();
//    //    const textContent = fixture.nativeElement.querySelector('.text-danger').textContent;

//    //    expect(textContent).toContain('*');
//    //});

//    //it('should be htmlFor == testField', () => {
//    //    component.field = 'testField';

//    //    cdRef.detectChanges();
//    //    const htmlFor = fixture.nativeElement.querySelector('label').htmlFor;

//    //    expect(component.field).toContain(htmlFor);
//    //});
//});

