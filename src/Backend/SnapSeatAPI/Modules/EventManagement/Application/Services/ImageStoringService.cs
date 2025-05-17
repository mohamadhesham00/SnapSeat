using Microsoft.AspNetCore.Http;

namespace EventManagement.Application.Services
{
    public static class ImageStoringService
    {
        public static async Task<string> UploadImageAsync(this IFormFile image, Guid eventId)
        {

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return filePath;

        }
    }
}
