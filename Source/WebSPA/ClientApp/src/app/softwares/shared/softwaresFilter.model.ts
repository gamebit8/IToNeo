import { Sorting } from '../../shared/models/sorting.model'
import { SoftwareBase } from './softwareBase.model'

export interface SoftwaresFilter extends SoftwareBase, Sorting{
    typeId: string;
    softwareId: string;
    organizationId: string;
    codeLicense: string;
    name: string;
}
