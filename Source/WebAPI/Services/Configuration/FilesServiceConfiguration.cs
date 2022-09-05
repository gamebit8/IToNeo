using System.Collections.Generic;

namespace IToNeo.WebAPI.Services.Configuration
{
    public class FilesServiceConfiguration
    {
        public const string File = "File";

        public int MaximumFileSize { get; set; }
        public IEnumerable<string> AllowedFileFormat { get; set; }
    }
}
