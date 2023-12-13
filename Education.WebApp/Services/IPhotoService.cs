using CloudinaryDotNet.Actions;

namespace Education.WebApp.Services
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeleteAsync(string publicUrl);
        Task<UploadResult> UploadVideoAsync(IFormFile videoFile);
    }
}
