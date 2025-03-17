using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    // Thẻ sách đang mượn cải tiến với thiết kế giống giao diện web
    public class EnhancedBorrowedBookCard : Panel
    {
        private Book book;
        private PictureBox picCover;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblBorrowDate;
        private Label lblDueDate;
        private Button btnReturn;
        private Button btnDetails;

        public EnhancedBorrowedBookCard(Book book)
        {
            this.book = book;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.picCover = new PictureBox();
            this.lblTitle = new Label();
            this.lblAuthor = new Label();
            this.lblBorrowDate = new Label();
            this.lblDueDate = new Label();
            this.btnReturn = new Button();
            this.btnDetails = new Button();

            // BorrowedBookCard
            this.Size = new Size(840, 160);
            this.BorderStyle = BorderStyle.None;
            this.Margin = new Padding(15);
            this.BackColor = Color.White;
            this.Padding = new Padding(15);
            // Thêm đổ bóng cho thẻ sách đã mượn
            this.Paint += (sender, e) => {
                var panel = sender as Panel;
                var rect = new Rectangle(0, 0, panel.Width, panel.Height);
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddRoundedRectangle(rect, 10);
                    panel.Region = new Region(path);

                    // Vẽ đổ bóng
                    var shadowRect = new Rectangle(0, 0, panel.Width, panel.Height);
                    using (var brush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
                    {
                        e.Graphics.FillRoundedRectangle(brush, shadowRect, 10);
                    }

                    // Vẽ viền
                    using (var pen = new Pen(Color.FromArgb(229, 231, 235), 1))
                    {
                        e.Graphics.DrawRoundedRectangle(pen, rect, 10);
                    }
                }
            };

            // picCover
            this.picCover.Size = new Size(110, 130);
            this.picCover.Location = new Point(15, 15);
            this.picCover.BackColor = Color.FromArgb(243, 244, 246);
            this.picCover.SizeMode = PictureBoxSizeMode.Zoom;
            // Bo góc cho hình ảnh
            this.picCover.Paint += (sender, e) => {
                var pic = sender as PictureBox;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, 15, 15, 180, 90);
                path.AddArc(pic.Width - 15, 0, 15, 15, 270, 90);
                path.AddArc(pic.Width - 15, pic.Height - 15, 15, 15, 0, 90);
                path.AddArc(0, pic.Height - 15, 15, 15, 90, 90);
                pic.Region = new Region(path);
            };

            // lblTitle
            this.lblTitle.Text = book.Title;
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.Location = new Point(140, 15);
            this.lblTitle.Size = new Size(500, 25);
            this.lblTitle.ForeColor = Color.FromArgb(17, 24, 39);

            // lblAuthor
            this.lblAuthor.Text = book.Author;
            this.lblAuthor.Font = new Font("Segoe UI", 10);
            this.lblAuthor.Location = new Point(140, 45);
            this.lblAuthor.Size = new Size(500, 20);
            this.lblAuthor.ForeColor = Color.FromArgb(107, 114, 128);

            // Get borrow date and due date from user's borrow history
            string borrowDate = "";
            string dueDate = "";
            if (Library.Instance.CurrentUser != null && Library.Instance.CurrentUser.BorrowHistory != null)
            {
                BorrowHistory borrow = null;
                foreach (var b in Library.Instance.CurrentUser.BorrowHistory)
                {
                    if (b.Book.Id == book.Id && !b.Returned)
                    {
                        borrow = b;
                        break;
                    }
                }
                if (borrow != null)
                {
                    borrowDate = borrow.BorrowDate;
                    dueDate = borrow.DueDate;
                }
            }

            // lblBorrowDate
            this.lblBorrowDate.Text = $"Ngày mượn: {borrowDate}";
            this.lblBorrowDate.Font = new Font("Segoe UI", 10);
            this.lblBorrowDate.Location = new Point(140, 75);
            this.lblBorrowDate.Size = new Size(200, 20);
            this.lblBorrowDate.ForeColor = Color.FromArgb(107, 114, 128);

            // lblDueDate
            this.lblDueDate.Text = $"Hạn trả: {dueDate}";
            this.lblDueDate.Font = new Font("Segoe UI", 10);
            this.lblDueDate.Location = new Point(140, 100);
            this.lblDueDate.Size = new Size(200, 20);
            this.lblDueDate.ForeColor = Color.FromArgb(107, 114, 128);

            // Check if book is overdue
            try
            {
                DateTime dueDateValue = DateTime.ParseExact(dueDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (dueDateValue < DateTime.Now)
                {
                    this.lblDueDate.ForeColor = Color.Red;
                    this.lblDueDate.Font = new Font(this.lblDueDate.Font, FontStyle.Bold);
                }
            }
            catch { }

            // btnReturn
            this.btnReturn.Text = "Trả sách";
            this.btnReturn.Location = new Point(730, 65);
            this.btnReturn.Size = new Size(100, 35);
            this.btnReturn.FlatStyle = FlatStyle.Flat;
            this.btnReturn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnReturn.BackColor = Color.FromArgb(220, 38, 38);
            this.btnReturn.ForeColor = Color.White;
            this.btnReturn.Cursor = Cursors.Hand;
            this.btnReturn.Click += new EventHandler(this.btnReturn_Click);
            // Bo góc cho nút trả sách
            this.btnReturn.Paint += (sender, e) => {
                var button = sender as Button;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, 15, 15, 180, 90);
                path.AddArc(button.Width - 15, 0, 15, 15, 270, 90);
                path.AddArc(button.Width - 15, button.Height - 15, 15, 15, 0, 90);
                path.AddArc(0, button.Height - 15, 15, 15, 90, 90);
                button.Region = new Region(path);
            };

            // btnDetails
            this.btnDetails.Text = "Chi tiết";
            this.btnDetails.Location = new Point(620, 65);
            this.btnDetails.Size = new Size(100, 35);
            this.btnDetails.FlatStyle = FlatStyle.Flat;
            this.btnDetails.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnDetails.BackColor = Color.FromArgb(37, 99, 235);
            this.btnDetails.ForeColor = Color.White;
            this.btnDetails.Cursor = Cursors.Hand;
            this.btnDetails.Click += new EventHandler(this.btnDetails_Click);
            // Bo góc cho nút chi tiết
            this.btnDetails.Paint += (sender, e) => {
                var button = sender as Button;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, 15, 15, 180, 90);
                path.AddArc(button.Width - 15, 0, 15, 15, 270, 90);
                path.AddArc(button.Width - 15, button.Height - 15, 15, 15, 0, 90);
                path.AddArc(0, button.Height - 15, 15, 15, 90, 90);
                button.Region = new Region(path);
            };

            // Add controls
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnDetails);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn trả sách '{book.Title}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string message = Library.Instance.CurrentUser.ReturnBook(book);
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Save data to the system
                Library.Instance.SaveData();

                // Refresh the parent panel
                if (this.Parent is FlowLayoutPanel && this.Parent.Parent is MyBooksPanel)
                {
                    ((MyBooksPanel)this.Parent.Parent).LoadBorrowedBooks();
                }

                // Update the book list
                if (Application.OpenForms["MainForm"] is MainForm mainForm)
                {
                    mainForm.UpdateAllPanels();
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            BookDetailForm detailForm = new BookDetailForm(book);
            detailForm.ShowDialog();
        }
    }
}

