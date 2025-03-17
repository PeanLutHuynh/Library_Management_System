using System;
using System.IO;

namespace LibraryManagementSystem
{
    [Serializable]
    public class Book
    {
        // Fields
        private string id;
        private string title;
        private string author;
        private int year;
        private string genre;
        private string publisher;
        private int pages;
        private string description;
        private bool available;
        private DateTime? dueDate;
        private int borrowCount;
        private string coverImage;

        // Properties
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public int Pages
        {
            get { return pages; }
            set { pages = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        public DateTime? DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public int BorrowCount
        {
            get { return borrowCount; }
            set { borrowCount = value; }
        }

        public string CoverImage
        {
            get { return coverImage; }
            set { coverImage = value; }
        }

        // Phương thức để tải ảnh bìa sách từ thư mục Resources/Images
        public void LoadCoverImage()
        {
            if (string.IsNullOrEmpty(this.coverImage))
            {
                // Tìm ảnh trong thư mục Resources/Images
                string[] possibleExtensions = { ".jpg", ".png", ".jpeg", ".gif" };

                foreach (string ext in possibleExtensions)
                {
                    // Đường dẫn tương đối từ thư mục thực thi
                    string relativePath = Path.Combine("Resources", "Images", $"{this.id}{ext}");
                    string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

                    if (File.Exists(absolutePath))
                    {
                        this.coverImage = absolutePath;
                        return;
                    }
                }

                // Nếu không tìm thấy ảnh với ID, thử tìm ảnh mặc định
                string defaultImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "default.jpg");
                if (File.Exists(defaultImagePath))
                {
                    this.coverImage = defaultImagePath;
                }
            }
        }

        // Constructor
        public Book(string id, string title, string author, int year, string genre, string publisher, int pages, string description, int borrowCount = 0)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.year = year;
            this.genre = genre;
            this.publisher = publisher;
            this.pages = pages;
            this.description = description;
            this.available = true;
            this.dueDate = null;
            this.borrowCount = borrowCount;
            this.coverImage = null;
        }

        // Default constructor for serialization
        public Book()
        {
            this.id = "";
            this.title = "";
            this.author = "";
            this.year = 0;
            this.genre = "";
            this.publisher = "";
            this.pages = 0;
            this.description = "";
            this.available = true;
            this.dueDate = null;
            this.borrowCount = 0;
            this.coverImage = null;
        }
    }
}
