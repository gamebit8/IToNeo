namespace IToNeo.WebAPI.ApiEndpoints.V1.Base
{
    public class BaseFilterRequest
    { 
        public int Offset { get; set; } = 0;
        public int Limit { get; } = 100;
        public string SortBy { get; set; }
        public bool SortDescending { get; set; }
    }
}
