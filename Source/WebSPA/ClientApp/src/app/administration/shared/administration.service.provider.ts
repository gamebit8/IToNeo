import { DataService } from "../../shared/abstract/abstract-service/data.service";
import { EquipmentType } from "../administration-equipment-types/equipmentType.model";
import { Organization } from "../administration-organizations/organization.model";
import { Place } from "../administration-places/place.model";
import { AdministrationService } from "../administration.service";
import { EventBusService } from "../../shared/abstract/abstract-service/event-bus.service";
import { EquipmentStatus } from "../administration-equipment-statuses/equipmentStatus.model";
import { AdministrationTableService } from "./services/administration-table.service";
import { AdministrationEditorService } from "./services/administration-editor.service";
import { MapperService } from "../../shared/abstract/abstract-service/mapper.service";
import { ConfigurationService } from "../../shared/abstract/abstract-service/configuration.service";

export const AdministrationStatusesTableServiceFactory = (dataService: DataService, mapperService: MapperService, configService: ConfigurationService) =>
    new AdministrationTableService<EquipmentStatus>(dataService, mapperService, configService.localization, configService.urls.equipmentStatusesUrl)

export const AdministrationStatusesEditorServiceFactory = (dataService: DataService, configService: ConfigurationService) =>
    new AdministrationEditorService<EquipmentStatus>(dataService, configService.localization, configService.urls.equipmentStatusesUrl)

export const AdministrationTypesTableServiceFactory = (dataService: DataService, mapperService: MapperService, configService: ConfigurationService) =>
    new AdministrationTableService<EquipmentType>(dataService, mapperService, configService.localization, configService.urls.equipmentTypesUrl)

export const AdministrationTypesEditorServiceFactory = (dataService: DataService, configService: ConfigurationService) =>
    new AdministrationEditorService<EquipmentType>(dataService, configService.localization, configService.urls.equipmentTypesUrl)

export const AdministrationOrganizationsTableServiceFactory = (dataService: DataService, mapperService: MapperService, configService: ConfigurationService) =>
    new AdministrationTableService<Organization>(dataService, mapperService, configService.localization, configService.urls.organizationsUrl)

export const AdministrationOrganizationsEditorServiceFactory = (dataService: DataService, configService: ConfigurationService) =>
    new AdministrationEditorService<Organization>(dataService, configService.localization, configService.urls.organizationsUrl)

export const AdministrationPlacesTableServiceFactory = (dataService: DataService, mapperService: MapperService, configService: ConfigurationService) =>
    new AdministrationTableService<Place>(dataService, mapperService, configService.localization, configService.urls.placesUrl)

export const AdministrationPlacesEditorServiceFactory = (dataService: DataService, configService: ConfigurationService) =>
    new AdministrationEditorService<Place>(dataService, configService.localization, configService.urls.placesUrl)

export const AdministrationServiceFactory = (eventBusService: EventBusService, configService: ConfigurationService) =>
    new AdministrationService(eventBusService, configService.localization)
