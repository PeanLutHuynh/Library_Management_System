using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public static class ResourceManager
    {
        // Resources folder path
        private static readonly string ResourcesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
        private static readonly string ImagesFolder = Path.Combine(ResourcesFolder, "Images");

        // Method to load an image from file
        public static Image LoadImage(string imageName)
        {
            try
            {
                string imagePath = Path.Combine(ImagesFolder, imageName);

                if (File.Exists(imagePath))
                {
                    using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        return Image.FromStream(stream);
                    }
                }

                // If the image does not exist, return null
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải ảnh {imageName}: {ex.Message}");
                return null;
            }
        }

        // MEthod to load book cover by book ID
        public static Image LoadBookCoverById(string bookId)
        {
            // Try to load the image with possible extensions
            string[] extensions = { ".jpg", ".png", ".jpeg", ".gif" };

            foreach (string ext in extensions)
            {
                Image img = LoadImage($"{bookId}{ext}");
                if (img != null)
                {
                    return img;
                }
            }
            // If no image found, return default.jpg
            return LoadImage("default.jpg");
        }

        // Check and create resource directories
        public static bool EnsureResourceDirectories()
        {
            try
            {
                if (!Directory.Exists(ResourcesFolder))
                {
                    Directory.CreateDirectory(ResourcesFolder);
                }

                if (!Directory.Exists(ImagesFolder))
                {
                    Directory.CreateDirectory(ImagesFolder);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tạo thư mục tài nguyên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

