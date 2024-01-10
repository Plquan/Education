using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using CloudinaryDotNet;
using Education.WebApp.Models;

namespace Education.WebApp.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloundinary;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloundinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {         
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloundinary.UploadAsync(uploadParams);
            }
            else
            {
                return uploadResult;
            }
       
            return uploadResult;
        }

        public async Task<DeletionResult> DeleteAsync(string publicUrl)
        {
            var publicId = publicUrl.Split('/').Last().Split('.')[0];
            var deleteParams = new DeletionParams(publicId);
            return await _cloundinary.DestroyAsync(deleteParams);
        }



        public async Task<UploadResult> UploadVideoAsync(IFormFile videoFile)
        {
            // Tạo request để upload video
            var uploadParams = new VideoUploadParams
            {
                File = new FileDescription(videoFile.FileName, videoFile.OpenReadStream()),
                Transformation = new Transformation().Width(640).Height(480).Crop("fit"),
                PublicId = Guid.NewGuid().ToString() // Tên duy nhất cho video trên Cloudinary
            };

            // Thực hiện upload video
            var uploadResult = await _cloundinary.UploadAsync(uploadParams);

            return uploadResult;
        }
       
    
}
}
