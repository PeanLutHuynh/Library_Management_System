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
            this.lblTitle.Location = new Point(0, 50);
            this.lblTitle.Size = new Size(860, 40);
            this.lblTitle.Dock = DockStyle.None;

            // Subtitle
            this.lblSubtitle.Text = "Khám phá, mượn và quản lý sách một cách dễ dàng. Thư viện trực tuyến của chúng tôi cung cấp hàng ngàn đầu sách cho bạn.";
            this.lblSubtitle.Font = new Font("Arial", 12);
            this.lblSubtitle.ForeColor = Color.White;
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSubtitle.Location = new Point(100, 100);
            this.lblSubtitle.Size = new Size(660, 40);
            this.lblSubtitle.Dock = DockStyle.None;

            // Buttons Panel
            Panel buttonsPanel = new Panel();
            buttonsPanel.Size = new Size(300, 40);
            buttonsPanel.Location = new Point(280, 150);
            buttonsPanel.BackColor = Color.Transparent;

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
            this.btnLogin.Location = new Point(130, 0);
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
            this.lblPopularSubtitle.Font = new Font("Arial", 10);
            this.lblPopularSubtitle.ForeColor = Color.Gray;
            this.lblPopularSubtitle.Location = new Point(20, 300);
            this.lblPopularSubtitle.Size = new Size(600, 20);

            // Popular Books Panel
            this.popularBooksPanel.Location = new Point(20, 330);
            this.popularBooksPanel.Size = new Size(860, 250);
            this.popularBooksPanel.AutoScroll = true;

            // Features Section
            this.featuresSection.Location = new Point(0, 600);
            this.featuresSection.Size = new Size(900, 250);
            this.featuresSection.BackColor = Color.FromArgb(243, 244, 246); // Light gray

            // Features Title
            this.lblFeaturesTitle.Text = "Tại sao chọn thư viện của chúng tôi?";
            this.lblFeaturesTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            this.lblFeaturesTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblFeaturesTitle.Location = new Point(0, 20);
            this.lblFeaturesTitle.Size = new Size(900, 30);

            // Features Table
            this.featuresTable.ColumnCount = 3;
            this.featuresTable.RowCount = 1;
            this.featuresTable.Location = new Point(50, 70);
            this.featuresTable.Size = new Size(800, 150);
            this.featuresTable.BackColor = Color.Transparent;

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
            featurePanel.Size = new Size(250, 150);
            featurePanel.BackColor = Color.White;
            featurePanel.Padding = new Padding(15);

            Label lblFeatureTitle = new Label();
            lblFeatureTitle.Text = title;
            lblFeatureTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblFeatureTitle.Location = new Point(15, 15);
            lblFeatureTitle.Size = new Size(220, 20);

            Label lblFeatureDesc = new Label();
            lblFeatureDesc.Text = description;
            lblFeatureDesc.Font = new Font("Arial", 9);
            lblFeatureDesc.Location = new Point(15, 45);
            lblFeatureDesc.Size = new Size(220, 60);
            lblFeatureDesc.ForeColor = Color.Gray;

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
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.White;
            this.Margin = new Padding(10);

            // Borrow Count Badge
            this.lblBorrowCount = new Label();
            this.lblBorrowCount.Text = $"{book.BorrowCount} lượt mượn";
            this.lblBorrowCount.Font = new Font("Arial", 8, FontStyle.Bold);
            this.lblBorrowCount.ForeColor = Color.White;
            this.lblBorrowCount.BackColor = Color.FromArgb(37, 99, 235);
            this.lblBorrowCount.Size = new Size(80, 20);
            this.lblBorrowCount.Location = new Point(10, 10);
            this.lblBorrowCount.TextAlign = ContentAlignment.MiddleCenter;

            // picCover
            this.picCover.Size = new Size(180, 150);
            this.picCover.Location = new Point(10, 10);
            this.picCover.BackColor = Color.LightGray;
            this.picCover.SizeMode = PictureBoxSizeMode.Zoom;

            // lblTitle
            this.lblTitle.Text = book.Title;
            this.lblTitle.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblTitle.Location = new Point(10, 170);
            this.lblTitle.Size = new Size(180, 20);

            // lblAuthor
            this.lblAuthor.Text = book.Author;
            this.lblAuthor.Location = new Point(10, 190);
            this.lblAuthor.Size = new Size(180, 20);
            this.lblAuthor.ForeColor = Color.Gray;

            // lblGenre
            this.lblGenre.Text = book.Genre;
            this.lblGenre.Location = new Point(10, 210);
            this.lblGenre.Size = new Size(90, 20);
            this.lblGenre.ForeColor = Color.Gray;

            // lblStatus
            this.lblStatus.Text = book.Available ? "Có sẵn" : "Đã mượn";
            this.lblStatus.Location = new Point(100, 210);
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