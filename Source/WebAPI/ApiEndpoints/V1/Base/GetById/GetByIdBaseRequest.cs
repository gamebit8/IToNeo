using Microsoft.AspNetCore.Mvc;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById
{
    public class GetByIdBaseRequest
    {
        [FromRoute(Name = "id")] public string Id { get; set; }  
    }
}
