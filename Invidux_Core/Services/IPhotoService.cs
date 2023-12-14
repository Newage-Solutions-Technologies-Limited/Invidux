using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Invidux_Core.Services
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo);

        //will add onre more method for deleting the photo
        Task<DeletionResult> DeletePhotoAsync(string publicId);
        Task<string[]> UploadPhoto(IFormFile photo);
        Task<bool> DeletePhoto(string imageName);
    }
}
