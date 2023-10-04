export interface AppConfig {
    appName: string;
    maximumUploadFileSize: number;
    allowedFileFormat: string[];
    httpDefaultTimeout: number;
    apiPathConfiguration: string,
    apiHost: string;
    localizationFileUrl: string;
}
