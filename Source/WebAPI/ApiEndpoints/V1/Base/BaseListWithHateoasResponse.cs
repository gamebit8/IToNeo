using IToNeo.WebAPI.ApiEndpoints.Shared;
using System.Collections.Generic;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base
{
    public class BaseListWithHateoasResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public IEnumerable<HateoasResponse> Link { get; set; }
    }
}
