namespace HotelReservationSystem.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadImage(IFormFile file)
        {
            if (file is null)
                throw new ArgumentNullException("No File is provided for upload.");

            if (!IsImageFile(file))
                throw new BadImageFormatException("Uploaded file is not image.");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");

            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
            var finalPath = Path.Combine(path, fileName);

            using (var fileStream = new FileStream(finalPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }

        public static bool IsImageFile(IFormFile file)
        {
            if (file is null || file.FileName is null)
                return false;

            var allowedImageExtenstions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".svg", ".webp" };
            var fileExtension = Path.GetExtension(file.FileName);

            return allowedImageExtenstions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }
    }
}
