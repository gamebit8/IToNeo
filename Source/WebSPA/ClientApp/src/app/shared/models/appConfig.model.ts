export interface AppConfig {
    appName: string;
    maximumUploadFileSize: number;
    allowedFileFormat: string[];
    httpDefaultTimeout: number;
    urlsConfigurationUrl: string,
    localizationFileUrl: string;
}
