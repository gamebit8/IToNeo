import { InjectionToken } from "@angular/core";
import { AppConfig } from "./shared/models/appConfig.model";

export const APP_CONFIG = new InjectionToken<AppConfig>('app.config');

export const DI_CONFIG: AppConfig = {
    appName: 'IToNeo',
    maximumUploadFileSize: 2097152,
    allowedFileFormat: [
        'txt',
        'doc',
        'docx',
        'pdf',
        'zip',
        'rar',
        '7zip',
        'jpg',
        'bmp',
        'png',
        'tif',
        'tiff',
        'jpeg',
        'gif'
    ],
    httpDefaultTimeout: 10000,
    apiHost: 'https://localhost:44394',
    apiPathConfiguration: '/api/v1/configurations/paths',
    localizationFileUrl: 'assets/localization/rusLocalization.json'
}
