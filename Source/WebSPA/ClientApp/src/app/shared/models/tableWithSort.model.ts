import { TableWithSortTitleButtons } from "../components/table-with-sort/table-with-sort-title-butttons/tableWithSortTitleButtons.model";
import { Sorting }              from "./sorting.model";
import { TableWithSortColumn } from "./tableWithSortColumn.model";

export interface TableWithSort<T> {
    colomns: TableWithSortColumn[];
    rows: T[];
    sorting: Sorting;
    selectedRowId: number | string;
    title?: string;
    buttons?: TableWithSortTitleButtons;
}
