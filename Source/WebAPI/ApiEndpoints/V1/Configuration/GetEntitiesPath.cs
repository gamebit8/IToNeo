using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Configuration
{
    [Route("api/v1/configurations")]
    [ApiController]
    [AllowAnonymous]
    public class GetEntitiesPaths : EndpointBaseSync.WithoutRequest.WithActionResult<GetEntitiesPathsResult>
    {
        [HttpGet("paths")]
        [SwaggerOperation(
            Summary = "Get a Paths",
            Description = "Get a Paths",
            OperationId = "GetPaths",
            Tags = new[] { "Configuration" })
        ]
        public override ActionResult<GetEntitiesPathsResult> Handle()
        {
            GetEntitiesPathsResult result = GetConfigurationUrlsResult();
            return Ok(result);
        }

        private GetEntitiesPathsResult GetConfigurationUrlsResult()
        {
            return new GetEntitiesPathsResult()
            {
                EmployeesPath = Url.Action("Handle", "GetEmployees", null),
                EquipmentsPath = Url.Action("Handle", "GetEquipments", null),
                EquipmentTypesPath = Url.Action("Handle", "GetEquipmentTypes", null),
                EquipmentStatusesPath = Url.Action("Handle", "GetEquipmentStatuses", null),
                SoftwaresPath = Url.Action("Handle", "GetSoftwares", null),
                SoftwareDevelopersPath = Url.Action("Handle", "GetDevelopers", null),
                SoftwareLicensesPath = Url.Action("Handle", "GetSoftwareLicenses", null),
                SoftwareLicenseTypesPath = Url.Action("Handle", "GetSoftwareLicenseTypes", null),
                DisposalsPath = Url.Action("Handle", "GetEquipmentDisposals", null),
                OrganizationsPath = Url.Action("Handle", "GetOrganizations", null),
                PlacesPath = Url.Action("Handle", "GetPlaces", null),
                WriteOffsPath = Url.Action("Handle", "GetEquipmentWriteOffs", null),
                AuthenticatePath = Url.Action("Handle", "Authenticate", null),
                RegisterPath = Url.Action("Handle", "Register", null),
                ChangePasswordPath = Url.Action("Handle", "ChangePassword", null),
                ChangePasswordAfterResetPath = Url.Action("Handle", "ChangePasswordAfterReset", null),
                RecoveryPasswordPath = Url.Action("Handle", "ResetPassword", null),
                ConfirmEmailPath = Url.Action("Handle", "ConfirmEmail", null),
                EmployeeSearchHelperPath = Url.Action("Handle", "GetEmployeesShort", null),
                OrganizationSearchHelperPath = Url.Action("Handle", "GetOrganizationsShort", null),
                EquipmentSearchHelperPath = Url.Action("Handle", "GetEquipmentsShort", null),
                EquipmentTypeSearchHelperPath = Url.Action("Handle", "GetEquipmentTypesShort", null),
                EquipmentStatusSearchHelperPath = Url.Action("Handle", "GetEquipmentStatusesShort", null),
                PlaceSearchHelperPath = Url.Action("Handle", "GetPlacesShort", null),
                FilesPath = Url.Action("Handle", "GetFiles", null),
                EquipmentsSoftwareLicensesPath = Url.Action("Handle", "GetEquipmentsSoftwareLicenses", null),
                UsersPath = Url.Action("Handle", "GetUsers", null),
                UserRolesPath = Url.Action("Handle", "GetUserRoles", null)
            };
        }
    }
}
