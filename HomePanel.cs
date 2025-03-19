using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public class HomePanel : Panel
    {
        private Panel heroSection;
        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnViewBooks;
        private Button btnLogin;

        private Label lblPopularTitle;
        private Label lblPopularSubtitle;
        private FlowLayoutPanel popularBooksPanel;

        private Panel featuresSection;
        private Label lblFeaturesTitle;
        private TableLayoutPanel featuresTable;

        public HomePanel()
        {
            InitializeComponent();
            LoadPopularBooks();
        }

        private void InitializeComponent()
        {
            // Initialize components
            this.heroSection = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.btnViewBooks = new Button();
            this.btnLogin = new Button();

            this.lblPopularTitle = new Label();
            this.lblPopularSubtitle = new Label();
            this.popularBooksPanel = new FlowLayoutPanel();

            this.featuresSection = new Panel();
            this.lblFeaturesTitle = new Label();
            this.featuresTable = new TableLayoutPanel();

            // Hero Section
            this.heroSection.BackColor = Color.FromArgb(37, 99, 235); // Blue color
            this.heroSection.Dock = DockStyle.Top;
            this.heroSection.Height = 250;
            this.heroSection.Padding = new Padding(20);

            // Title
            this.lblTitle.Text = "Thư Viện Trực Tuyến";
            this.lblTitle.Font = new Font("Arial", 28, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Size = new Size(860, 40);
            this.lblTitle.Dock = DockStyle.None;
            this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.lblTitle.Location = new Point((this.ClientSize.Width - lblTitle.Width) / 2, 70);

            // Subtitle
            this.lblSubtitle.Text = "Khám phá, mượn và quản lý sách một cách dễ dàng. Thư viện trực tuyến cung cấp hàng ngàn đầu sách cho bạn.";
            this.lblSubtitle.Font = new Font("Arial", 12, FontStyle.Bold);
            this.lblSubtitle.ForeColor = Color.White;
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSubtitle.Location = new Point(135, 120);
            this.lblSubtitle.Size = new Size(660, 40);
            this.lblSubtitle.Dock = DockStyle.None;
            this.lblSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.lblSubtitle.Location = new Point((this.ClientSize.Width - lblSubtitle.Width) / 2, 120);

            // Buttons Panel
            Panel buttonsPanel = new Panel();
            buttonsPanel.Size = new Size(300, 40);
            buttonsPanel.Location = new Point((this.ClientSize.Width - buttonsPanel.Width + 20) / 2, 170);
            buttonsPanel.BackColor = Color.Transparent;
            buttonsPanel.Anchor = AnchorStyles.Top;

            // View Books Button
            this.btnViewBooks.Text = "Xem Sách";
            this.btnViewBooks.BackColor = Color.White;
            this.btnViewBooks.ForeColor = Color.FromArgb(37, 99, 235);
            this.btnViewBooks.Font = new Font("Arial", 10, FontStyle.Bold);
            this.btnViewBooks.Size = new Size(120, 35);
            this.btnViewBooks.Location = new Point(0, 0);
            this.btnViewBooks.FlatStyle = FlatStyle.Flat;
            this.btnViewBooks.Click += new EventHandler(this.btnViewBooks_Click);

            // Login Button
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.BackColor = Color.FromArgb(59, 130, 246);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Font = new Font("Arial", 10, FontStyle.Bold);
            this.btnLogin.Size = new Size(120, 35);
            this.btnLogin.Location = new Point(this.btnViewBooks.Right + 18, 0); // Đặt bên phải btnViewBooks với khoảng cách 10px
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // Add buttons to panel
            buttonsPanel.Controls.Add(this.btnViewBooks);
            buttonsPanel.Controls.Add(this.btnLogin);

            // Add controls to hero section
            this.heroSection.Controls.Add(this.lblTitle);
            this.heroSection.Controls.Add(this.lblSubtitle);
            this.heroSection.Controls.Add(buttonsPanel);

            // Popular Books Section
            this.lblPopularTitle.Text = "Sách Được Mượn Nhiều Nhất";
            this.lblPopularTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            this.lblPopularTitle.Location = new Point(20, 270);
            this.lblPopularTitle.Size = new Size(400, 30);

            this.lblPopularSubtitle.Text = "Khám phá những cuốn sách được độc giả yêu thích nhất tại thư viện của chúng tôi.";
            this.lblPopularSubtitle.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblPopularSubtitle.ForeColor = Color.Gray;
            this.lblPopularSubtitle.Location = new Point(25, 310);
            this.lblPopularSubtitle.Size = new Size(600, 20);

            // Popular Books Panel
            this.popularBooksPanel.Location = new Point(20, 350);
            this.popularBooksPanel.Size = new Size(this.ClientSize.Width - 32, 450);
            this.popularBooksPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.popularBooksPanel.AutoScroll = true;

            // Features Section
            this.featuresSection.Size = new Size(this.ClientSize.Width, 250);
            this.featuresSection.Location = new Point(0, this.popularBooksPanel.Bottom + 50);
            this.featuresSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.featuresSection.BackColor = Color.FromArgb(243, 244, 246);

            // Features Title
            this.lblFeaturesTitle.Size = new Size(this.featuresSection.Width, 30);
            this.lblFeaturesTitle.Location = new Point((this.featuresSection.Width - this.lblFeaturesTitle.Width) / 2, 20);
            this.lblFeaturesTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblFeaturesTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            this.lblFeaturesTitle.Text = "Tại sao chọn thư viện của chúng tôi?";

            // Features Table
            this.featuresTable.ColumnCount = 3;
            this.featuresTable.RowCount = 1;
            this.featuresTable.Size = new Size(this.featuresSection.Width - 40, 150); // Lấp đầy khung
            this.featuresTable.Location = new Point((this.featuresSection.Width - this.featuresTable.Width) / 2, 70);
            this.featuresTable.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Đặt mỗi cột chiếm 1/3 chiều rộng bảng
            for (int i = 0; i < this.featuresTable.ColumnCount; i++)
            {
                this.featuresTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            }


            this.Resize += (sender, e) =>
            {
                // Cập nhật vị trí Features Section
                this.featuresSection.Size = new Size(this.ClientSize.Width, 250);
                this.featuresSection.Location = new Point(0, this.popularBooksPanel.Bottom + 50);

                // Cập nhật lại tiêu đề Features Title
                this.lblFeaturesTitle.Size = new Size(this.featuresSection.Width, 30);
                this.lblFeaturesTitle.Location = new Point((this.featuresSection.Width - this.lblFeaturesTitle.Width) / 2, 20);

                // Cập nhật lại Features Table
                this.featuresTable.Size = new Size(this.ClientSize.Width - 100, 150);
                this.featuresTable.Location = new Point((this.featuresSection.Width - this.featuresTable.Width) / 2, 70);
            };

            // Add features
            AddFeature(this.featuresTable, 0, "Đa dạng sách", "Thư viện của chúng tôi có hàng ngàn đầu sách thuộc nhiều thể loại khác nhau.");
            AddFeature(this.featuresTable, 1, "Miễn phí", "Dịch vụ mượn sách hoàn toàn miễn phí cho tất cả thành viên.");
            AddFeature(this.featuresTable, 2, "Dễ dàng quản lý", "Theo dõi sách đã mượn và thời hạn trả sách một cách dễ dàng.");

            // Add features table to features section
            this.featuresSection.Controls.Add(this.lblFeaturesTitle);
            this.featuresSection.Controls.Add(this.featuresTable);

            // Add all sections to the main panel
            this.Controls.Add(this.heroSection);
            this.Controls.Add(this.lblPopularTitle);
            this.Controls.Add(this.lblPopularSubtitle);
            this.Controls.Add(this.popularBooksPanel);
            this.Controls.Add(this.featuresSection);

            // Set AutoScroll for the main panel
            this.AutoScroll = true;
        }

        private void AddFeature(TableLayoutPanel table, int column, string title, string description)
        {
            Panel featurePanel = new Panel();
            featurePanel.Dock = DockStyle.Fill; // Chiếm toàn bộ cột
            featurePanel.BackColor = Color.White;
            featurePanel.Padding = new Padding(15);

            Label lblFeatureTitle = new Label();
            lblFeatureTitle.Text = title;
            lblFeatureTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblFeatureTitle.Dock = DockStyle.Top; // Căn giữa trên
            lblFeatureTitle.TextAlign = ContentAlignment.MiddleCenter;

            Label lblFeatureDesc = new Label();
            lblFeatureDesc.Text = description;
            lblFeatureDesc.Font = new Font("Arial", 10);
            lblFeatureDesc.Dock = DockStyle.Fill; // Giãn toàn bộ phần còn lại
            lblFeatureDesc.ForeColor = Color.Gray;
            lblFeatureDesc.TextAlign = ContentAlignment.MiddleCenter;

            featurePanel.Controls.Add(lblFeatureTitle);
            featurePanel.Controls.Add(lblFeatureDesc);

            table.Controls.Add(featurePanel, column, 0);
        }


        public void LoadPopularBooks()
        {
            popularBooksPanel.Controls.Clear();

            List<Book> popularBooks = Library.Instance.GetMostBorrowedBooks(5);

            foreach (Book book in popularBooks)
            {
                EnhancedBookCard bookCard = new EnhancedBookCard(book);
                popularBooksPanel.Controls.Add(bookCard);
                bookCard.Margin = new Padding(31); // Tăng khoảng cách giữa các sách
            }
            if (Library.Instance.CurrentUser != null)
            {
                this.btnLogin.Enabled = false;
                this.btnLogin.BackColor = Color.Gray;
            }
        }

        private void btnViewBooks_Click(object sender, EventArgs e)
        {
            if (MainForm.FormManager.MainForm != null)
            {
                MainForm.FormManager.MainForm.ShowBooksPanel();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (MainForm.FormManager.MainForm != null)
            {
                MainForm.FormManager.MainForm.ShowLoginForm();
            }
        }
    }

    // Lớp PopularBookCard chỉ được sử dụng trong HomePanel
    public class PopularBookCard : Panel
    {
        private Book book;
        private PictureBox picCover;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblBorrowCount;
        private Label lblStatus;
        private Label lblGenre;

        public PopularBookCard(Book book)
        {
            this.book = book;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.picCover = new PictureBox();
            this.lblTitle = new Label();
            this.lblAuthor = new Label();
            this.lblBorrowCount = new Label();
            this.lblStatus = new Label();
            this.lblGenre = new Label();

            // BookCard
            this.Size = new Size(200, 240);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;
            this.Margin = new Padding(10);

            // Borrow Count Badge
            this.lblBorrowCount.Text = $"{book.BorrowCount} lượt mượn";
            this.lblBorrowCount.Font = new Font("Arial", 8, FontStyle.Bold);
            this.lblBorrowCount.ForeColor = Color.White;
            this.lblBorrowCount.BackColor = Color.FromArgb(37, 99, 235);
            this.lblBorrowCount.Size = new Size(80, 20);
            this.lblBorrowCount.Location = new Point(this.Width - 90, 5); // Căn góc phải trên

            // picCover
            this.picCover.Size = new Size(180, 140);
            this.picCover.Location = new Point(10, 30);
            this.picCover.BackColor = Color.LightGray;
            this.picCover.SizeMode = PictureBoxSizeMode.Zoom;

            // lblTitle
            this.lblTitle.Text = book.Title;
            this.lblTitle.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblTitle.Location = new Point(10, 175);
            this.lblTitle.Size = new Size(180, 20);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblAuthor
            this.lblAuthor.Text = book.Author;
            this.lblAuthor.Location = new Point(10, 195);
            this.lblAuthor.Size = new Size(180, 20);
            this.lblAuthor.ForeColor = Color.Gray;
            this.lblAuthor.TextAlign = ContentAlignment.MiddleCenter;

            // lblGenre
            this.lblGenre.Text = book.Genre;
            this.lblGenre.Location = new Point(10, 215);
            this.lblGenre.Size = new Size(90, 20);
            this.lblGenre.ForeColor = Color.Gray;

            // lblStatus
            this.lblStatus.Text = book.Available ? "Có sẵn" : "Đã mượn";
            this.lblStatus.Location = new Point(100, 215);
            this.lblStatus.Size = new Size(90, 20);
            this.lblStatus.ForeColor = book.Available ? Color.Green : Color.Red;
            this.lblStatus.TextAlign = ContentAlignment.TopRight;

            // Add controls
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.lblBorrowCount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblStatus);


            // Add click event to the entire panel
            this.Click += new EventHandler(this.BookCard_Click);
            foreach (Control control in this.Controls)
            {
                control.Click += new EventHandler(this.BookCard_Click);
            }
        }

        private void BookCard_Click(object sender, EventArgs e)
        {
            BookDetailForm detailForm = new BookDetailForm(book);
            detailForm.ShowDialog();
        }
    }
}