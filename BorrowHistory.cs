using System;

namespace LibraryManagementSystem
{
    [Serializable]
    public class BorrowHistory : LibraryItem
    {
        // Fields
        private string id;
        private Book book;
        private string borrowDate;
        private string dueDate;
        private bool returned;
        private string returnDate;
        
        // Properties
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public Book Book
        {
            get { return book; }
            set { book = value; }
        }

        public string BorrowDate
        {
            get { return borrowDate; }
            set { borrowDate = value; }
        }

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public bool Returned
        {
            get { return returned; }
            set { returned = value; }
        }

        public string ReturnDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }

        // Constructor
        public BorrowHistory(string id, Book book, string borrowDate, string dueDate, bool returned, string returnDate)
            : base(id, book.Title, book.Author, book.Year, book.Genre, book.Publisher, book.Pages, book.Description, book.BorrowCount)
        {
            this.id = id;
            this.book = book;
            this.borrowDate = borrowDate;
            this.dueDate = dueDate;
            this.returned = returned;
            this.returnDate = returnDate;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Borrow History ID: " + Id);
            Console.WriteLine("Book Title: " + Book.Title);
            Console.WriteLine("Borrow Date: " + BorrowDate);
            Console.WriteLine("Due Date: " + DueDate);
            Console.WriteLine("Returned: " + Returned);
            Console.WriteLine("Return Date: " + ReturnDate);
        }
    }
}