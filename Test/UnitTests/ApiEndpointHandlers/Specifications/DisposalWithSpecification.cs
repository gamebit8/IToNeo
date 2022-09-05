using IToNeo.ApplicationCore.Entities;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class DisposalWithSpecification
    {
        private readonly IQueryable<EquipmentDisposal> _testDisposals;

        public DisposalWithSpecification()
        {
            _testDisposals = new DisposalsBuilder().Build().AsQueryable();
        }


        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 2)]
        [InlineData(1, 100, 1)]
        public void ReturnEquipmentDisposalsWithFilter(int skip, int take, int count)
        {
            var spec = new IToNeo.ApplicationCore.Specifications.DisposalWithSpecification(skip, take, new EquipmentDisposal());
            var result = SpecificationEvaluator<EquipmentDisposal>.GetQuery(_testDisposals, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count ,result.Count);
        }

        [Fact]
        public void ReturnEquipmentDisposalWithFilter()
        {
            var disposalAsFilter = _testDisposals.First();

            var spec = new IToNeo.ApplicationCore.Specifications.DisposalWithSpecification(0, 100, disposalAsFilter);
            var result = SpecificationEvaluator<EquipmentDisposal>.GetQuery(_testDisposals, spec).ToList();

            Assert.Single(result);
            Assert.Equal(disposalAsFilter, result.First());
        }
    }
}
