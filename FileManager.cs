using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    // Singleton Pattern
    public class FileManager
    {
        // Singleton instance
        private static FileManager instance;

        // Private constructor (Singleton pattern)
        private FileManager()
        {
        }

        // Singleton instance property
        public static FileManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileManager();
                }
                return instance;
            }
        }

        // Method to serialize library object to file
        public void SerializeLibrary(Library library, string filePath)
        {
            try
            {
                // Tạo một bản sao của thư viện để tránh lưu đường dẫn tuyệt đối
                LibraryData libraryData = new LibraryData
                {
                    Books = library.Books,
                    Users = library.Users,
                    CurrentUser = library.CurrentUser
                };

                // Xóa đường dẫn ảnh tuyệt đối trước khi lưu
                foreach (var book in libraryData.Books)
                {
                    // Lưu chỉ tên file thay vì đường dẫn đầy đủ
                    if (!string.IsNullOrEmpty(book.CoverImage))
                    {
                        book.CoverImage = Path.GetFileName(book.CoverImage);
                    }
                }

                string jsonString = JsonSerializer.Serialize(libraryData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to deserialize library object from file
        public Library DeserializeLibrary(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);

                // Tạo một lớp tạm để deserialize dữ liệu
                var libraryData = JsonSerializer.Deserialize<LibraryData>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (libraryData != null)
                {
                    // Đặt lại trạng thái của tất cả sách thành true trước
                    foreach (Book book in libraryData.Books)
                    {
                        book.Available = true;
                        book.DueDate = null;
                    }

                    // Cập nhật dữ liệu vào instance hiện tại
                    Library.Instance.Books = libraryData.Books;
                    Library.Instance.Users = libraryData.Users;
                    Library.Instance.CurrentUser = libraryData.CurrentUser;

                    // Khôi phục mối quan hệ giữa Book trong BorrowHistory và Book trong danh sách Books
                    if (Library.Instance.Users != null)
                    {
                        foreach (User user in Library.Instance.Users)
                        {
                            if (user.BorrowHistory != null)
                            {
                                foreach (BorrowHistory borrow in user.BorrowHistory)
                                {
                                    if (borrow != null && borrow.Book != null)
                                    {
                                        // Tìm sách tương ứng trong danh sách Books
                                        Book actualBook = Library.Instance.FindBook(borrow.Book.Id);
                                        if (actualBook != null)
                                        {
                                            // Cập nhật tham chiếu Book trong BorrowHistory
                                            borrow.Book = actualBook;

                                            // Cập nhật trạng thái của sách nếu đang được mượn
                                            if (!borrow.Returned)
                                            {
                                                actualBook.Available = false;
                                                try
                                                {
                                                    actualBook.DueDate = DateTime.Parse(borrow.DueDate, new System.Globalization.CultureInfo("vi-VN"));
                                                }
                                                catch
                                                {
                                                    // Nếu không parse được ngày, sử dụng ngày mặc định
                                                    actualBook.DueDate = DateTime.Now.AddDays(7);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Tải ảnh bìa sách cho tất cả sách
                foreach (var book in Library.Instance.Books)
                {
                    book.LoadCoverImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Library.Instance;
        }

        // Lớp tạm để deserialize dữ liệu
        [Serializable]
        public class LibraryData
        {
            public List<Book> Books { get; set; }
            public List<User> Users { get; set; }
            public User CurrentUser { get; set; }
        }
    }
}

