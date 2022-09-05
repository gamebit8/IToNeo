import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntitiesBaseSearchBar } from '../../shared/abstract/abstract-modules/entities-base/entities-base-search-bar.directive';
import { Equipment } from '../shared/equipment.model';
import { EquipmentsFilter } from '../shared/equipmentsFilter.model';

@Component({
    selector: 'equipments-search-bar',
    templateUrl: './equipments-search-bar.component.html',
    styleUrls: ['./equipments-search-bar.component.css']
})

export class EqupmentsSearchBarComponent extends EntitiesBaseSearchBar<Equipment, EquipmentsFilter>{

    constructor(activeLink: ActivatedRoute, router: Router) {
        super(activeLink, router)
    }
}
