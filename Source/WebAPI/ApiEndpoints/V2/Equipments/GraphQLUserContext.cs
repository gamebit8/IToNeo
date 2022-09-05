using System.Collections.Generic;
using System.Security.Claims;
using GraphQL.Authorization;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class GraphQLUserContext : Dictionary<string, object>, IProvideClaimsPrincipal
    {
        public ClaimsPrincipal User { get; set; }
    }
}
