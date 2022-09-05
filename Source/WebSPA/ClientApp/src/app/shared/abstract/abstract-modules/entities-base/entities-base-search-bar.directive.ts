import { Directive, Input, OnChanges, OnDestroy, SimpleChanges } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { BaseWithNameModel } from "../../../models/baseWithName.model";
import { InputModel } from "../../../models/input.model";
import { Sorting } from "../../../models/sorting.model";

@Directive()
export abstract class EntitiesBaseSearchBar<TE extends BaseWithNameModel, TEF extends Sorting>{
    @Input() entityIdsDescription: TE;
    @Input() htmlInputs: { [key: string]: InputModel } ;
    @Input() entityFilter: TEF;

    constructor(protected activeLink: ActivatedRoute, protected router: Router) {

    }

    protected onSubmitSearch() {
        this.router.navigate([], { relativeTo: this.activeLink, queryParams: this.entityFilter })
    }
}
