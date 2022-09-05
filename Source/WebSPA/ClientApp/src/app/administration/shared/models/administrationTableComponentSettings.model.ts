import { BaseWithNameModel } from "../../../shared/models/baseWithName.model";
import { TableWithSort } from "../../../shared/models/tableWithSort.model";

export class AdministrationTableSettings {
     table = <TableWithSort<BaseWithNameModel>>{};
     title: string
}
