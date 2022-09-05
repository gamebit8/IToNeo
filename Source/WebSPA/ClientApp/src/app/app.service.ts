import { Injectable } from '@angular/core';
import { ConfigurationService } from './shared/abstract/abstract-service/configuration.service';
import { Localization } from './shared/models/localization.model';

@Injectable()
export class AppService {
    constructor(private configService: ConfigurationService) {

    }

    public getLocalization(): Localization {
        return this.configService.localization
    }
}
