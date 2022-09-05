using IToNeo.ApplicationCore.Entities;


namespace IToNeo.ApplicationCore.Specifications
{
    public class PlaceWithSpecification : BaseSpecification<Place>
    {
        public PlaceWithSpecification(string id) : base(i => i.Id == id)
        {
        }
        public PlaceWithSpecification(int skip, int take, Place place, string OrderBy = null, bool isDescending = false)
            : base(i => string.IsNullOrEmpty(place.Name) || i.Name.StartsWith(place.Name))
        {
            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(OrderBy))
            {
                ApplyOrderBy(OrderBy, isDescending);
            }
        }
    }
}
