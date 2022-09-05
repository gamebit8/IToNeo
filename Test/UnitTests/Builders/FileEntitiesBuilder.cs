using IToNeo.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IToNeo.UnitTests.Builders
{
    public class FileEntitiesBuilder
    {
        private readonly IEnumerable<FileEntity> _files;

        public FileEntitiesBuilder()
        {
            _files = WithDefaultValues();
        }

        private static IEnumerable<FileEntity> WithDefaultValues()
        {
            var content = Encoding.ASCII.GetBytes("test text");

            return new List<FileEntity>()
            {
                new FileEntity("test.txt", content, "0", null, null),
                new FileEntity("test.txt", content, null, "0", null),
                new FileEntity("test.txt", content, null, null, "0")
            };
        }

        public IEnumerable<FileEntity> Build() => _files;
    }
}
