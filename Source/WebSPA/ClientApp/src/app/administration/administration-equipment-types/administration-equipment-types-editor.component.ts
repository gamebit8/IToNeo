import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConfigurationService } from '../../shared/abstract/abstract-service/configuration.service';
import { DataService } from '../../shared/abstract/abstract-service/data.service';
import { inputType } from '../../shared/enums/inputType';
import { InputModel } from '../../shared/models/input.model';
import { AdministrationEditorBuilder } from '../shared/administration-editor.builder';
import { AdministrationTypesEditorServiceFactory } from '../shared/administration.service.provider';
import { AdministationEditorDirective } from '../shared/directives/administation-editor.directive';
import { AdministrationEditorService } from '../shared/services/administration-editor.service';
import { EquipmentType } from './equipmentType.model';

@Component({
    selector: 'administration-equipment-types-editor',
    templateUrl: './administration-equipment-types-editor.component.html',
    providers: [{
        provide: AdministrationEditorService,
        useFactory: AdministrationTypesEditorServiceFactory,
        deps: [DataService, ConfigurationService]
    }]
})
export class AdministrationEquipmentTypesEditorComponent extends AdministationEditorDirective<EquipmentType> {
    constructor(protected administrationEditorService: AdministrationEditorService<EquipmentType>) {
        super(administrationEditorService)
    }

    onCreating(builder: AdministrationEditorBuilder) {
        const titleTable = this.getTitle();
        const inputSettings = this.getInputSettings();
        const form = this.getInputsForm();

        builder.setTitle(titleTable);
        builder.setInputs(inputSettings);
        builder.setForm(form);
    }

    private getTitle(): string {
        return this.localization.equipmentStatuses;
    }

    private getInputSettings(): { [key: string]: InputModel } {
        return {
            name: {
                name: 'name',
                title: this.localization.status,
                type: inputType.text,
            }
        }
    }

    private getInputsForm() {
        return new FormGroup({
            "id": new FormControl(''),
            "name": new FormControl('', Validators.required)
        });
    }
}
