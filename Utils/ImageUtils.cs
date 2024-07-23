namespace user_app.Utils
{
    public static class ImageUtils
    {
        public static async Task<byte[]?> ConvertFromIFormFile(IFormFile image)
        {
            if (image == null || image.Length < 1) { return null; }
            using MemoryStream stream = new();
            await image.CopyToAsync(stream);
            return stream.ToArray();
        }
    }
}
