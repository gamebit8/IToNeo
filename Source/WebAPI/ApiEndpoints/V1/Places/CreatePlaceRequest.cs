using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;
using System.Text.Json.Serialization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    public class CreatePlaceRequest : CreateBaseRequest
    {
        public string Address { get; set; }
    }
}
