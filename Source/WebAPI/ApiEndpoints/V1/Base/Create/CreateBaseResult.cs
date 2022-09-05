using IToNeo.WebAPI.ApiEndpoints.Shared;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Base.Create
{
    public class CreateBaseResult : HateoasResponse
    {
        public CreateBaseResult() { }
        public CreateBaseResult(string rel, string href) 
            : base(rel, href)
        {

        }
    }

}
