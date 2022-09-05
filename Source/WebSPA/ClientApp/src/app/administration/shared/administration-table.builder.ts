import { TableWithSort } from "../../shared/models/tableWithSort.model";
import { AdministrationTableSettings } from "./models/administrationTableComponentSettings.model";


export class AdministrationTableBuilder {
    private componentSettings = new AdministrationTableSettings();

    setTable(table: TableWithSort<any>): void {
        this.componentSettings.table = table;
    }

    setTitle(title: string): void {
        this.componentSettings.title = title;
    }

    getSettings(): AdministrationTableSettings {
        return this.componentSettings;
    }
}
