import { Injectable } from '@angular/core';
import { link } from 'fs';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { EntitiesBaseService } from '../shared/abstract/abstract-modules/entities-base/entities-base.service';
import { ConfigurationService } from '../shared/abstract/abstract-service/configuration.service';
import { DataService } from '../shared/abstract/abstract-service/data.service';
import { EventBusService } from '../shared/abstract/abstract-service/event-bus.service';
import { MapperService } from '../shared/abstract/abstract-service/mapper.service';
import { StorageService } from '../shared/abstract/abstract-service/storage.service';
import { CheckBoxItem } from '../shared/components/checkbox-group/checkboxItem.model';
import { BaseResponse } from '../shared/models/baseResponse.model';
import { BaseWithNameModel } from '../shared/models/baseWithName.model';
import { User } from './shared/user.model';
import { UserRequest } from './shared/userRequest.model';
import { UsersFilter } from './shared/usersFilter.model';
import { UsersResoponse } from './shared/usersResponse.model';

@Injectable()
export class UsersService extends EntitiesBaseService<User, UsersFilter, UserRequest, UsersResoponse> {
    private userRolesUrl: string;

    constructor(
        protected dataService: DataService,
        protected configurationService: ConfigurationService,
        protected eventBusService: EventBusService,
        protected storageService: StorageService,
        protected mapperService: MapperService
    ) {
        super(dataService, configurationService, eventBusService, storageService, mapperService)
        this.entitiesUrl = this.configurationService.urls.usersUrl;
        this.userRolesUrl = this.configurationService.urls.userRolesUrl;
    }

    getRoles(): Observable<BaseResponse<Array<CheckBoxItem>>> {
        return this.dataService
            .get<BaseWithNameModel[]>(this.userRolesUrl)
            .pipe(map((res) => {
                return {
                    status: res.status,
                    data: res.data.map(r => <CheckBoxItem>{ title: r.name, value: r.name, checked: false })
                }
            }));
    }
}
