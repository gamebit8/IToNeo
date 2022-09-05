import { OperationButtonsSettings } from "../../../components/operations-menu/operationsMenuSettings.model";
import { InputModel } from "../../../models/input.model";
import { NavFragmentSettings } from "../../../models/navFragmentSettings.model";
import { TableWithSortColumn } from "../../../models/tableWithSortColumn.model";
import { EntitiesComponentSettings } from "./entities-component-settings.model";

export class EntitiesComponentBuilder {
    private entitiesComponentSettings: EntitiesComponentSettings = new EntitiesComponentSettings();

    public setEntityInput(entityInput: { [key: string]: InputModel }): void {
        this.entitiesComponentSettings.inputs = entityInput;
    }

    public setComponentTitle(title: string): void {
        this.entitiesComponentSettings.title = title;
    }

    public addEntityEditor(settings: { fragmentSettings: NavFragmentSettings[], defaultFragment: string }): void {
        this.entitiesComponentSettings.entityEditorSettings = settings;
    }

    public addSearchBar(searchBarComponent: any): void {
        this.entitiesComponentSettings.searchBarComponent = searchBarComponent;
    }

    public setOperationButtons(settings: OperationButtonsSettings): void {
        this.entitiesComponentSettings.operationButtonsSettings = settings;
    }

    public setReferenseEntityTableColumns(entityTableColomns: TableWithSortColumn[]): void {
        this.entitiesComponentSettings.referenseEntityTableColumns = entityTableColomns;
    }

    public getSettings(): EntitiesComponentSettings {
        return this.entitiesComponentSettings;
    }
}
