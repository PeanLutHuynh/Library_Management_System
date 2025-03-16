using System;

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
        private int borrowCount;
        private string coverImage;
        private DateTime? dueDate;
        
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

        public int BorrowCount
        {
            get { return borrowCount; }
            set { borrowCount = value; }
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

        public string CoverImage
        {
            get { return coverImage; }
            set { coverImage = value; }
        }

        public DateTime? DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        // Constructor
        public Book(string id, string title, string author, int year, string genre, string publisher, int pages, int borrowCount, string description)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.year = year;
            this.genre = genre;
            this.publisher = publisher;
            this.pages = pages;
            this.borrowCount = borrowCount;
            this.description = description;
            this.available = true;
            this.coverImage = null;
            this.dueDate = null;
        }
    }
}