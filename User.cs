using System;
using System.Collections.Generic;

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
        }

        // Method to borrow a book
        public string BorrowBook(Book book, DateTime borrowDate, DateTime returnDate)
        {
            if (!book.Available)
            {
                return "Sách này hiện không có sẵn để mượn.";
            }

            DateTime pickupDeadline = DateTime.Now.AddDays(7); // Thời hạn để lấy sách (7 ngày)
            DateTime systemReturnDeadline = DateTime.Now.AddDays(30); // Thời hạn xác nhận trả trên hệ thống (30 ngày)

            BorrowHistory borrow = new BorrowHistory(
                Guid.NewGuid().ToString(),
                book,
                borrowDate.ToString("dd/MM/yyyy"),
                returnDate.ToString("dd/MM/yyyy"),
                false,
                null
            );

            borrowHistory.Add(borrow);
            book.Available = false;
            book.DueDate = returnDate;
            book.BorrowCount++;

            // Thông báo sự thay đổi cho Library (Observer pattern)
            Library.Instance.NotifyBookChanged(book);

            string result = $"Đã mượn thành công: {book.Title}\n";
            //result += $"Vui lòng đến thư viện đúng ngày {pickupDeadline.ToString("dd/MM/yyyy")} để lấy sách.\n";

            return result;
        }

        // Method to return a book
        public string ReturnBook(Book book)
        {
            BorrowHistory borrow = null;

            foreach (BorrowHistory b in borrowHistory)
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

            borrow.ReturnDate = DateTime.Now.ToString();
            borrow.Returned = true;
            book.Available = true;
            book.DueDate = null;

            // Thông báo sự thay đổi cho Library (Observer pattern)
            Library.Instance.NotifyBookChanged(book);

            // Tính ngày hạn chót để trả sách (7 ngày từ hôm nay)
            DateTime physicalReturnDeadline = DateTime.Now.AddDays(7);
            string result = $"Đã xác nhận trả sách thành công: {book.Title}\n\n";
            result += $"Vui lòng mang sách đến thư viện trong vòng 7 ngày (trước ngày {physicalReturnDeadline.ToString("dd/MM/yyyy")}).";

            return result;
        }
    }
}