using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;

namespace Invidux_Core.Services
{
    public class PhotoService: IPhotoService
    {
        private readonly Cloudinary cloudinary;
        private readonly IWebHostEnvironment _hostingEnv;
        public PhotoService(IConfiguration config, IWebHostEnvironment _hostingEnv)
        {
            Account account = new Account(
                config.GetSection("CloudinarySettings:CloudName").Value,
                config.GetSection("CloudinarySettings:ApiKey").Value,
                config.GetSection("CloudinarySettings:ApiSecret").Value);

            cloudinary = new Cloudinary(account);
            this._hostingEnv = _hostingEnv;
        }

        public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo)
        {
            var uploadResult = new ImageUploadResult();
            if (photo.Length > 0)
            {
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.FileName, stream),
                    Transformation = new Transformation()
                        .Height(500).Width(800)
                };
                uploadResult = await cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await cloudinary.DestroyAsync(deleteParams);

            return result;

        }

        public async Task<string[]> UploadPhoto(IFormFile photo)
        {
            try
            {
                string fileName;
                // Get the file extension from the uploaded file
                var extension = "." + photo.FileName.Split('.')[photo.FileName.Split('.').Length - 1];
                // Create a unique filename for the uploaded file using the current timestamp
                fileName = DateTime.Now.Ticks + extension;

                // Define the path where the file will be saved
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Images");

                // Create the directory if it doesn't exist
                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                // Combine the directory path and the unique filename to get the complete file path
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Images", fileName);

                // Create a FileStream to write the uploaded file data
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Copy the uploaded file's contents to the FileStream asynchronously
                    await photo.CopyToAsync(stream);
                }

                // After successful upload, construct the URL to access the uploaded file
                var fileUrl = $"Uploads/Images/{fileName}";

                return [fileName, fileUrl]; // Return the Name and URL of the uploaded file
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // If an exception occurs during the upload process, log the error and throw an exception
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePhoto(string imageName)
        {
            try
            {
                // Construct the full path to the file based on the filename
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Images", imageName);

                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // If the file exists, delete it
                    File.Delete(filePath);
                    return true; // File deletion successful
                }

                return false; // File doesn't exist
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message); // Throw an exception if an error occurs during deletion
            }
        }
    }
}
