using IToNeo.ApplicationCore.Entities;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class PlaceWithSpecification
    {
        private readonly IQueryable<Place> _testPlaces;

        public PlaceWithSpecification()
        {
            _testPlaces = new PlacesBuilder().Build().AsQueryable();
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 3)]
        [InlineData(1, 100, 2)]
        public void ReturnPlacesWithFilter(int skip, int take, int count)
        {
            var spec = new IToNeo.ApplicationCore.Specifications.PlaceWithSpecification(skip, take, new Place());
            var result = SpecificationEvaluator<Place>.GetQuery(_testPlaces, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturnPlaceWithFilter()
        {
            var placeAsFilter = _testPlaces.First();

            var spec = new IToNeo.ApplicationCore.Specifications.PlaceWithSpecification(0, 100, placeAsFilter);
            var result = SpecificationEvaluator<Place>.GetQuery(_testPlaces, spec).ToList();

            Assert.Single(result);
            Assert.Equal(placeAsFilter, result.First());
        }
    }
}
