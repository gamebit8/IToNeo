import { Injectable } from '@angular/core';
import { ConfigurationService } from '../../shared/abstract/abstract-service/configuration.service';
import { Localization } from '../../shared/models/localization.model';

@Injectable()
export class IdentityAbstractService {
    public get localization(): Localization {
        return this._localization;
    }
    private _localization: Localization

    constructor(protected configurationService: ConfigurationService) {
        this.getLocalization();
        if (this.configurationService?.urls)
            this.onCreateService();
    }

    protected onCreateService() {

    }

    private getLocalization(): void {
        if(this.configurationService?.localization)
            this._localization = this.configurationService.localization;
    }
}
