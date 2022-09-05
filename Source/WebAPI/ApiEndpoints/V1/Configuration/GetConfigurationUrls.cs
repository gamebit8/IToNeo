using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Configuration
{
    [Route("api/v1/configurations")]
    [ApiController]
    [AllowAnonymous]
    public class GetConfigurationUrls : EndpointBaseSync.WithoutRequest.WithActionResult<GetConfigurationUrlsResult>
    {
        [HttpGet("urls")]
        [SwaggerOperation(
            Summary = "Get a Urls",
            Description = "Get a Urls",
            OperationId = "GetUrls",
            Tags = new[] { "Configuration" })
        ]
        public override ActionResult<GetConfigurationUrlsResult> Handle()
        {
            GetConfigurationUrlsResult result = GetConfigurationUrlsResult();
            return Ok(result);
        }

        private GetConfigurationUrlsResult GetConfigurationUrlsResult()
        {
            string scheme = Url.ActionContext.HttpContext.Request.Scheme;

            return new GetConfigurationUrlsResult()
            {
                EmployeesUrl = Url.Action("Handle", "GetEmployees", null, scheme),
                EquipmentsUrl = Url.Action("Handle", "GetEquipments", null, scheme),
                EquipmentTypesUrl = Url.Action("Handle", "GetEquipmentTypes", null, scheme),
                EquipmentStatusesUrl = Url.Action("Handle", "GetEquipmentStatuses", null, scheme),
                SoftwaresUrl = Url.Action("Handle", "GetSoftwares", null, scheme),
                SoftwareDevelopersUrl = Url.Action("Handle", "GetDevelopers", null, scheme),
                SoftwareLicensesUrl = Url.Action("Handle", "GetSoftwareLicenses", null, scheme),
                SoftwareLicenseTypesUrl = Url.Action("Handle", "GetSoftwareLicenseTypes", null, scheme),
                DisposalsUrl = Url.Action("Handle", "GetEquipmentDisposals", null, scheme),
                OrganizationsUrl = Url.Action("Handle", "GetOrganizations", null, scheme),
                PlacesUrl = Url.Action("Handle", "GetPlaces", null, scheme),
                WriteOffsUrl = Url.Action("Handle", "GetEquipmentWriteOffs", null, scheme),
                AuthenticateUrl = Url.Action("Handle", "Authenticate", null, scheme),
                RegisterUrl = Url.Action("Handle", "Register", null, scheme),
                ChangePasswordUrl = Url.Action("Handle", "ChangePassword", null, scheme),
                ChangePasswordAfterResetUrl = Url.Action("Handle", "ChangePasswordAfterReset", null, scheme),
                RecoveryPasswordUrl = Url.Action("Handle", "ResetPassword", null, scheme),
                ConfirmEmailUrl = Url.Action("Handle", "ConfirmEmail", null, scheme),
                EmployeeSearchHelperUrl = Url.Action("Handle", "GetEmployeesShort", null, scheme),
                OrganizationSearchHelperUrl = Url.Action("Handle", "GetOrganizationsShort", null, scheme),
                EquipmentSearchHelperUrl = Url.Action("Handle", "GetEquipmentsShort", null, scheme),
                EquipmentTypeSearchHelperUrl = Url.Action("Handle", "GetEquipmentTypesShort", null, scheme),
                EquipmentStatusSearchHelperUrl = Url.Action("Handle", "GetEquipmentStatusesShort", null, scheme),
                PlaceSearchHelperUrl = Url.Action("Handle", "GetPlacesShort", null, scheme),
                FilesUrl = Url.Action("Handle", "GetFiles", null, scheme),
                EquipmentsSoftwareLicensesUrl = Url.Action("Handle", "GetEquipmentsSoftwareLicenses", null, scheme),
                UsersUrl = Url.Action("Handle", "GetUsers", null, scheme),
                UserRolesUrl = Url.Action("Handle", "GetUserRoles", null, scheme)
            };
        }
    }
}
