import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntitiesBase } from '../shared/abstract/abstract-modules/entities-base/entities-base.directive';
import { EntitiesComponentBuilder } from '../shared/abstract/abstract-modules/entities-base/entities-component.builder';
import { OperationComponentSettings } from '../shared/components/operations-menu/operationsMenuSettings.model';
import { inputType } from '../shared/enums/inputType';
import { InputModel } from '../shared/models/input.model';
import { NavFragmentSettings } from '../shared/models/navFragmentSettings.model';
import { TableWithSortColumn } from '../shared/models/tableWithSortColumn.model';
import { Software } from './shared/software.model';
import { SoftwareRequest } from './shared/softwareRequest.model';
import { SoftwaresFilter } from './shared/softwaresFilter.model';
import { SoftwaresResoponse } from './shared/softwaresResponse.model';
import { SoftwaresEditorComponent } from './softwares-editor/softwares-editor.component';
import { SoftwaresEquipmentsComponent } from './softwares-equipments/softwares-equipments.component';
import { SoftwaresSearchBarComponent } from './softwares-search-bar/softwares-search-bar.component';
import { SoftwaresService } from './softwares.service';

@Component({
    selector: 'softwares',
    templateUrl: '../shared/abstract/abstract-modules/entities-base/entities-base.component.html'
})

export class SoftwaresComponent extends EntitiesBase<Software, SoftwaresFilter, SoftwareRequest, SoftwaresResoponse> {
    constructor(protected softwaresService: SoftwaresService, protected activeLink: ActivatedRoute, protected router: Router) {
        super(softwaresService, activeLink, router)
    }

    protected onCreating(builder: EntitiesComponentBuilder): void {
        const editorSettings = this.getEditorSetting();
        const operationButtonsSettings = this.getOperationButtonsSettings();
        const inputSettings = this.getEntityInput();
        const entityTalbeColumns = this.getReferenseEntityTableColumns();

        builder.addEntityEditor(editorSettings);
        builder.addSearchBar(SoftwaresSearchBarComponent);
        builder.setComponentTitle(this.localization.equipment);
        builder.setOperationButtons(operationButtonsSettings);
        builder.setEntityInput(inputSettings);
        builder.setReferenseEntityTableColumns(entityTalbeColumns);
    }

    private getEditorSetting(): { fragmentSettings: NavFragmentSettings[], defaultFragment: string } {
        return {
            fragmentSettings: [
                { title: this.localization.main, fragment: 'edit', component: SoftwaresEditorComponent },
                { title: this.localization.equipment, fragment: 'equipments', component: SoftwaresEquipmentsComponent },              ],
            defaultFragment: 'edit'
        }
    }

    private getOperationButtonsSettings(): OperationComponentSettings {
        return {
            addOperation: true,
            deleteOperation: true,
            editOperation: true,
            searchOperation: true,
        }
    }

    private getEntityInput(): { [key: string]: InputModel } {
        return {
            name: {
                name: 'name',
                title: this.localization.license,
                type: inputType.text
            },
            type: {
                name: 'type.name',
                title: this.localization.licenseType,
                type: inputType.text,
                searchHelperUrl: this.urls.softwareLicenseTypesUrl
            },
            software: {
                name: 'software.name',
                title: this.localization.software,
                type: inputType.text,
                searchHelperUrl: this.urls.softwaresUrl
            },
            organization: {
                name: 'organization.name',
                title: this.localization.organization,
                type: inputType.text,
                searchHelperUrl: this.urls.organizationSearchHelperUrl
            },
            count: {
                name: 'count',
                title: this.localization.licenseCount,
                type: inputType.number
            },
            licenseCode: {
                name: 'licenseCode',
                title: this.localization.licenseCode,
                type: inputType.text
            },
            note: {
                name: 'note',
                title: this.localization.lisenseNote,
                type: inputType.text
            }
        }
    }

    private getReferenseEntityTableColumns(): TableWithSortColumn[] {
        return [
            { field: 'developer.name', title: this.localization.developer },
            { field: 'software.name', title: this.localization.software },
            { field: 'name', title: this.localization.license },
            { field: 'type.name', title: this.localization.licenseType },
            { field: 'licenseCode', title: this.localization.licenseCode },
            { field: 'count', title: this.localization.licenseCount },
            { field: 'usedLicenses', title: this.localization.usedLicenses }
        ]
    }
}
