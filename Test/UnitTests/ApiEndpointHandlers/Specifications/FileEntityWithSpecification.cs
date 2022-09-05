using IToNeo.ApplicationCore.Entities;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public  class FileEntityWithSpecification
    {
        private readonly IQueryable<FileEntity> _testFileEntities;

        public FileEntityWithSpecification()
        {
            _testFileEntities = new FileEntitiesBuilder().Build().AsQueryable();
        }


        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 3)]
        [InlineData(1, 100, 2)]
        public void ReturnFileEntitiesWithFilter(int skip, int take, int count)
        {
            var spec = new IToNeo.ApplicationCore.Specifications.FileEntityWithSpecification(skip, take);
            var result = SpecificationEvaluator<FileEntity>.GetQuery(_testFileEntities, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
