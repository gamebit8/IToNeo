using GraphQL.Types;
using IToNeo.ApplicationCore.Entities;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments.Types
{
    public class PlaceGraphType : ObjectGraphType<Place>
    {
        public PlaceGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
