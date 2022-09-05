import { Injectable } from '@angular/core';
import { OperationComponentSettings } from '../shared/components/operations-menu/operationsMenuSettings.model';
import { Localization } from '../shared/models/localization.model';
import { AuthService } from '../shared/abstract/abstract-service/auth.service';
import { castKey, EventBusService } from '../shared/abstract/abstract-service/event-bus.service';
import { User } from './user.model';
import { ConfigurationService } from '../shared/abstract/abstract-service/configuration.service';

@Injectable()
export class ProfileService {

    constructor(private configService: ConfigurationService , private eventBusService: EventBusService, private auth: AuthService) {

    }

    getLocalization(): Localization {
        return this.configService.localization
    }

    getInforamationAboutUser(): User {
        return {
            userName: this.auth.username,
            userRoles: this.auth.roles.toString(),
            UserPicUrl: ''
        };
    }

    castInitEvent(titleComponent: string): void {
        const ocs = <OperationComponentSettings>{ title: titleComponent };
        this.eventBusService.cast(castKey.operationСomponentConfiguration, ocs);
    }
}
