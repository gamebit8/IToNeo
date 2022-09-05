using Microsoft.AspNetCore.Mvc;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base
{
    public class EntityBaseRequest
    {
        [FromRoute]
        public string Id { get; set; }  
    }
}
