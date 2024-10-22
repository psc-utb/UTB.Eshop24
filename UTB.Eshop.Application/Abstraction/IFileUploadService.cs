using Microsoft.AspNetCore.Http;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IFileUploadService
    {
        string FileUpload(IFormFile fileToUpload, string folderNameOnServer);
    }
}
