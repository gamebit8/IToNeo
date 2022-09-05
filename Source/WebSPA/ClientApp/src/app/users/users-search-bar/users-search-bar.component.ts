import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntitiesBaseSearchBar } from '../../shared/abstract/abstract-modules/entities-base/entities-base-search-bar.directive';
import { UserBase } from '../shared/userBase.model';
import { UsersFilter } from '../shared/usersFilter.model';

@Component({
    selector: 'users-search-bar',
    templateUrl: './users-search-bar.component.html',
})

export class UsersSearchBlockComponent extends EntitiesBaseSearchBar<UserBase, UsersFilter>{
    constructor(protected activedLink: ActivatedRoute, protected router: Router) {
        super(activedLink, router)
    }
}
