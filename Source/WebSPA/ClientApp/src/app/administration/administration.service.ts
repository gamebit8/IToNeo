import { Injectable } from '@angular/core';
import { castKey, EventBusService } from '../shared/abstract/abstract-service/event-bus.service';
import { OperationComponentSettings } from '../shared/components/operations-menu/operationsMenuSettings.model';
import { Localization } from '../shared/models/localization.model';

@Injectable()
export class AdministrationService {
    constructor(private eventBusService: EventBusService, private localization: Localization) { }

    getLocalization(): Localization {
        return this.localization;
    }

    sendOperationComponentConfiguration(settings: OperationComponentSettings): void {
        this.eventBusService.cast(castKey.operationСomponentConfiguration, settings)
    }
}
