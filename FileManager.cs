using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                LibraryData libraryData = new LibraryData
                {
                    Books = library.Books,
                    Users = library.Users,
                    //CurrentlyBorrowedBooks = library.CurrentUser?.CurrentlyBorrowedBooks ?? new List<BorrowHistory>() // Thêm dòng này
                };
                string jsonString = JsonSerializer.Serialize(library, new JsonSerializerOptions { WriteIndented = true });
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
                LibraryData libraryData = JsonSerializer.Deserialize<LibraryData>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (libraryData != null)
                {
                    // Cập nhật dữ liệu vào instance hiện tại
                    Library.Instance.Books = libraryData.Books;
                    Library.Instance.Users = libraryData.Users;

                    if (libraryData.CurrentUser != null)
                    {
                        // Tìm user có trong danh sách Users thay vì sử dụng trực tiếp CurrentUser từ JSON
                        User savedUser = Library.Instance.Users.FirstOrDefault(u => u.Email == libraryData.CurrentUser.Email);
                        if (savedUser != null)
                        {
                            Library.Instance.CurrentUser = savedUser;
                            savedUser.RestoreBorrowedBooks(); // GỌI HÀM Ở ĐÂY
                        }
                    }
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
            public List<BorrowHistory> CurrentlyBorrowedBooks { get; set; }
        }

    }
}