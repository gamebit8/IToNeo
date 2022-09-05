using Microsoft.AspNetCore.Mvc;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete
{
    public class DeleteBaseRequest
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
