import { BaseWithNameModel } from "./baseWithName.model";
import { FileRequets } from "./fileRequest.model";

export interface BaseWithNameAndFileModel extends BaseWithNameModel {
    file: FileRequets;
}
