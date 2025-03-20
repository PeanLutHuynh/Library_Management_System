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
                // Create a temporary class to serialize data
                LibraryData libraryData = new LibraryData
                {
                    Books = library.Books,
                    Users = library.Users,
                    CurrentUser = library.CurrentUser
                };

                // Delete the cover image path to save only the file name
                foreach (Book book in libraryData.Books)
                {
                    // Save only the file name of the cover image
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

                // Create a temporary class to deserialize data
                LibraryData libraryData = JsonSerializer.Deserialize<LibraryData>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (libraryData != null)
                {
                    // Update the cover image path to the full path
                    Library.Instance.Books = libraryData.Books;
                    Library.Instance.Users = libraryData.Users;

                    // Reset the availability of all books
                    foreach (Book book in libraryData.Books)
                    {
                        book.Available = true;
                        book.DueDate = null;
                    }

                    // Restore borrowed books for the current user
                    if (libraryData.CurrentUser != null)
                    {
                        // Find the saved user in the current list of users
                        User savedUser = null;
                        foreach (User user in Library.Instance.Users)
                        {
                            if (user.Email == libraryData.CurrentUser.Email)
                            {
                                savedUser = user;
                                break;
                            }
                        }

                        if (savedUser != null)
                        {
                            Library.Instance.CurrentUser = savedUser;
                            savedUser.RestoreBorrowedBooks();
                        }
                    }
                }

                // Load cover images
                foreach (Book book in Library.Instance.Books)
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

        // Temporary class to serialize/deserialize library data
        [Serializable]
        public class LibraryData
        {
            public List<Book> Books { get; set; }
            public List<User> Users { get; set; }
            public User CurrentUser { get; set; }
        }
    }
}

