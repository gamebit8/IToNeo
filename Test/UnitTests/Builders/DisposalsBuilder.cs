using IToNeo.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class DisposalsBuilder
    {
        private readonly IEnumerable<EquipmentDisposal> _disposals;

        public DisposalsBuilder()
        {
            _disposals = WithDefaultValues();
        }

        private static IEnumerable<EquipmentDisposal> WithDefaultValues()
        {
            return new List<EquipmentDisposal>()
            {
                new EquipmentDisposal("2/1", DateTime.Now.Date, (float)0.01, "test1", "1"),
                new EquipmentDisposal("2/2", DateTime.Now.Date, (float)0.02, "test2", "2"),
            };
        }

        public IEnumerable<EquipmentDisposal> Build() => _disposals;
    }
}
