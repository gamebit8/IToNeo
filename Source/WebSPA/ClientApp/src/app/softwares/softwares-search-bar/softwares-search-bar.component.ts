import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntitiesBaseSearchBar } from '../../shared/abstract/abstract-modules/entities-base/entities-base-search-bar.directive';
import { Software } from '../shared/software.model';
import { SoftwaresFilter } from '../shared/softwaresFilter.model';

@Component({
    selector: 'softwares-search-bar',
    templateUrl: './softwares-search-bar.component.html',
})

export class SoftwaresSearchBarComponent extends EntitiesBaseSearchBar<Software, SoftwaresFilter>{
    constructor(protected activedLink: ActivatedRoute, protected router: Router) {
        super(activedLink, router)
    }
}
