using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ITonNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class WriteOffWithSpecification
    {
        private readonly IQueryable<EquipmentWriteOff> _testWriteOffs;

        public WriteOffWithSpecification()
        {
            _testWriteOffs = new WriteOffsBuilder().Build().AsQueryable();
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 2)]
        [InlineData(1, 100, 1)]
        public void ReturnWriteOffsWithFilter(int skip, int take, int count)
        {

            var spec = new IToNeo.ApplicationCore.Specifications.WriteOffWithSpecification(skip, take, new EquipmentWriteOff());
            var result = SpecificationEvaluator<EquipmentWriteOff>.GetQuery(_testWriteOffs, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturnWriteOffWithFilter()
        {
            var writeOffAsFilter = _testWriteOffs.First();

            var spec = new IToNeo.ApplicationCore.Specifications.WriteOffWithSpecification(0, 100, writeOffAsFilter);
            var result = SpecificationEvaluator<EquipmentWriteOff>.GetQuery(_testWriteOffs, spec).ToList();

            Assert.Single(result);
            Assert.Equal(writeOffAsFilter, result.First());
        }
    }
}

