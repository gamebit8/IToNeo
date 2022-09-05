using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class SoftwaresBuilder
    {
        private readonly IEnumerable<Software> _softwares;

        public SoftwaresBuilder()
        {
            _softwares = WithDefaultValues();
        }

        private static IEnumerable<Software> WithDefaultValues()
        {
            return new List<Software>()
            {
                new Software("Office Professional 2016", "тест комментария", "1"),
                new Software("Office Professional 2019", "тест комментария", "1"),
                new Software("Windows 10 Pro", "тест комментария", "1"),
                new Software("предприятие 8.3", "тест комментария", "0"),
                new Software("предприятие 7.7", "тест комментария", "0")
            };
        }

        public IEnumerable<Software> Build() => _softwares;
    }
}
