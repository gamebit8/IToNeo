using IToNeo.WebAPI.ApiEndpoints.Shared;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base
{
    public class BaseWithHateoasResponse<T>
    {
        public T Data { get; set; }
        public HateoasResponse Link { get; set; }
    }
}
