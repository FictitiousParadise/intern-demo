using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace TheOneCatBa.Util
{
    public static class UploadHelper
    {
        public static string ResizeImage(string image, int maxWidth)
        {
            if (image != null && image.Contains("base64,"))
            {
                var imageBytes = Convert.FromBase64String(image.Split(',')[1]);
                using (var imageStream = new MemoryStream(imageBytes))
                {
                    using (var originalBitmap = new Bitmap(imageStream))
                    {
                        int newHeight = (int)((double)originalBitmap.Height / originalBitmap.Width * maxWidth);

                        using (var resizedBitmap = new Bitmap(originalBitmap, maxWidth, newHeight))
                        {
                            using (var resultStream = new MemoryStream())
                            {
                                resizedBitmap.Save(resultStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                var base64String = Convert.ToBase64String(resultStream.ToArray());
                                string rootFile = $"upload";
                                string path = Path.Combine("wwwroot/", $"{rootFile}");
                                string imgName = Guid.NewGuid().ToString("N") + ".png";
                                var bytes = Convert.FromBase64String(base64String);
                                using (var imageFile = new FileStream(path + "/" + imgName, FileMode.Create))
                                {
                                    imageFile.Write(bytes, 0, bytes.Length);
                                    imageFile.Flush();
                                }
                                return $"/{rootFile}/{imgName}";
                            }
                        }
                    }
                }
            }
            else
            {
                return image;
            }

        }



        public static string UploadImage(string image)
        {
            if (image != null && image.Contains("base64,"))
            {
                string rootFile = $"upload";
                string path = Path.Combine("wwwroot/", $"{rootFile}");
                string imgName = Guid.NewGuid().ToString("N") + ".png";
                var bytes = Convert.FromBase64String(image.Split(',')[1]);
                using (var imageFile = new FileStream(path + "/" + imgName, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
                return $"/{rootFile}/{imgName}";
            }
            else
            {
                return image;
            }
        }
        public static string UploadVideo(string video)
        {
            if (video != null && video.Contains("base64,"))
            {
                string rootFile = $"upload";
                string path = Path.Combine("wwwroot/", $"{rootFile}");
                string imgName = Guid.NewGuid().ToString("N") + ".mp4";
                var bytes = Convert.FromBase64String(video.Split(',')[1]);
                using (var imageFile = new FileStream(path + "/" + imgName, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
                return $"/{rootFile}/{imgName}";
            }
            else
            {
                return video;
            }
        }

        public static string UploadImageFormFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "";
            }
            var fileName = Guid.NewGuid().ToString()+".jpg";
            string rootFile = $"upload";
            string path = Path.Combine("wwwroot/", $"{rootFile}");
          
            using (var stream = new FileStream(path + "/" + fileName, FileMode.Create))
            {
                 file.CopyTo(stream);
            }
            return $"/{rootFile}/{fileName}";
        }
    
    }
}
