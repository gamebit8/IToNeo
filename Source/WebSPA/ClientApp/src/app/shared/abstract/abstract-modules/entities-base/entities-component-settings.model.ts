import { OperationButtonsSettings } from "../../../components/operations-menu/operationsMenuSettings.model";
import { InputModel } from "../../../models/input.model";
import { NavFragmentSettings } from "../../../models/navFragmentSettings.model";
import { TableWithSortColumn } from "../../../models/tableWithSortColumn.model";
import { EntitiesBaseSearchBar } from "./entities-base-search-bar.directive";

export class EntitiesComponentSettings {
    title: string;
    inputs: { [key: string]: InputModel };
    entityEditorSettings: { fragmentSettings: NavFragmentSettings[], defaultFragment: string };
    operationButtonsSettings: OperationButtonsSettings;
    searchBarComponent: typeof EntitiesBaseSearchBar;
    referenseEntityTableColumns: TableWithSortColumn[];
}
