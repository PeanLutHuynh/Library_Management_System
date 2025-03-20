using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    [Serializable]
    public class User
    {
        // Fields
        private string id;
        private string name;
        private string email;
        private string password;
        private string phone;
        private string address;
        private string memberSince;
        private List<BorrowHistory> borrowHistory;
        private List<BorrowHistory> currentlyBorrowedBooks; // List of books that are currently borrowed

        // Properties
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string MemberSince
        {
            get { return memberSince; }
            set { memberSince = value; }
        }

        public List<BorrowHistory> BorrowHistory
        {
            get { return borrowHistory; }
            set { borrowHistory = value; }
        }

        public List<BorrowHistory> CurrentlyBorrowedBooks
        {
            get { return currentlyBorrowedBooks; }
            set { currentlyBorrowedBooks = value; }
        }

        // Constructor
        public User(string id, string name, string email, string password, string phone, string address)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.address = address;
            this.memberSince = DateTime.Now.ToString("dd/MM/yyyy");
            this.borrowHistory = new List<BorrowHistory>();
            this.currentlyBorrowedBooks = new List<BorrowHistory>();

        }

        // Method to borrow a book
        public string BorrowBook(Book book, DateTime borrowDate, DateTime returnDate)
        {
            if (!book.Available)
            {
                return "Sách này hiện không có sẵn để mượn.";
            }

            // Create a new BorrowHistory object
            BorrowHistory borrow = new BorrowHistory(
                Guid.NewGuid().ToString(),
                book,
                borrowDate.ToString("dd/MM/yyyy"),
                returnDate.ToString("dd/MM/yyyy"),
                false,
                null
            );

            // Add to borrow history
            borrowHistory.Add(borrow);
            // Add to currently borrowed books
            currentlyBorrowedBooks.Add(borrow);

            // Update book status
            book.Available = false;
            book.DueDate = returnDate;
            book.BorrowCount++;

            // Notify Library of the change (Observer pattern)
            Library.Instance.NotifyBookChanged(book);

            // Update UI
            if (MainForm.FormManager.MainForm != null)
            {
                MainForm.FormManager.MainForm.Invoke((MethodInvoker)delegate
                {
                    MainForm.FormManager.MainForm.UpdateAllPanels();
                });
            }

            // Save data
            Library.Instance.SaveData();

            string result = $"Đã mượn thành công: {book.Title}\n";
            //result += $"Ngày mượn: {borrowDate.ToString("dd/MM/yyyy")}, Hạn trả: {returnDate.ToString("dd/MM/yyyy")}";
            return result;
        }

        public void RestoreBorrowedBooks()
        {
            CurrentlyBorrowedBooks = new List<BorrowHistory>();

            foreach (BorrowHistory borrow in BorrowHistory)
            {
                if (!borrow.Returned)
                {
                    Book actualBook = Library.Instance.FindBook(borrow.Book.Id);
                    if (actualBook != null)
                    {
                        borrow.Book = actualBook;
                        actualBook.Available = false; // Mark the book as borrowed

                        // Handle due date
                        if (DateTime.TryParseExact(borrow.DueDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
                        {
                            actualBook.DueDate = dueDate;
                        }
                        else
                        {
                            actualBook.DueDate = DateTime.Now.AddDays(7); // Default due date is 7 days from now
                        }

                        CurrentlyBorrowedBooks.Add(borrow);
                    }
                }
            }
        }

        // Method to return a book
        public string ReturnBook(Book book)
        {
            BorrowHistory borrow = null;
            foreach (BorrowHistory b in BorrowHistory)
            {
                if (b.Book.Id == book.Id && !b.Returned)
                {
                    borrow = b;
                    break;
                }
            }
            if (borrow == null)
            {
                return "Không tìm thấy thông tin mượn cho sách này.";
            }

            // Update borrow history
            borrow.ReturnDate = DateTime.Now.ToString("dd/MM/yyyy");
            borrow.Returned = true;

            // Remove from currently borrowed books
            currentlyBorrowedBooks.Remove(borrow);

            // Update book status
            Book actualBook = Library.Instance.FindBook(book.Id);
            if (actualBook != null)
            {
                actualBook.Available = true;
                actualBook.DueDate = null;
            }

            // Remove from currently borrowed books
            CurrentlyBorrowedBooks.Remove(borrow);

            // Update Book Status
            book.Available = true;
            book.DueDate = null;

            // Notify Library of the change (Observer pattern)
            Library.Instance.NotifyBookChanged(book);

            // Update UI
            if (MainForm.FormManager.MainForm != null)
            {
                MainForm.FormManager.MainForm.Invoke((MethodInvoker)delegate
                {
                    MainForm.FormManager.MainForm.UpdateAllPanels();
                });
            }

            // Save data
            Library.Instance.SaveData();

            // Estimate physical return deadline
            DateTime physicalReturnDeadline = DateTime.Now.AddDays(7);
            string result = $"Đã xác nhận trả sách thành công: {book.Title}\n\n";
            result += $"Vui lòng mang sách đến thư viện trong vòng 7 ngày (trước ngày {physicalReturnDeadline.ToString("dd/MM/yyyy")}).";

            return result;
        }
    }
}