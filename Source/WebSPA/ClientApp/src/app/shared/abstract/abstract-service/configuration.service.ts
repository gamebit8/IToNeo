import { Observable } from 'rxjs';
import { Localization } from '../../models/localization.model';
import { UrlsConfiguration } from '../../models/urlsConfiguration.model';
import { BaseConfigurationService } from "../interfaces/baseConfigurationService";

export abstract class ConfigurationService implements BaseConfigurationService{
    apiHost: string;
    urls: UrlsConfiguration;
    localization: Localization;
    isReady: boolean;
    settingsLoaded$: Observable<unknown>;
    load(): void { }
}
