using Microsoft.AspNetCore.Http;

namespace IToNeo.WebAPI.Interfaces
{
    public interface IFileHelper
    {
        bool CheckAllowedFileExtension(IFormFile file);
        bool CheckAllowedFileSize(IFormFile file);
        bool CheckFileIsValid(IFormFile file);
        string GetFileName(IFormFile file);
    }
}