using AutoMapper;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.Infrastructure.Identity.Entities;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Developers;
using IToNeo.WebAPI.ApiEndpoints.V1.Employees;
using IToNeo.WebAPI.ApiEndpoints.V1.Equipments;
using IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Disposals;
using IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Statuses;
using IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Types;
using IToNeo.WebAPI.ApiEndpoints.V1.Equipments.WriteOffs;
using IToNeo.WebAPI.ApiEndpoints.V1.EquipmentsSoftwareLicenses;
using IToNeo.WebAPI.ApiEndpoints.V1.Files;
using IToNeo.WebAPI.ApiEndpoints.V1.Organizations;
using IToNeo.WebAPI.ApiEndpoints.V1.Places;
using IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses;
using IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenseTypes;
using IToNeo.WebAPI.ApiEndpoints.V1.Softwares;
using IToNeo.WebAPI.ApiEndpoints.V1.Users;


namespace IToNeo.WebAPI.Services.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<FileEntity, BaseResponse>();

            CreateMap<GetEmployeesRequest, Employee>();
            CreateMap<GetEmployeesShortRequest, Employee>();
            CreateMap<GetByIdEmployeeRequest, Employee>();
            CreateMap<Employee, GetEmployeesResult>();
            CreateMap<Employee, GetByIdEmployeeResult>();
            CreateMap<Employee, EntityBaseResult>();
            CreateMap<Employee, GetEmployeesShortResult>();
            CreateMap<Employee, UpdateEmployeeResult>();
            CreateMap<UpdateEmployeeRequestBody, Employee>();
            CreateMap<CreateEmployeeRequest, Employee>();

            CreateMap<GetEquipmentsRequest, Equipment>();
            CreateMap<GetEquipmentsShortRequest, Equipment>();
            CreateMap<GetByIdEquipmentRequest, Equipment>();
            CreateMap<Equipment, GetEquipmentsResult>();
            CreateMap<Equipment, GetByIdSoftwareLicenseEquipmentResult>();
            CreateMap<Equipment, GetEquipmentsShortResult>();
            CreateMap<EntityBaseResult, GetByIdEquipmentResult>();
            CreateMap<Equipment, UpdateEquipmentResult>();
            CreateMap<Equipment, GetByIdEquipmentResult>();
            CreateMap<Equipment, EntityBaseResult>();
            CreateMap<UpdateEquipmentRequestBody, Equipment>();
            CreateMap<CreateEquipmentRequest, Equipment>();

            CreateMap<GetEquipmentDisposalsRequest, EquipmentDisposal>();
            CreateMap<GetByIdEquipmentDisposalRequest, EquipmentDisposal>();
            CreateMap<EquipmentDisposal, GetEquipmentDisposalsResult>();
            CreateMap<EquipmentDisposal, GetByIdEquipmentDisposalResult>();
            CreateMap<EquipmentDisposal, EntityBaseResult>();
            CreateMap<EquipmentDisposal, UpdateEquipmentDisposalResult>();
            CreateMap<UpdateEquipmentDisposalRequestBody, EquipmentDisposal>();
            CreateMap<CreateEquipmentDisposalRequest, EquipmentDisposal>();

            CreateMap<GetEquipmentStatusesRequest, EquipmentStatus>();
            CreateMap<GetEquipmentStatusesShortRequest, EquipmentStatus>();
            CreateMap<GetByIdEquipmentStatusRequest, EquipmentStatus>();
            CreateMap<EquipmentStatus, GetEquipmentStatusesResult>();
            CreateMap<EquipmentStatus, GetByIdEquipmentStatusResult>();
            CreateMap<EquipmentStatus, GetEquipmentStatusesShortResult>();
            CreateMap<EquipmentStatus, EntityBaseResult>();
            CreateMap<EquipmentStatus, UpdateEquipmentStatusResult>();
            CreateMap<UpdateEquipmentStatusRequestBody, EquipmentStatus>();
            CreateMap<CreateEquipmentStatusRequest, EquipmentStatus>();

            CreateMap<GetEquipmentTypesRequest, EquipmentType>();
            CreateMap<GetEquipmentTypesShortRequest, EquipmentType>();
            CreateMap<GetByIdEquipmentTypeRequest, EquipmentType>();
            CreateMap<EquipmentType, GetEquipmentTypesResult>();
            CreateMap<EquipmentType, GetEquipmentTypesShortResult>();
            CreateMap<EquipmentType, GetByIdEquipmentTypeResult>();
            CreateMap<EquipmentType, EntityBaseResult>();
            CreateMap<EquipmentType, UpdateEquipmentTypeResult>();
            CreateMap<UpdateEquipmentTypeRequestBody, EquipmentType>();
            CreateMap<CreateEquipmentTypeRequest, EquipmentType>();

            CreateMap<GetByIdEquipmentWriteOffRequest, EquipmentWriteOff>();
            CreateMap<GetEquipmentWriteOffsRequest, EquipmentWriteOff>();
            CreateMap<EquipmentWriteOff, GetEquipmentWriteOffsResult>();
            CreateMap<EquipmentWriteOff, GetByIdEquipmentWriteOffResult>();
            CreateMap<EquipmentWriteOff, EntityBaseResult>();
            CreateMap<EquipmentWriteOff, UpdateEquipmentWriteOffResult>();
            CreateMap<UpdateEquipmentWriteOffRequestBody, EquipmentWriteOff>();
            CreateMap<CreateEquipmentWriteOffRequest, EquipmentWriteOff>();

            CreateMap<GetByIdEquipmentSoftwareLicenseRequest, EquipmentSoftwareLicense>();
            CreateMap<EquipmentSoftwareLicense, GetEquipmentsSoftwareLicensesResult>();
            CreateMap<EquipmentSoftwareLicense, GetByIdEquipmentSoftwareLicenseResult>();
            CreateMap<EquipmentSoftwareLicense, EntityBaseResult>();
            CreateMap<EntityBaseResult, GetEquipmentsSoftwareLicensesResult>();
            CreateMap<EntityBaseResult, GetEquipmentsSoftwareLicensesResult>();
            CreateMap<EquipmentSoftwareLicense, UpdateEquipmentSoftwareLicenseResult>();
            CreateMap<UpdateEquipmentSoftwareLicenseRequestBody, EquipmentSoftwareLicense>();
            CreateMap<CreateEquipmentSoftwareLicenseRequest, EquipmentSoftwareLicense>();

            CreateMap<GetByIdFileRequest, FileEntity>();
            CreateMap<FileEntity, GetByIdFileResult>();
            CreateMap<FileEntity, EntityBaseResult>();
            CreateMap<FileEntity, UpdateFileResult>();
            CreateMap<UpdateFileRequestBody, FileEntity>();
            CreateMap<CreateFileRequest, FileEntity>();

            CreateMap<GetByIdOrganizationRequest, Organization>();
            CreateMap<GetOrganizationsRequest, Organization>();
            CreateMap<GetOrganizationsShortRequest, Organization>();
            CreateMap<Organization, GetOrganizationsResult>();
            CreateMap<Organization, GetOrganizationsShortResult>();
            CreateMap<Organization, GetByIdOrganizationResult>();
            CreateMap<Organization, EntityBaseResult>();
            CreateMap<Organization, UpdateOrganizationResult>();
            CreateMap<UpdateOrganizationRequestBody, Organization>();
            CreateMap<CreateOrganizationRequest, Organization>();

            CreateMap<ApplicationUser, GetUsersResult>();
            CreateMap<ApplicationUser, GetByIdUserResult>();

            CreateMap<GetByIdPlaceRequest, Place>();
            CreateMap<GetPlacesRequest, Place>();
            CreateMap<GetPlacesShortRequest, Place>();
            CreateMap<Place, GetPlacesResult>();
            CreateMap<Place, GetPlacesShortResult>();
            CreateMap<Place, GetByIdPlaceResult>();
            CreateMap<Place, EntityBaseResult>();
            CreateMap<Place, UpdatePlaceResult>();
            CreateMap<UpdatePlaceRequestBody, Place>();
            CreateMap<CreatePlaceRequest, Place>();

            CreateMap<GetByIdSoftwareRequest, Software>();
            CreateMap<GetSoftwaresRequest, Software>();
            CreateMap<Software, GetByIdSoftwareResult>();
            CreateMap<Software, GetSoftwaresResult>();
            CreateMap<Software, EntityBaseResult>();
            CreateMap<Software, UpdateSoftwareResult>();
            CreateMap<UpdateSoftwareRequestBody, Software>();
            CreateMap<CreateSoftwareRequest, Software>();

            CreateMap<GetByIdDeveloperRequest, SoftwareDeveloper>();
            CreateMap<GetDevelopersRequest, SoftwareDeveloper>();
            CreateMap<SoftwareDeveloper, GetDevelopersResult>();
            CreateMap<SoftwareDeveloper, GetByIdDeveloperResult>();
            CreateMap<SoftwareDeveloper, EntityBaseResult>();
            CreateMap<SoftwareDeveloper, UpdateDeveloperResult>();
            CreateMap<UpdateDeveloperRequestBody, SoftwareDeveloper>();
            CreateMap<CreateDeveloperRequest, SoftwareDeveloper>();

            CreateMap<GetByIdSoftwareLicenseRequest, SoftwareLicense>();
            CreateMap<GetSoftwareLicensesRequest, SoftwareLicense>();
            CreateMap<SoftwareLicense, GetSoftwareLicensesResult>()
                .ForPath(d => d.Developer.Id, opt => opt.MapFrom(s => s.Software.Developer.Id))
                .ForPath(d => d.Developer.Name, opt => opt.MapFrom(s => s.Software.Developer.Name))
                .ForPath(d => d.UsedLicenses, opt => opt.MapFrom(s => s.Equipments.Count));
            CreateMap<GetSoftwareLicensesRequest, SoftwareLicense>();
            CreateMap<SoftwareLicense, GetByIdSoftwareLicenseResult>();
            CreateMap<SoftwareLicense, EntityBaseResult>();
            CreateMap<SoftwareLicense, UpdateSoftwareLicenseResult>();
            CreateMap<UpdateSoftwareLicenseRequestBody, SoftwareLicense>();
            CreateMap<CreateSoftwareLicenseRequest, SoftwareLicense>();

            CreateMap<GetByIdSoftwareLicenseTypeRequest, SoftwareLicenseType>();
            CreateMap<GetSoftwareLicenseTypesRequest, SoftwareLicenseType>();
            CreateMap<SoftwareLicenseType, GetSoftwareLicenseTypesResult>();
            CreateMap<SoftwareLicenseType, GetByIdSoftwareLicenseTypeResult>();
            CreateMap<SoftwareLicenseType, EntityBaseResult>();
            CreateMap<SoftwareLicenseType, UpdateSoftwareLicenseTypeResult>();
            CreateMap<UpdateSoftwareLicenseTypeRequestBody, SoftwareLicenseType>();
            CreateMap<CreateSoftwareLicenseTypeRequest, SoftwareLicenseType>();
        }
    }
}
