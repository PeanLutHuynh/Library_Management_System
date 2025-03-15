using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class MainForm : Form
    {
        private Panel mainPanel;
        private Panel navbarPanel;
        private Panel contentPanel;

        // Các tab
        private HomePanel homePanel;
        private BooksPanel booksPanel;
        private SearchPanel searchPanel;
        private MyBooksPanel myBooksPanel;
        private ProfilePanel profilePanel;

        // Các button trên navbar
        private Button btnHome;
        private Button btnBooks;
        private Button btnSearch;
        private Button btnMyBooks;
        private Button btnLogin;
        private Button btnProfile;
        private Button btnLogout;
        private Label lblUserName;

        public MainForm()
        {
            InitializeComponent();
            InitializePanels();

            // Đăng ký sự kiện khi người dùng đăng nhập/đăng xuất
            UpdateNavbar();

            // Hiển thị trang chủ mặc định
            ShowPanel(homePanel);
        }

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.navbarPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();

            this.btnHome = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMyBooks = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // mainPanel
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Controls.Add(this.navbarPanel);
            this.mainPanel.Controls.Add(this.contentPanel);

            // navbarPanel
            this.navbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navbarPanel.Height = 60;
            this.navbarPanel.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.navbarPanel.Controls.Add(this.btnHome);
            this.navbarPanel.Controls.Add(this.btnBooks);
            this.navbarPanel.Controls.Add(this.btnSearch);
            this.navbarPanel.Controls.Add(this.btnMyBooks);
            this.navbarPanel.Controls.Add(this.btnLogin);
            this.navbarPanel.Controls.Add(this.btnProfile);
            this.navbarPanel.Controls.Add(this.btnLogout);
            this.navbarPanel.Controls.Add(this.lblUserName);

            // contentPanel
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.BackColor = System.Drawing.Color.White;

            // btnHome
            this.btnHome.Text = "Trang chủ";
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(10, 15);
            this.btnHome.Size = new System.Drawing.Size(100, 30);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);

            // btnBooks
            this.btnBooks.Text = "Sách";
            this.btnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooks.FlatAppearance.BorderSize = 0;
            this.btnBooks.ForeColor = System.Drawing.Color.White;
            this.btnBooks.Location = new System.Drawing.Point(120, 15);
            this.btnBooks.Size = new System.Drawing.Size(100, 30);
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);

            // btnSearch
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(230, 15);
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnMyBooks
            this.btnMyBooks.Text = "Sách của tôi";
            this.btnMyBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyBooks.FlatAppearance.BorderSize = 0;
            this.btnMyBooks.ForeColor = System.Drawing.Color.White;
            this.btnMyBooks.Location = new System.Drawing.Point(340, 15);
            this.btnMyBooks.Size = new System.Drawing.Size(100, 30);
            this.btnMyBooks.Click += new System.EventHandler(this.btnMyBooks_Click);

            // btnLogin
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(680, 15);
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnProfile
            this.btnProfile.Text = "Hồ sơ";
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Location = new System.Drawing.Point(680, 15);
            this.btnProfile.Size = new System.Drawing.Size(100, 30);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            // btnLogout
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(790, 15);
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // lblUserName
            this.lblUserName.Text = "";
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(580, 15);
            this.lblUserName.Size = new System.Drawing.Size(100, 30);
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // MainForm
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.mainPanel);
            this.Text = "Thư Viện Trực Tuyến";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);

            this.ResumeLayout(false);
        }


        private void InitializePanels()
        {
            // Khởi tạo các panel
            homePanel = new HomePanel();
            booksPanel = new BooksPanel();
            searchPanel = new SearchPanel();
            myBooksPanel = new MyBooksPanel();
            profilePanel = new ProfilePanel();

            // Thiết lập kích thước và vị trí
            homePanel.Dock = DockStyle.Fill;
            booksPanel.Dock = DockStyle.Fill;
            searchPanel.Dock = DockStyle.Fill;
            myBooksPanel.Dock = DockStyle.Fill;
            profilePanel.Dock = DockStyle.Fill;
        }

        private void UpdateNavbar()
        {
            bool isAuthenticated = Library.Instance.CurrentUser != null;

            btnMyBooks.Visible = isAuthenticated;
            btnProfile.Visible = isAuthenticated;
            btnLogout.Visible = isAuthenticated;
            lblUserName.Visible = isAuthenticated;
            btnLogin.Visible = !isAuthenticated;

            if (isAuthenticated)
            {
                lblUserName.Text = $"Xin chào, {Library.Instance.CurrentUser.Name.Split(' ')[Library.Instance.CurrentUser.Name.Split(' ').Length - 1]}";
            }
        }

        private void ShowPanel(Panel panel)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(panel);
            panel.BringToFront();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowPanel(homePanel);
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            ShowPanel(booksPanel);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowPanel(searchPanel);
        }

        private void btnMyBooks_Click(object sender, EventArgs e)
        {
            if (Library.Instance.CurrentUser == null)
            {
                MessageBox.Show("Bạn cần đăng nhập để xem sách đã mượn.", "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowLoginForm();
                return;
            }

            ShowPanel(myBooksPanel);
            myBooksPanel.LoadBorrowedBooks();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ShowPanel(profilePanel);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Library.Instance.CurrentUser = null;
            UpdateNavbar();
            ShowPanel(homePanel);
        }

        private void ShowLoginForm()
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                UpdateNavbar();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Library.Instance.SaveData();
        }
    }

    // Panel cho trang chủ
    public class HomePanel : Panel
    {
        private Label lblTitle;
        private Label lblSubtitle;
        private FlowLayoutPanel popularBooksPanel;

        public HomePanel()
        {
            InitializeComponent();
            LoadPopularBooks();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.popularBooksPanel = new FlowLayoutPanel();

            // lblTitle
            this.lblTitle.Text = "Thư Viện Trực Tuyến";
            this.lblTitle.Font = new Font("Arial", 24, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(400, 40);

            // lblSubtitle
            this.lblSubtitle.Text = "Sách Được Mượn Nhiều Nhất";
            this.lblSubtitle.Font = new Font("Arial", 16, FontStyle.Bold);
            this.lblSubtitle.Location = new Point(20, 100);
            this.lblSubtitle.Size = new Size(400, 30);

            // popularBooksPanel
            this.popularBooksPanel.Location = new Point(20, 140);
            this.popularBooksPanel.Size = new Size(860, 400);
            this.popularBooksPanel.AutoScroll = true;

            // HomePanel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.popularBooksPanel);
        }

        private void LoadPopularBooks()
        {
            popularBooksPanel.Controls.Clear();

            List<Book> popularBooks = Library.Instance.GetMostBorrowedBooks(4);

            foreach (Book book in popularBooks)
            {
                BookCard bookCard = new BookCard(book);
                popularBooksPanel.Controls.Add(bookCard);
            }
        }
    }

    // Panel cho danh sách sách
    public class BooksPanel : Panel
    {
        private Label lblTitle;
        private FlowLayoutPanel booksPanel;

        public BooksPanel()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.booksPanel = new FlowLayoutPanel();

            // lblTitle
            this.lblTitle.Text = "Danh sách sách";
            this.lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(400, 30);

            // booksPanel
            this.booksPanel.Location = new Point(20, 60);
            this.booksPanel.Size = new Size(860, 480);
            this.booksPanel.AutoScroll = true;

            // BooksPanel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.booksPanel);
        }

        private void LoadBooks()
        {
            booksPanel.Controls.Clear();

            foreach (Book book in Library.Instance.Books)
            {
                BookCard bookCard = new BookCard(book);
                booksPanel.Controls.Add(bookCard);
            }
        }
    }

    // Panel cho tìm kiếm
    public class SearchPanel : Panel
    {
        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private FlowLayoutPanel resultsPanel;

        public SearchPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.resultsPanel = new FlowLayoutPanel();

            // lblTitle
            this.lblTitle.Text = "Tìm kiếm sách";
            this.lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(400, 30);

            // txtSearch
            this.txtSearch.Location = new Point(20, 60);
            this.txtSearch.Size = new Size(300, 25);
            this.txtSearch.Font = new Font("Arial", 12);

            // btnSearch
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Location = new Point(330, 60);
            this.btnSearch.Size = new Size(100, 25);
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // resultsPanel
            this.resultsPanel.Location = new Point(20, 100);
            this.resultsPanel.Size = new Size(860, 440);
            this.resultsPanel.AutoScroll = true;

            // SearchPanel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.resultsPanel);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                return;
            }

            List<Book> results = Library.Instance.SearchBooks(query);

            resultsPanel.Controls.Clear();

            if (results.Count == 0)
            {
                Label lblNoResults = new Label();
                lblNoResults.Text = $"Không tìm thấy kết quả nào phù hợp với từ khóa \"{query}\"";
                lblNoResults.Location = new Point(0, 0);
                lblNoResults.Size = new Size(400, 30);
                resultsPanel.Controls.Add(lblNoResults);
            }
            else
            {
                foreach (Book book in results)
                {
                    BookCard bookCard = new BookCard(book);
                    resultsPanel.Controls.Add(bookCard);
                }
            }
        }
    }

    // Panel cho sách của tôi
    public class MyBooksPanel : Panel
    {
        private Label lblTitle;
        private FlowLayoutPanel borrowedBooksPanel;

        public MyBooksPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.borrowedBooksPanel = new FlowLayoutPanel();

            // lblTitle
            this.lblTitle.Text = "Sách của tôi";
            this.lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(400, 30);

            // borrowedBooksPanel
            this.borrowedBooksPanel.Location = new Point(20, 60);
            this.borrowedBooksPanel.Size = new Size(860, 480);
            this.borrowedBooksPanel.AutoScroll = true;

            // MyBooksPanel
            this.Controls.Add(this.lblTitle);
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
                lblNoBooks.Location = new Point(0, 0);
                lblNoBooks.Size = new Size(400, 30);
                borrowedBooksPanel.Controls.Add(lblNoBooks);
            }
            else
            {
                foreach (Book book in borrowedBooks)
                {
                    BorrowedBookCard bookCard = new BorrowedBookCard(book);
                    borrowedBooksPanel.Controls.Add(bookCard);
                }
            }
        }
    }

    // Panel cho hồ sơ người dùng
    public class ProfilePanel : Panel
    {
        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Button btnSave;

        public ProfilePanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblAddress = new Label();
            this.txtAddress = new TextBox();
            this.btnSave = new Button();

            // lblTitle
            this.lblTitle.Text = "Hồ sơ của tôi";
            this.lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(400, 30);

            // lblName
            this.lblName.Text = "Họ tên:";
            this.lblName.Location = new Point(20, 70);
            this.lblName.Size = new Size(100, 20);

            // txtName
            this.txtName.Location = new Point(120, 70);
            this.txtName.Size = new Size(300, 20);

            // lblEmail
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new Point(20, 100);
            this.lblEmail.Size = new Size(100, 20);

            // txtEmail
            this.txtEmail.Location = new Point(120, 100);
            this.txtEmail.Size = new Size(300, 20);

            // lblPhone
            this.lblPhone.Text = "Số điện thoại:";
            this.lblPhone.Location = new Point(20, 130);
            this.lblPhone.Size = new Size(100, 20);

            // txtPhone
            this.txtPhone.Location = new Point(120, 130);
            this.txtPhone.Size = new Size(300, 20);

            // lblAddress
            this.lblAddress.Text = "Địa chỉ:";
            this.lblAddress.Location = new Point(20, 160);
            this.lblAddress.Size = new Size(100, 20);

            // txtAddress
            this.txtAddress.Location = new Point(120, 160);
            this.txtAddress.Size = new Size(300, 20);

            // btnSave
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.Location = new Point(120, 200);
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // ProfilePanel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSave);

            // Load user data
            this.VisibleChanged += new EventHandler(this.ProfilePanel_VisibleChanged);
        }

        private void ProfilePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && Library.Instance.CurrentUser != null)
            {
                User user = Library.Instance.CurrentUser;
                txtName.Text = user.Name;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                txtAddress.Text = user.Address;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Library.Instance.CurrentUser != null)
            {
                User user = Library.Instance.CurrentUser;
                user.Name = txtName.Text;
                user.Email = txtEmail.Text;
                user.Phone = txtPhone.Text;
                user.Address = txtAddress.Text;

                Library.Instance.SaveData();
                MessageBox.Show("Thông tin đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    // Card hiển thị sách
    public class BookCard : Panel
    {
        private Book book;
        private PictureBox picCover;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblGenre;
        private Label lblStatus;
        private Button btnDetails;

        public BookCard(Book book)
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
            this.btnDetails = new Button();

            // BookCard
            this.Size = new Size(200, 300);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(10);

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

            // btnDetails
            this.btnDetails.Text = "Chi tiết";
            this.btnDetails.Location = new Point(10, 240);
            this.btnDetails.Size = new Size(180, 30);
            this.btnDetails.Click += new EventHandler(this.btnDetails_Click);

            // Add controls
            this.Controls.Add(this.picCover);
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

    // Card hiển thị sách đã mượn
    public class BorrowedBookCard : Panel
    {
        private Book book;
        private PictureBox picCover;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblDueDate;
        private Button btnReturn;
        private Button btnDetails;

        public BorrowedBookCard(Book book)
        {
            this.book = book;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.picCover = new PictureBox();
            this.lblTitle = new Label();
            this.lblAuthor = new Label();
            this.lblDueDate = new Label();
            this.btnReturn = new Button();
            this.btnDetails = new Button();

            // BorrowedBookCard
            this.Size = new Size(400, 150);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(10);

            // picCover
            this.picCover.Size = new Size(100, 130);
            this.picCover.Location = new Point(10, 10);
            this.picCover.BackColor = Color.LightGray;
            this.picCover.SizeMode = PictureBoxSizeMode.Zoom;

            // lblTitle
            this.lblTitle.Text = book.Title;
            this.lblTitle.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblTitle.Location = new Point(120, 10);
            this.lblTitle.Size = new Size(270, 20);

            // lblAuthor
            this.lblAuthor.Text = book.Author;
            this.lblAuthor.Location = new Point(120, 30);
            this.lblAuthor.Size = new Size(270, 20);
            this.lblAuthor.ForeColor = Color.Gray;

            // lblDueDate
            this.lblDueDate.Text = $"Hạn trả: {book.DueDate}";
            this.lblDueDate.Location = new Point(120, 50);
            this.lblDueDate.Size = new Size(270, 20);

            // btnReturn
            this.btnReturn.Text = "Trả sách";
            this.btnReturn.Location = new Point(290, 80);
            this.btnReturn.Size = new Size(100, 30);
            this.btnReturn.Click += new EventHandler(this.btnReturn_Click);

            // btnDetails
            this.btnDetails.Text = "Chi tiết";
            this.btnDetails.Location = new Point(180, 80);
            this.btnDetails.Size = new Size(100, 30);
            this.btnDetails.Click += new EventHandler(this.btnDetails_Click);

            // Add controls
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAuthor);
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

                // Refresh the parent panel
                if (this.Parent is MyBooksPanel)
                {
                    ((MyBooksPanel)this.Parent).LoadBorrowedBooks();
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            BookDetailForm detailForm = new BookDetailForm(book);
            detailForm.ShowDialog();
        }
    }

    // Form chi tiết sách
    public class BookDetailForm : Form
    {
        private Book book;
        private PictureBox picCover;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblYear;
        private Label lblGenre;
        private Label lblPublisher;
        private Label lblPages;
        private Label lblStatus;
        private Label lblDescription;
        private TextBox txtDescription;
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
            this.lblYear = new Label();
            this.lblGenre = new Label();
            this.lblPublisher = new Label();
            this.lblPages = new Label();
            this.lblStatus = new Label();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.btnBorrow = new Button();
            this.btnClose = new Button();

            // BookDetailForm
            this.ClientSize = new Size(600, 500);
            this.Text = "Chi tiết sách";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // picCover
            this.picCover.Size = new Size(200, 250);
            this.picCover.Location = new Point(20, 20);
            this.picCover.BackColor = Color.LightGray;
            this.picCover.SizeMode = PictureBoxSizeMode.Zoom;

            // lblTitle
            this.lblTitle.Text = book.Title;
            this.lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            this.lblTitle.Location = new Point(240, 20);
            this.lblTitle.Size = new Size(340, 30);

            // lblAuthor
            this.lblAuthor.Text = $"Tác giả: {book.Author}";
            this.lblAuthor.Location = new Point(240, 60);
            this.lblAuthor.Size = new Size(340, 20);

            // lblYear
            this.lblYear.Text = $"Năm xuất bản: {book.Year}";
            this.lblYear.Location = new Point(240, 90);
            this.lblYear.Size = new Size(340, 20);

            // lblGenre
            this.lblGenre.Text = $"Thể loại: {book.Genre}";
            this.lblGenre.Location = new Point(240, 120);
            this.lblGenre.Size = new Size(340, 20);

            // lblPublisher
            this.lblPublisher.Text = $"Nhà xuất bản: {book.Publisher}";
            this.lblPublisher.Location = new Point(240, 150);
            this.lblPublisher.Size = new Size(340, 20);

            // lblPages
            this.lblPages.Text = $"Số trang: {book.Pages}";
            this.lblPages.Location = new Point(240, 180);
            this.lblPages.Size = new Size(340, 20);

            // lblStatus
            this.lblStatus.Text = $"Trạng thái: {(book.Available ? "Có sẵn" : "Đã mượn")}";
            this.lblStatus.Location = new Point(240, 210);
            this.lblStatus.Size = new Size(340, 20);
            this.lblStatus.ForeColor = book.Available ? Color.Green : Color.Red;

            // lblDescription
            this.lblDescription.Text = "Mô tả:";
            this.lblDescription.Location = new Point(20, 280);
            this.lblDescription.Size = new Size(100, 20);

            // txtDescription
            this.txtDescription.Text = book.Description;
            this.txtDescription.Location = new Point(20, 300);
            this.txtDescription.Size = new Size(560, 100);
            this.txtDescription.Multiline = true;
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = ScrollBars.Vertical;

            // btnBorrow
            this.btnBorrow.Text = book.Available ? "Mượn sách" : "Đã mượn";
            this.btnBorrow.Location = new Point(20, 420);
            this.btnBorrow.Size = new Size(100, 30);
            this.btnBorrow.Enabled = book.Available;
            this.btnBorrow.Click += new EventHandler(this.btnBorrow_Click);

            // btnClose
            this.btnClose.Text = "Đóng";
            this.btnClose.Location = new Point(480, 420);
            this.btnClose.Size = new Size(100, 30);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // Add controls
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.lblPages);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.btnClose);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (Library.Instance.CurrentUser == null)
            {
                MessageBox.Show("Bạn cần đăng nhập để mượn sách.", "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu đăng nhập thành công, tiếp tục mượn sách
                    ShowBorrowDialog();
                }
                return;
            }

            ShowBorrowDialog();
        }

        private void ShowBorrowDialog()
        {
            BorrowForm borrowForm = new BorrowForm(book);
            if (borrowForm.ShowDialog() == DialogResult.OK)
            {
                this.btnBorrow.Text = "Đã mượn";
                this.btnBorrow.Enabled = false;
                this.lblStatus.Text = "Trạng thái: Đã mượn";
                this.lblStatus.ForeColor = Color.Red;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Form mượn sách
    public class BorrowForm : Form
    {
        private Book book;
        private Label lblTitle;
        private Label lblBookInfo;
        private Label lblBorrowDate;
        private Label lblReturnDate;
        private DateTimePicker dtpBorrowDate;
        private DateTimePicker dtpReturnDate;
        private Button btnBorrow;
        private Button btnCancel;

        public BorrowForm(Book book)
        {
            this.book = book;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblBookInfo = new Label();
            this.lblBorrowDate = new Label();
            this.lblReturnDate = new Label();
            this.dtpBorrowDate = new DateTimePicker();
            this.dtpReturnDate = new DateTimePicker();
            this.btnBorrow = new Button();
            this.btnCancel = new Button();

            // BorrowForm
            this.ClientSize = new Size(400, 250);
            this.Text = "Mượn sách";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // lblTitle
            this.lblTitle.Text = "Mượn sách";
            this.lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(360, 30);

            // lblBookInfo
            this.lblBookInfo.Text = $"Sách: {book.Title}";
            this.lblBookInfo.Location = new Point(20, 60);
            this.lblBookInfo.Size = new Size(360, 20);

            // lblBorrowDate
            this.lblBorrowDate.Text = "Ngày mượn:";
            this.lblBorrowDate.Location = new Point(20, 100);
            this.lblBorrowDate.Size = new Size(100, 20);

            // dtpBorrowDate
            this.dtpBorrowDate.Location = new Point(120, 100);
            this.dtpBorrowDate.Size = new Size(200, 20);
            this.dtpBorrowDate.Format = DateTimePickerFormat.Short;
            this.dtpBorrowDate.MinDate = DateTime.Today.AddDays(0);
            this.dtpBorrowDate.MaxDate = DateTime.Today.AddDays(7);
            this.dtpBorrowDate.ValueChanged += new EventHandler(this.dtpBorrowDate_ValueChanged);

            // lblReturnDate
            this.lblReturnDate.Text = "Ngày trả:";
            this.lblReturnDate.Location = new Point(20, 140);
            this.lblReturnDate.Size = new Size(100, 20);

            // dtpReturnDate
            this.dtpReturnDate.Location = new Point(120, 140);
            this.dtpReturnDate.Size = new Size(200, 20);
            this.dtpReturnDate.Format = DateTimePickerFormat.Short;
            this.dtpReturnDate.MinDate = DateTime.Today.AddDays(1);
            this.dtpReturnDate.MaxDate = DateTime.Today.AddDays(30);

            // btnBorrow
            this.btnBorrow.Text = "Mượn";
            this.btnBorrow.Location = new Point(120, 180);
            this.btnBorrow.Size = new Size(100, 30);
            this.btnBorrow.Click += new EventHandler(this.btnBorrow_Click);

            // btnCancel
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Location = new Point(230, 180);
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblBookInfo);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.dtpBorrowDate);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.btnCancel);
        }

        private void dtpBorrowDate_ValueChanged(object sender, EventArgs e)
        {
            // Update return dates based on borrow date
            DateTime borrowDate = dtpBorrowDate.Value;
            dtpReturnDate.MinDate = borrowDate.AddDays(1);
            dtpReturnDate.Value = borrowDate.AddDays(1);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            DateTime borrowDate = dtpBorrowDate.Value;
            DateTime returnDate = dtpReturnDate.Value;

            if (returnDate <= borrowDate)
            {
                MessageBox.Show("Ngày trả sách phải sau ngày mượn sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message = Library.Instance.CurrentUser.BorrowBook(book, borrowDate, returnDate);

            MessageBox.Show($"Chúc mừng! {message}\nVui lòng đến thư viện vào ngày {borrowDate.ToString("dd/MM/yyyy")} để nhận sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    // Form đăng nhập
    public class LoginForm : Form
    {
        private Label lblTitle;
        private TabControl tabControl;
        private TabPage tabLogin;
        private TabPage tabRegister;

        // Login controls
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;

        // Register controls
        private Label lblRegName;
        private TextBox txtRegName;
        private Label lblRegEmail;
        private TextBox txtRegEmail;
        private Label lblRegPassword;
        private TextBox txtRegPassword;
        private Label lblRegPhone;
        private TextBox txtRegPhone;
        private Label lblRegAddress;
        private TextBox txtRegAddress;
        private Button btnRegister;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.tabControl = new TabControl();
            this.tabLogin = new TabPage();
            this.tabRegister = new TabPage();

            // Login controls
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();

            // Register controls
            this.lblRegName = new Label();
            this.txtRegName = new TextBox();
            this.lblRegEmail = new Label();
            this.txtRegEmail = new TextBox();
            this.lblRegPassword = new Label();
            this.txtRegPassword = new TextBox();
            this.lblRegPhone = new Label();
            this.txtRegPhone = new TextBox();
            this.lblRegAddress = new Label();
            this.txtRegAddress = new TextBox();
            this.btnRegister = new Button();

            // LoginForm
            this.ClientSize = new Size(400, 400);
            this.Text = "Đăng nhập";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // lblTitle
            this.lblTitle.Text = "Thư Viện Trực Tuyến";
            this.lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(360, 30);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // tabControl
            this.tabControl.Location = new Point(20, 60);
            this.tabControl.Size = new Size(360, 320);
            this.tabControl.Controls.Add(this.tabLogin);
            this.tabControl.Controls.Add(this.tabRegister);

            // tabLogin
            this.tabLogin.Text = "Đăng nhập";
            this.tabLogin.Controls.Add(this.lblEmail);
            this.tabLogin.Controls.Add(this.txtEmail);
            this.tabLogin.Controls.Add(this.lblPassword);
            this.tabLogin.Controls.Add(this.txtPassword);
            this.tabLogin.Controls.Add(this.btnLogin);

            // tabRegister
            this.tabRegister.Text = "Đăng ký";
            this.tabRegister.Controls.Add(this.lblRegName);
            this.tabRegister.Controls.Add(this.txtRegName);
            this.tabRegister.Controls.Add(this.lblRegEmail);
            this.tabRegister.Controls.Add(this.txtRegEmail);
            this.tabRegister.Controls.Add(this.lblRegPassword);
            this.tabRegister.Controls.Add(this.txtRegPassword);
            this.tabRegister.Controls.Add(this.lblRegPhone);
            this.tabRegister.Controls.Add(this.txtRegPhone);
            this.tabRegister.Controls.Add(this.lblRegAddress);
            this.tabRegister.Controls.Add(this.txtRegAddress);
            this.tabRegister.Controls.Add(this.btnRegister);

            // Login controls
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new Point(20, 20);
            this.lblEmail.Size = new Size(100, 20);

            this.txtEmail.Location = new Point(20, 40);
            this.txtEmail.Size = new Size(300, 20);

            this.lblPassword.Text = "Mật khẩu:";
            this.lblPassword.Location = new Point(20, 70);
            this.lblPassword.Size = new Size(100, 20);

            this.txtPassword.Location = new Point(20, 90);
            this.txtPassword.Size = new Size(300, 20);
            this.txtPassword.PasswordChar = '*';

            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Location = new Point(120, 130);
            this.btnLogin.Size = new Size(100, 30);
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // Register controls
            this.lblRegName.Text = "Họ tên:";
            this.lblRegName.Location = new Point(20, 20);
            this.lblRegName.Size = new Size(100, 20);

            this.txtRegName.Location = new Point(20, 40);
            this.txtRegName.Size = new Size(300, 20);

            this.lblRegEmail.Text = "Email:";
            this.lblRegEmail.Location = new Point(20, 70);
            this.lblRegEmail.Size = new Size(100, 20);

            this.txtRegEmail.Location = new Point(20, 90);
            this.txtRegEmail.Size = new Size(300, 20);

            this.lblRegPassword.Text = "Mật khẩu:";
            this.lblRegPassword.Location = new Point(20, 120);
            this.lblRegPassword.Size = new Size(100, 20);

            this.txtRegPassword.Location = new Point(20, 140);
            this.txtRegPassword.Size = new Size(300, 20);
            this.txtRegPassword.PasswordChar = '*';

            this.lblRegPhone.Text = "Số điện thoại:";
            this.lblRegPhone.Location = new Point(20, 170);
            this.lblRegPhone.Size = new Size(100, 20);

            this.txtRegPhone.Location = new Point(20, 190);
            this.txtRegPhone.Size = new Size(300, 20);

            this.lblRegAddress.Text = "Địa chỉ:";
            this.lblRegAddress.Location = new Point(20, 220);
            this.lblRegAddress.Size = new Size(100, 20);

            this.txtRegAddress.Location = new Point(20, 240);
            this.txtRegAddress.Size = new Size(300, 20);

            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.Location = new Point(120, 270);
            this.btnRegister.Size = new Size(100, 30);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabControl);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Giả lập đăng nhập thành công
            User user = Library.Instance.FindUser(email, password);

            if (user != null)
            {
                Library.Instance.CurrentUser = user;
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Kiểm tra lại email và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtRegName.Text.Trim();
            string email = txtRegEmail.Text.Trim();
            string password = txtRegPassword.Text;
            string phone = txtRegPhone.Text.Trim();
            string address = txtRegAddress.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo người dùng mới
            User newUser = new User(Guid.NewGuid().ToString(), name, email, password, phone, address);
            Library.Instance.AddUser(newUser);
            Library.Instance.CurrentUser = newUser;

            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}