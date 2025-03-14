using System;

namespace LibraryManagementSystem
{
    [Serializable]
    public class BorrowHistory
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
        {
            this.id = id;
            this.book = book;
            this.borrowDate = borrowDate;
            this.dueDate = dueDate;
            this.returned = returned;
            this.returnDate = returnDate;
        }
    }
}