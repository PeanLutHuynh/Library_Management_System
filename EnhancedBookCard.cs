using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    // Thẻ sách cải tiến với thiết kế giống giao diện web
    public class EnhancedBookCard : Panel
    {
        private Book book;
        private PictureBox picCover;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblGenre;
        private Label lblStatus;
        private Label lblBorrowCount;
        private Button btnDetails;

        public EnhancedBookCard(Book book)
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
            this.lblStatus = new Label();
            this.lblBorrowCount = new Label();
            this.btnDetails = new Button();

            // BookCard
            this.Size = new Size(220, 350);
            this.BorderStyle = BorderStyle.None;
            this.Margin = new Padding(15);
            this.BackColor = Color.White;
            // Thêm đổ bóng cho thẻ sách
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

            // Borrow Count Badge
            this.lblBorrowCount = new Label();
            this.lblBorrowCount.Text = $"{book.BorrowCount} lượt mượn";
            this.lblBorrowCount.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            this.lblBorrowCount.ForeColor = Color.White;
            this.lblBorrowCount.BackColor = Color.FromArgb(37, 99, 235);
            this.lblBorrowCount.Size = new Size(90, 24);
            this.lblBorrowCount.Location = new Point(10, 10);
            this.lblBorrowCount.TextAlign = ContentAlignment.MiddleCenter;
            // Bo góc cho badge
            this.lblBorrowCount.Paint += (sender, e) => {
                var label = sender as Label;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, 10, 10, 180, 90);
                path.AddArc(label.Width - 10, 0, 10, 10, 270, 90);
                path.AddArc(label.Width - 10, label.Height - 10, 10, 10, 0, 90);
                path.AddArc(0, label.Height - 10, 10, 10, 90, 90);
                label.Region = new Region(path);
            };

            // picCover
            this.picCover.Size = new Size(200, 170);
            this.picCover.Location = new Point(10, 10);
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
            this.lblTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblTitle.Location = new Point(10, 190);
            this.lblTitle.Size = new Size(200, 40);
            this.lblTitle.ForeColor = Color.FromArgb(17, 24, 39);

            // lblAuthor
            this.lblAuthor.Text = book.Author;
            this.lblAuthor.Font = new Font("Segoe UI", 9);
            this.lblAuthor.Location = new Point(10, 230);
            this.lblAuthor.Size = new Size(200, 20);
            this.lblAuthor.ForeColor = Color.FromArgb(107, 114, 128);

            // lblGenre
            this.lblGenre.Text = book.Genre;
            this.lblGenre.Font = new Font("Segoe UI", 9);
            this.lblGenre.Location = new Point(10, 255);
            this.lblGenre.Size = new Size(100, 20);
            this.lblGenre.ForeColor = Color.FromArgb(107, 114, 128);

            // lblStatus
            this.lblStatus.Text = book.Available ? "Có sẵn" : "Đã mượn";
            this.lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblStatus.Location = new Point(110, 255);
            this.lblStatus.Size = new Size(100, 20);
            this.lblStatus.ForeColor = book.Available ? Color.Green : Color.Red;
            this.lblStatus.TextAlign = ContentAlignment.TopRight;

            // btnDetails
            this.btnDetails.Text = "Chi tiết";
            this.btnDetails.Location = new Point(10, 285);
            this.btnDetails.Size = new Size(200, 40);
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
            this.Controls.Add(this.lblBorrowCount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDetails);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            BookDetailForm detailForm = new BookDetailForm(book);
            detailForm.ShowDialog();
        }
    }
}

