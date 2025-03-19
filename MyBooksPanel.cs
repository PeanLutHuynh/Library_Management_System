using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public class MyBooksPanel : Panel
    {
        private Label lblTitle;
        private Label lblSubtitle;
        private FlowLayoutPanel borrowedBooksPanel;

        public MyBooksPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.borrowedBooksPanel = new FlowLayoutPanel();

            // lblTitle
            this.lblTitle.Text = "Sách của tôi";
            this.lblTitle.Font = new Font("Arial", 24, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(400, 40);

            // lblSubtitle
            this.lblSubtitle.Text = "Quản lý sách bạn đang mượn";
            this.lblSubtitle.Font = new Font("Arial", 10);
            this.lblSubtitle.ForeColor = Color.Gray;
            this.lblSubtitle.Location = new Point(20, 70);
            this.lblSubtitle.Size = new Size(400, 20);

            // borrowedBooksPanel
            this.borrowedBooksPanel.Location = new Point(20, 90);
            this.borrowedBooksPanel.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 110);
            this.borrowedBooksPanel.AutoScroll = true;
            this.borrowedBooksPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.borrowedBooksPanel.Padding = new Padding(0, 0, 20, 0); // Add right padding for scrollbar

            // MyBooksPanel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.borrowedBooksPanel);
        }

        public void LoadBorrowedBooks()
        {
            borrowedBooksPanel.Controls.Clear();

            List<Book> borrowedBooks = Library.Instance.GetBorrowedBooks();

            if (borrowedBooks.Count == 0)
            {
                Label lblNoBooks = new Label();
                lblNoBooks.Text = "Bạn chưa mượn sách nào";
                lblNoBooks.Font = new Font("Arial", 12);
                lblNoBooks.Location = new Point(0, 0);
                lblNoBooks.Size = new Size(400, 30);
                lblNoBooks.TextAlign = ContentAlignment.MiddleCenter;
                borrowedBooksPanel.Controls.Add(lblNoBooks);
            }
            else
            {
                foreach (Book book in borrowedBooks)
                {
                    EnhancedBorrowedBookCard bookCard = new EnhancedBorrowedBookCard(book);
                    borrowedBooksPanel.Controls.Add(bookCard);
                }
            }
        }
    }
}