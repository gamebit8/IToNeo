import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Localization } from '../shared/models/localization.model';
import { AuthService } from '../shared/abstract/abstract-service/auth.service';
import { castKey, EventBusService } from '../shared/abstract/abstract-service/event-bus.service';
import { ConfigurationService } from '../shared/abstract/abstract-service/configuration.service';

@Injectable()
export class HeaderBarService {
    constructor(private configService: ConfigurationService, private eventBusService: EventBusService, private auth: AuthService) {

    }

    getLocalization(): Localization {
        return this.configService.localization
    }

    onEvents(): Observable<any>{
        return this.eventBusService.on(castKey.operationСomponentConfiguration);
    }

    castEvents(key: string, data: any): void{
        return this.eventBusService.cast(key, data);
    }

    logout(): void {
        this.auth.logout();
    }
}
