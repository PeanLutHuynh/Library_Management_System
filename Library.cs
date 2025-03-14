﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem
{
    // Singleton Pattern
    [Serializable]
    public class Library
    {
        // Singleton instance
        private static Library instance;

        // Observer Pattern - Delegates and Events
        public delegate void BookChangedEventHandler(Book book);
        public event BookChangedEventHandler BookChanged;

        // Fields
        private List<Book> books;
        private List<User> users;
        private User currentUser;

        // Properties
        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }

        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        // Private constructor (Singleton pattern)
        private Library()
        {
            this.books = new List<Book>();
            this.users = new List<User>();
            this.currentUser = null;
        }


        // Singleton instance property
        public static Library Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Library();
                }
                return instance;
            }
        }

        // Method to set the instance (used for deserialization)
        public static void SetInstance(Library library)
        {
            instance = library;
        }

        // Method to initialize the library with sample data
        public void Initialize()
        {
            // Tải dữ liệu từ file nếu có
            if (System.IO.File.Exists("library.json"))
            {
                Library loadedLibrary = FileManager.Instance.DeserializeLibrary("library.json");
                if (loadedLibrary != null)
                {
                    this.books = loadedLibrary.Books;
                    this.users = loadedLibrary.Users;
                }
            }
            else
            {
                // Thêm một số dữ liệu mẫu
                AddBook(new Book("1", "Đắc Nhân Tâm", "Dale Carnegie", 1936, "Tâm lý - Kỹ năng sống", "NXB Tổng hợp TP.HCM", 320,
                    "Đắc nhân tâm (How to Win Friends and Influence People) là một quyển sách nhằm tự giúp bản thân (self-help) bán chạy nhất từ trước đến nay. Tác phẩm đã được chuyển ngữ sang hầu hết các thứ tiếng trên thế giới và có mặt ở hàng trăm quốc gia."));

                AddBook(new Book("2", "Nhà Giả Kim", "Paulo Coelho", 1988, "Tiểu thuyết", "NXB Văn học", 224,
                    "Nhà giả kim là cuốn sách được xuất bản lần đầu ở Brasil năm 1988, và là cuốn sách nổi tiếng nhất của nhà văn Paulo Coelho. Tác phẩm đã được dịch ra 67 ngôn ngữ và bán ra tới 95 triệu bản."));

                AddBook(new Book("3", "Tôi Tài Giỏi, Bạn Cũng Thế", "Adam Khoo", 2008, "Kỹ năng sống", "NXB Trẻ", 304,
                    "Tôi Tài Giỏi, Bạn Cũng Thế là cuốn sách giúp bạn khám phá ra tiềm năng thực sự của bản thân để thành công trong học tập và cuộc sống."));

                AddBook(new Book("4", "Tuổi Trẻ Đáng Giá Bao Nhiêu", "Rosie Nguyễn", 2016, "Tùy bút", "NXB Hội Nhà Văn", 285,
                    "Tuổi Trẻ Đáng Giá Bao Nhiêu là tác phẩm đầu tay của tác giả Rosie Nguyễn, là tập hợp những bài viết của cô về những trải nghiệm trong cuộc sống, những chuyến đi, những suy ngẫm về tình yêu, hạnh phúc, thành công, v.v."));

                AddBook(new Book("5", "Cà Phê Cùng Tony", "Tony Buổi Sáng", 2014, "Tùy bút", "NXB Trẻ", 268,
                    "Cà Phê Cùng Tony là tập hợp những bài viết được yêu thích trên Facebook của tác giả Tony Buổi Sáng. Đây là cuốn sách dành cho những người trẻ, những người đang tìm kiếm, khát khao một cuộc sống tốt đẹp hơn."));

                AddBook(new Book("6", "Người Giàu Có Nhất Thành Babylon", "George S. Clason", 1926, "Kinh tế", "NXB Tổng hợp TP.HCM", 208,
                    "Người giàu có nhất thành Babylon là một cuốn sách kinh điển về tài chính cá nhân. Cuốn sách kể về cách làm giàu của người dân vùng Babylon cổ đại."));

                AddBook(new Book("7", "Đời Ngắn Đừng Ngủ Dài", "Robin Sharma", 2011, "Kỹ năng sống", "NXB Trẻ", 228,
                    "Đời Ngắn Đừng Ngủ Dài là cuốn sách của Robin Sharma, một tác giả chuyên viết về đề tài lãnh đạo và phát triển cá nhân. Cuốn sách này đưa ra những lời khuyên để sống một cuộc đời trọn vẹn và ý nghĩa."));

                AddBook(new Book("8", "Hành Trình Về Phương Đông", "Baird T. Spalding", 1924, "Tâm linh", "NXB Hồng Đức", 256,
                    "Hành Trình Về Phương Đông kể về những trải nghiệm của một đoàn khoa học gồm các chuyên gia hàng đầu của Hội Khoa Học Hoàng Gia Anh được cử sang Ấn Độ và Tây Tạng để tìm hiểu về những khả năng siêu nhiên của con người."));

                // Thêm người dùng mẫu
                AddUser(new User("1", "Nguyễn Văn A", "nguyenvana@example.com", "0123456789", "Hà Nội, Việt Nam"));
            }
        }

        // Method to notify observers about book changes
        public void NotifyBookChanged(Book book)
        {
            BookChanged?.Invoke(book);
        }

        // Method to add a book
        public void AddBook(Book book)
        {
            books.Add(book);
            NotifyBookChanged(book);
        }

        // Method to remove a book
        public void RemoveBook(string bookId)
        {
            Book bookToRemove = null;

            foreach (Book book in books)
            {
                if (book.Id == bookId)
                {
                    bookToRemove = book;
                    break;
                }
            }

            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                NotifyBookChanged(bookToRemove);
            }
        }

        // Method to find a book
        public Book FindBook(string bookId)
        {
            foreach (Book book in books)
            {
                if (book.Id == bookId)
                {
                    return book;
                }
            }

            return null;
        }

        // Method to add a user
        public void AddUser(User user)
        {
            users.Add(user);
        }

        // Method to find a user
        public User FindUser(string email, string password)
        {
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    // Trong thực tế, cần kiểm tra mật khẩu đã hash
                    return user;
                }
            }

            return null;
        }

        // Method to get all available books
        public List<Book> GetAvailableBooks()
        {
            List<Book> availableBooks = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Available)
                {
                    availableBooks.Add(book);
                }
            }

            return availableBooks;
        }

        // Method to get borrowed books
        public List<Book> GetBorrowedBooks()
        {
            List<Book> borrowedBooks = new List<Book>();

            if (currentUser != null)
            {
                foreach (BorrowHistory borrow in currentUser.BorrowHistory)
                {
                    if (!borrow.Returned)
                    {
                        borrowedBooks.Add(borrow.Book);
                    }
                }
            }

            return borrowedBooks;
        }

        // Method to get most borrowed books
        public List<Book> GetMostBorrowedBooks(int limit)
        {
            List<Book> sortedBooks = new List<Book>(books);
            sortedBooks.Sort((a, b) => b.BorrowCount.CompareTo(a.BorrowCount));

            List<Book> result = new List<Book>();
            int count = 0;

            foreach (Book book in sortedBooks)
            {
                if (count < limit)
                {
                    result.Add(book);
                    count++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        // Method to search books
        public List<Book> SearchBooks(string query)
        {
            List<Book> results = new List<Book>();
            string lowercaseQuery = query.ToLower();

            foreach (Book book in books)
            {
                if (book.Title.ToLower().Contains(lowercaseQuery) ||
                    book.Author.ToLower().Contains(lowercaseQuery) ||
                    book.Genre.ToLower().Contains(lowercaseQuery))
                {
                    results.Add(book);
                }
            }

            return results;
        }

        // Method to save the library data
        public void SaveData()
        {
            FileManager.Instance.SerializeLibrary(this, "library.json");
        }
    }
}