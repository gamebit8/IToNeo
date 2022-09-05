import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConfigurationService } from '../../shared/abstract/abstract-service/configuration.service';
import { DataService } from '../../shared/abstract/abstract-service/data.service';
import { inputType } from '../../shared/enums/inputType';
import { InputModel } from '../../shared/models/input.model';
import { AdministrationEditorBuilder } from '../shared/administration-editor.builder';
import { AdministrationPlacesEditorServiceFactory } from '../shared/administration.service.provider';
import { AdministationEditorDirective } from '../shared/directives/administation-editor.directive';
import { AdministrationEditorService } from '../shared/services/administration-editor.service';
import { Place } from './place.model';

@Component({
    selector: 'administration-places-editor',
    templateUrl: './administration-places-editor.component.html',
    providers: [{
        provide: AdministrationEditorService,
        useFactory: AdministrationPlacesEditorServiceFactory,
        deps: [DataService, ConfigurationService]
    }]
})
export class AdministrationPlacesEditorComponent extends AdministationEditorDirective<Place> {
    constructor(protected administrationEditorService: AdministrationEditorService<Place>) {
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
                title: this.localization.organization,
                type: inputType.text,
            },
            address: {
                name: 'name',
                title: this.localization.address,
                type: inputType.text
            }
        }
    }

    private getInputsForm(): FormGroup {
        return new FormGroup({
            "id": new FormControl(''),
            "name": new FormControl('', Validators.required),
            "address": new FormControl('', Validators.required)
        });
    }
}
