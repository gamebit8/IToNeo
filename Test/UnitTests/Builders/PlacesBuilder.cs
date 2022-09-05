using IToNeo.ApplicationCore.Entities;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class PlacesBuilder
    {
        private readonly IEnumerable<Place> _places;

        public PlacesBuilder()
        {
            _places = WithDefaultValues();
        }

        private static IEnumerable<Place> WithDefaultValues()
        {
            return new List<Place>()
            {
                new Place("Саратов ЗУ", "ул. Ленина 12"),
                new Place("Самара ГО", "ул. Садовая 180"),
                new Place("Москва ЗУ", "ул. Судакова 256")
            };
        }

        public IEnumerable<Place> Build() => _places;
    }
}

