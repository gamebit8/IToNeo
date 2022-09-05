using IToNeo.WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Files
{
    public class FileHelper : IFileHelper
    {
        private readonly int _fileMaxSize;
        private readonly IEnumerable<string> _allowedFileExtensions;

        public FileHelper(int fileMaxSize, IEnumerable<string> allowedFileExtensions)
        {
            _fileMaxSize = fileMaxSize;
            _allowedFileExtensions = allowedFileExtensions ?? throw new ArgumentNullException(nameof(allowedFileExtensions));
        }

        public string GetFileName(IFormFile file)
        {
            return ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        }

        public bool CheckFileIsValid(IFormFile file)
        {
            return (CheckAllowedFileSize(file) && CheckAllowedFileExtension(file));
        }

        public bool CheckAllowedFileSize(IFormFile file)
        {
            return (file.Length <= _fileMaxSize);
        }

        public bool CheckAllowedFileExtension(IFormFile file)
        {
            var extensionFile = Path.GetExtension(file.FileName).ToLower();

            foreach (var allowedFileFormat in _allowedFileExtensions)
            {
                if (allowedFileFormat == extensionFile)
                    return true;
            }

            return false;
        }
    }
}
