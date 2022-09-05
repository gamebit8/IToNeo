using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    public class CreatePlaceResult : CreateBaseResult
    {
        public string Address { get; set; }
    }
}
