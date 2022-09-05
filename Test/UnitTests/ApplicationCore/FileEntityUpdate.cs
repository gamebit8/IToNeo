using IToNeo.ApplicationCore.Entities;
using System.Text;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class FileEntityUpdate
    {
        private readonly string _testName = "TestName";
        private readonly byte[] _testContent = Encoding.ASCII.GetBytes("TestContent");

        [Fact]
        public void UpdateFileEntity()
        {
            var file = new FileEntity()
            {
                Name = _testName,
                Content = _testContent,
            };

            var updatebleFile = new FileEntity();
            updatebleFile.Update(file);

            Assert.Equal(_testName, updatebleFile.Name);
            Assert.Equal(_testContent, updatebleFile.Content);
        }
    }
}
