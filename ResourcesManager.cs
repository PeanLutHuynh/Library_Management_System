using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public static class ResourceManager
    {
        // Thư mục chứa tài nguyên
        private static readonly string ResourcesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
        private static readonly string ImagesFolder = Path.Combine(ResourcesFolder, "Images");

        // Phương thức tải ảnh từ thư mục Resources/Images
        public static Image LoadImage(string imageName)
        {
            try
            {
                string imagePath = Path.Combine(ImagesFolder, imageName);

                if (File.Exists(imagePath))
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        return Image.FromStream(stream);
                    }
                }

                // Nếu không tìm thấy ảnh, trả về null
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải ảnh {imageName}: {ex.Message}");
                return null;
            }
        }

        // Phương thức tải ảnh bìa sách theo ID
        public static Image LoadBookCoverById(string bookId)
        {
            // Thử tải ảnh với các định dạng phổ biến
            string[] extensions = { ".jpg", ".png", ".jpeg", ".gif" };

            foreach (string ext in extensions)
            {
                Image img = LoadImage($"{bookId}{ext}");
                if (img != null)
                {
                    return img;
                }
            }

            // Nếu không tìm thấy, trả về ảnh mặc định
            return LoadImage("default.jpg");
        }

        // Kiểm tra xem thư mục Resources/Images có tồn tại không
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

