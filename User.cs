using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<BorrowHistory> currentlyBorrowedBooks; // Chỉ chứa sách đang mượn

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

            // Tạo một bản ghi mượn sách mới
            BorrowHistory borrow = new BorrowHistory(
                Guid.NewGuid().ToString(),
                book,
                borrowDate.ToString("dd/MM/yyyy"),
                returnDate.ToString("dd/MM/yyyy"),
                false,
                null
            );

            // Thêm vào lịch sử mượn sách của người dùng
            borrowHistory.Add(borrow);
            // Thêm vào danh sách sách đang mượn
            currentlyBorrowedBooks.Add(borrow);

            // Cập nhật trạng thái sách
            book.Available = false;
            book.DueDate = returnDate;
            book.BorrowCount++;

            // Thông báo sự thay đổi cho Library (Observer pattern)
            Library.Instance.NotifyBookChanged(book);

            // Cập nhật giao diện
            if (MainForm.FormManager.MainForm != null)
            {
                MainForm.FormManager.MainForm.Invoke((MethodInvoker)delegate
                {
                    MainForm.FormManager.MainForm.UpdateAllPanels();
                });
            }

            // Lưu dữ liệu
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
                        actualBook.Available = false; // Đánh dấu sách đã được mượn

                        // Xử lý lỗi DateTime nếu dữ liệu không hợp lệ
                        if (DateTime.TryParseExact(borrow.DueDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
                        {
                            actualBook.DueDate = dueDate;
                        }
                        else
                        {
                            actualBook.DueDate = DateTime.Now.AddDays(7); // Mặc định hạn trả là 7 ngày
                        }

                        CurrentlyBorrowedBooks.Add(borrow);
                    }
                }
            }
        }


        // Method to return a book
        public string ReturnBook(Book book)
        {
            BorrowHistory borrow = BorrowHistory.FirstOrDefault(b => b.Book.Id == book.Id && !b.Returned);
            if (borrow == null)
            {
                return "Không tìm thấy thông tin mượn cho sách này.";
            }

            // Cập nhật thông tin trả sách
            borrow.ReturnDate = DateTime.Now.ToString("dd/MM/yyyy");
            borrow.Returned = true;

            // Xóa khỏi danh sách sách đang mượn
            currentlyBorrowedBooks.Remove(borrow);

            // Cập nhật trạng thái của sách trong danh sách Books
            Book actualBook = Library.Instance.FindBook(book.Id);
            if (actualBook != null)
            {
                actualBook.Available = true;
                actualBook.DueDate = null;
            }

            // Xóa khỏi danh sách sách đang mượn
            CurrentlyBorrowedBooks.Remove(borrow);

            // Cập nhật trạng thái của sách trong BorrowHistory
            book.Available = true;
            book.DueDate = null;

            // Thông báo sự thay đổi cho Library (Observer pattern)
            Library.Instance.NotifyBookChanged(book);

            // Cập nhật giao diện
            if (MainForm.FormManager.MainForm != null)
            {
                MainForm.FormManager.MainForm.Invoke((MethodInvoker)delegate
                {
                    MainForm.FormManager.MainForm.UpdateAllPanels();
                });
            }

            // Lưu dữ liệu
            Library.Instance.SaveData();

            // Tính ngày hạn chót để trả sách (7 ngày từ hôm nay)
            DateTime physicalReturnDeadline = DateTime.Now.AddDays(7);
            string result = $"Đã xác nhận trả sách thành công: {book.Title}\n\n";
            result += $"Vui lòng mang sách đến thư viện trong vòng 7 ngày (trước ngày {physicalReturnDeadline.ToString("dd/MM/yyyy")}).";

            return result;
        }
    }
}