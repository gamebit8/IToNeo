using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;
using System.Text.Json.Serialization;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    public class GetPlacesResult : GetListBaseResult
    {
        public string Address { get; set; }
    }
}
