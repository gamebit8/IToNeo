namespace IToNeo.WebAPI.ApiEndpoints.Shared
{
    public class HateoasResponse
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public HateoasResponse() { }
        public HateoasResponse(string rel, string href)
        {
            Rel = rel;
            Href = href;
        }
    }
}
