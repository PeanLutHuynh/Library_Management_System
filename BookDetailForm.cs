using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public class BookDetailForm : Form
    {
        private Book book;
        private PictureBox picCover;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblGenre;
        private Label lblPublisher;
        private Label lblYear;
        private Label lblPages;
        private Label lblDescription;
        private Label lblStatus;
        private Button btnBorrow;
        private Button btnClose;

        public BookDetailForm(Book book)
        {
            this.book = book;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.picCover = new PictureBox();
            this.lblTitle = new Label();
            this.lblAuthor = new Label();
            this.lblGenre = new Label();
            this.lblPublisher = new Label();
            this.lblYear = new Label();
            this.lblPages = new Label();
            this.lblDescription = new Label();
            this.lblStatus = new Label();
            this.btnBorrow = new Button();
            this.btnClose = new Button();

            // BookDetailForm
            this.ClientSize = new Size(800, 550);
            this.Text = "Chi tiết sách";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Padding = new Padding(30);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // picCover
            this.picCover.Size = new Size(220, 300);
            this.picCover.Location = new Point(30, 30);
            this.picCover.BackColor = Color.FromArgb(243, 244, 246);
            this.picCover.SizeMode = PictureBoxSizeMode.Zoom;
            // Bo góc cho hình ảnh
            this.picCover.Paint += (sender, e) => {
                var pic = sender as PictureBox;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(pic.Width - 20, 0, 20, 20, 270, 90);
                path.AddArc(pic.Width - 20, pic.Height - 20, 20, 20, 0, 90);
                path.AddArc(0, pic.Height - 20, 20, 20, 90, 90);
                pic.Region = new Region(path);
            };

            // lblTitle
            this.lblTitle.Text = book.Title;
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.Location = new Point(280, 30);
            this.lblTitle.Size = new Size(490, 40);
            this.lblTitle.ForeColor = Color.FromArgb(17, 24, 39);

            // lblAuthor
            this.lblAuthor.Text = "Tác giả: " + book.Author;
            this.lblAuthor.Font = new Font("Segoe UI", 12);
            this.lblAuthor.Location = new Point(280, 80);
            this.lblAuthor.Size = new Size(490, 25);
            this.lblAuthor.ForeColor = Color.FromArgb(75, 85, 99);

            // lblGenre
            this.lblGenre.Text = "Thể loại: " + book.Genre;
            this.lblGenre.Font = new Font("Segoe UI", 12);
            this.lblGenre.Location = new Point(280, 115);
            this.lblGenre.Size = new Size(490, 25);
            this.lblGenre.ForeColor = Color.FromArgb(75, 85, 99);

            // lblPublisher
            this.lblPublisher.Text = "Nhà xuất bản: " + book.Publisher;
            this.lblPublisher.Font = new Font("Segoe UI", 12);
            this.lblPublisher.Location = new Point(280, 150);
            this.lblPublisher.Size = new Size(490, 25);
            this.lblPublisher.ForeColor = Color.FromArgb(75, 85, 99);

            // lblYear
            this.lblYear.Text = "Năm xuất bản: " + book.Year.ToString();
            this.lblYear.Font = new Font("Segoe UI", 12);
            this.lblYear.Location = new Point(280, 185);
            this.lblYear.Size = new Size(490, 25);
            this.lblYear.ForeColor = Color.FromArgb(75, 85, 99);

            // lblPages
            this.lblPages.Text = "Số trang: " + book.Pages.ToString();
            this.lblPages.Font = new Font("Segoe UI", 12);
            this.lblPages.Location = new Point(280, 220);
            this.lblPages.Size = new Size(490, 25);
            this.lblPages.ForeColor = Color.FromArgb(75, 85, 99);

            // lblStatus
            this.lblStatus.Text = "Trạng thái: " + (book.Available ? "Có sẵn" : "Đã mượn");
            this.lblStatus.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblStatus.ForeColor = book.Available ? Color.Green : Color.Red;
            this.lblStatus.Location = new Point(280, 255);
            this.lblStatus.Size = new Size(490, 25);

            // lblDescription
            this.lblDescription.Text = "Mô tả: " + book.Description;
            this.lblDescription.Font = new Font("Segoe UI", 12);
            this.lblDescription.Location = new Point(30, 350);
            this.lblDescription.Size = new Size(740, 120);
            this.lblDescription.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblDescription.AutoSize = false;

            // btnBorrow
            this.btnBorrow.Text = "Mượn sách";
            this.btnBorrow.BackColor = Color.FromArgb(37, 99, 235);
            this.btnBorrow.ForeColor = Color.White;
            this.btnBorrow.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnBorrow.Size = new Size(150, 45);
            this.btnBorrow.Location = new Point(30, 480);
            this.btnBorrow.FlatStyle = FlatStyle.Flat;
            this.btnBorrow.FlatAppearance.BorderSize = 0;
            this.btnBorrow.Cursor = Cursors.Hand;
            this.btnBorrow.Enabled = book.Available && Library.Instance.CurrentUser != null;
            this.btnBorrow.Click += new EventHandler(this.btnBorrow_Click);
            // Bo góc cho nút mượn sách
            this.btnBorrow.Paint += (sender, e) => {
                var button = sender as Button;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(button.Width - 20, 0, 20, 20, 270, 90);
                path.AddArc(button.Width - 20, button.Height - 20, 20, 20, 0, 90);
                path.AddArc(0, button.Height - 20, 20, 20, 90, 90);
                button.Region = new Region(path);
            };

            // btnClose
            this.btnClose.Text = "Đóng";
            this.btnClose.Font = new Font("Segoe UI", 12);
            this.btnClose.Size = new Size(150, 45);
            this.btnClose.Location = new Point(620, 480);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            // Bo góc cho nút đóng
            this.btnClose.Paint += (sender, e) => {
                var button = sender as Button;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(button.Width - 20, 0, 20, 20, 270, 90);
                path.AddArc(button.Width - 20, button.Height - 20, 20, 20, 0, 90);
                path.AddArc(0, button.Height - 20, 20, 20, 90, 90);
                button.Region = new Region(path);
            };

            // Add controls
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblPages);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.btnClose);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (Library.Instance.CurrentUser == null)
            {
                MessageBox.Show("Bạn cần đăng nhập để mượn sách.", "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MainForm.FormManager.MainForm != null)
                {
                    MainForm.FormManager.MainForm.ShowLoginForm();
                }

                return;
            }

            if (!book.Available)
            {
                MessageBox.Show("Sách này hiện không có sẵn để mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BorrowForm borrowForm = new BorrowForm(book);
            if (borrowForm.ShowDialog() == DialogResult.OK)
            {
                // Cập nhật trạng thái sách
                this.lblStatus.Text = "Trạng thái: Đã mượn";
                this.lblStatus.ForeColor = Color.Red;
                this.btnBorrow.Enabled = false;

                // Đóng form chi tiết
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

