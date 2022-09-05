import { Observable } from "rxjs";
import { Localization } from "../../models/localization.model";
import { UrlsConfiguration } from "../../models/urlsConfiguration.model";

export interface BaseConfigurationService {
    urls: UrlsConfiguration; 
    localization: Localization; 
    isReady: boolean;
    settingsLoaded$: Observable<unknown>;
    load(): void;
}

