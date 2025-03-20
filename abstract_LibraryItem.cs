using System;

namespace LibraryManagementSystem
{
    public abstract class LibraryItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre;
        public string Publisher;
        public int Pages;
        public string Description;
        public bool Available;
        public int BorrowCount;

        public LibraryItem(string id, string title, string author, int year, string genre, string publisher, int pages, string description, int borrowCount)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            Pages = pages;
            Description = description;
            Available = true;
            BorrowCount = borrowCount;
        }

        public abstract void DisplayInfo();
    }
}
