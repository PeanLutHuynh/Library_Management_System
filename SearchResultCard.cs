using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    // Thẻ kết quả tìm kiếm với thiết kế giống giao diện web
    public class SearchResultCard : Panel
    {
        private Book book;
        private PictureBox picCover;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblGenre;
        private Label lblStatus;
        private Label lblDescription;
        private Button btnDetails;

        public SearchResultCard(Book book)
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
            this.lblDescription = new Label();
            this.btnDetails = new Button();

            // SearchResultCard
            this.Size = new Size(840, 160);
            this.BorderStyle = BorderStyle.None;
            this.Margin = new Padding(15);
            this.BackColor = Color.White;
            this.Padding = new Padding(15);
            // Thêm đổ bóng cho thẻ kết quả tìm kiếm
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

            // lblGenre
            this.lblGenre.Text = book.Genre;
            this.lblGenre.Font = new Font("Segoe UI", 10);
            this.lblGenre.Location = new Point(140, 70);
            this.lblGenre.Size = new Size(200, 20);
            this.lblGenre.ForeColor = Color.FromArgb(107, 114, 128);

            // lblStatus
            this.lblStatus.Text = book.Available ? "Có sẵn" : "Đã mượn";
            this.lblStatus.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblStatus.Location = new Point(350, 70);
            this.lblStatus.Size = new Size(100, 20);
            this.lblStatus.ForeColor = book.Available ? Color.Green : Color.Red;

            // lblDescription
            this.lblDescription.Text = book.Description.Length > 150 ? book.Description.Substring(0, 150) + "..." : book.Description;
            this.lblDescription.Font = new Font("Segoe UI", 9);
            this.lblDescription.Location = new Point(140, 95);
            this.lblDescription.Size = new Size(600, 50);
            this.lblDescription.ForeColor = Color.FromArgb(107, 114, 128);

            // btnDetails
            this.btnDetails.Text = "Chi tiết";
            this.btnDetails.Location = new Point(730, 65);
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
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnDetails);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            BookDetailForm detailForm = new BookDetailForm(book);
            detailForm.ShowDialog();
        }
    }
}

