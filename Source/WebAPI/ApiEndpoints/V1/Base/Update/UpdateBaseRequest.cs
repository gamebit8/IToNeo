using Microsoft.AspNetCore.Mvc;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base.Update
{
    public class UpdateBaseRequest<TUpdateRequestBody>  where TUpdateRequestBody : UpdateBaseRequestBody
    {
        [FromRoute(Name = "id")] public string Id { get; set; }  
        [FromBody] public TUpdateRequestBody Entity { get; set; }
    }
}
