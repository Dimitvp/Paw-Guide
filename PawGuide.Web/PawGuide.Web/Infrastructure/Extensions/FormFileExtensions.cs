namespace PawGuide.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Http;
    using System.IO;

    using static WebConstants;

    public static class FormFileExtensions
    {
        public static bool HasValidImage(this IFormFile image)
            => image != null
               && image.Length <= ImageSize
               && (image.FileName.EndsWith(JpgFormat)
                   || image.FileName.EndsWith(PngFormat));

        public static string SaveImage(this IFormFile image, int businessId, string businessType, string businessName, string imagePath)
        {
            var imageName = image.FileName.ToImageName(businessId, businessType, businessName);

            var filePath = Path
                .Combine(Directory.GetCurrentDirectory(),
                    imagePath,
                    imageName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return imageName;
        }

        public static void SaveImage(this IFormFile image, string imageName, string imagePath)
        {
            var extension = Path.GetExtension(image.FileName);

            var filePath = Path
                .Combine(Directory.GetCurrentDirectory(),
                    imagePath,
                    imageName + extension);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }
        }
    }
}
