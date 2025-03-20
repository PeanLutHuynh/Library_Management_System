using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class MainForm : Form
    {
        private Panel mainPanel;
        private Panel navbarPanel;
        private Panel contentPanel;

        // TabPanel
        private HomePanel homePanel;
        private BooksPanel booksPanel;
        private SearchPanel searchPanel;
        private MyBooksPanel myBooksPanel;
        private ProfilePanel profilePanel;

        // Buttons and labels
        private Button btnHome;
        private Button btnBooks;
        private Button btnSearch;
        private Button btnMyBooks;
        private Button btnLogin;
        private Button btnProfile;
        private Button btnLogout;
        private Label lblUserName;
        private PictureBox picLogo;

        public static class FormManager
        {
            public static MainForm MainForm { get; set; }
        }

        public MainForm()
        {
            InitializeComponent();
            // Asure that the resource directories are created
            ResourceManager.EnsureResourceDirectories();
            InitializePanels();
            // Set the MainForm property of FormManager to this instance
            FormManager.MainForm = this;
            // Update the navbar to show the correct details
            UpdateNavbar();
            // Show the home panel by default
            ShowPanel(homePanel);
            //this.MaximizeBox = false;
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            MainForm_SizeChanged(this, EventArgs.Empty); // Initial call to set positions
        }

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.navbarPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();

            this.picLogo = new System.Windows.Forms.PictureBox();
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
            this.mainPanel.Padding = new Padding(10);

            // navbarPanel
            this.navbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navbarPanel.Height = 70;
            this.navbarPanel.BackColor = System.Drawing.Color.White;
            this.navbarPanel.BorderStyle = BorderStyle.None;
            this.navbarPanel.Padding = new Padding(10);
            // Border bottom
            this.navbarPanel.Paint += (sender, e) => {
                Panel panel = sender as Panel;
                Pen pen = new Pen(Color.FromArgb(229, 231, 235), 1);
                e.Graphics.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
            };

            // Add logo
            PictureBox picLogo = new PictureBox();
            picLogo.Size = new Size(40, 40);
            picLogo.Location = new Point(20, 15);
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "book.png")); // Bạn có thể thêm logo ở đây
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.navbarPanel.Controls.Add(picLogo);

            // Add logo text
            Label lblLogo = new Label();
            lblLogo.Text = "Thư Viện";
            lblLogo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(37, 99, 235);
            lblLogo.Location = new Point(70, 15);
            lblLogo.Size = new Size(120, 40);
            lblLogo.TextAlign = ContentAlignment.MiddleLeft;
            this.navbarPanel.Controls.Add(lblLogo);
            this.navbarPanel.Controls.Add(this.picLogo);
            this.navbarPanel.Controls.Add(this.btnHome);
            this.navbarPanel.Controls.Add(this.btnBooks);
            this.navbarPanel.Controls.Add(this.btnSearch);
            this.navbarPanel.Controls.Add(this.btnMyBooks);
            this.navbarPanel.Controls.Add(this.btnLogin);
            this.navbarPanel.Controls.Add(this.btnProfile);
            this.navbarPanel.Controls.Add(this.btnLogout);
            this.navbarPanel.Controls.Add(this.lblUserName);

            // picLogo
            this.picLogo.Size = new Size(40, 40);
            this.picLogo.Location = new Point(20, 15);
            this.picLogo.BackColor = Color.Transparent;
            //this.picLogo.Image = null; //Set Logo image
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;

            // Logo text
            lblLogo.Text = "Thư Viện";
            lblLogo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(37, 99, 235);
            lblLogo.Location = new Point(70, 15);
            lblLogo.Size = new Size(120, 40);
            lblLogo.TextAlign = ContentAlignment.MiddleLeft;
            this.navbarPanel.Controls.Add(lblLogo);

            // contentPanel
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.contentPanel.Padding = new Padding(20);
            this.contentPanel.AutoScroll = true;

            // btnHome
            this.btnHome.Text = "Trang chủ";
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnHome.Location = new System.Drawing.Point(200, 15);
            this.btnHome.Size = new System.Drawing.Size(110, 40);
            this.btnHome.Cursor = Cursors.Hand;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);

            // btnBooks
            this.btnBooks.Text = "Sách";
            this.btnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooks.FlatAppearance.BorderSize = 0;
            this.btnBooks.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnBooks.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnBooks.Location = new System.Drawing.Point(310, 15);
            this.btnBooks.Size = new System.Drawing.Size(110, 40);
            this.btnBooks.Cursor = Cursors.Hand;
            this.btnBooks.Dock = DockStyle.None;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);

            // btnSearch
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSearch.Location = new System.Drawing.Point(420, 15);
            this.btnSearch.Size = new System.Drawing.Size(110, 40);
            this.btnSearch.Cursor = Cursors.Hand;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnMyBooks
            this.btnMyBooks.Text = "Sách của tôi";
            this.btnMyBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyBooks.FlatAppearance.BorderSize = 0;
            this.btnMyBooks.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnMyBooks.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnMyBooks.Location = new System.Drawing.Point(530, 15);
            this.btnMyBooks.Size = new System.Drawing.Size(120, 40);
            this.btnMyBooks.Cursor = Cursors.Hand;
            this.btnMyBooks.Click += new System.EventHandler(this.btnMyBooks_Click);

            // lblUserName
            this.lblUserName.Text = "";
            this.lblUserName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblUserName.Location = new System.Drawing.Point(650, 15);
            this.lblUserName.Size = new System.Drawing.Size(180, 40);
            this.lblUserName.Dock = DockStyle.None;
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnLogin
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Size = new System.Drawing.Size(100, 40);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnProfile
            this.btnProfile.Text = "Hồ sơ";
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnProfile.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnProfile.Location = new System.Drawing.Point(800, 15);
            this.btnProfile.Size = new System.Drawing.Size(100, 40);
            this.btnProfile.Cursor = Cursors.Hand;
            this.btnProfile.Dock = DockStyle.Right;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            // btnLogout
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnLogout.Location = new System.Drawing.Point(880, 15);
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Dock = DockStyle.Right;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.mainPanel);
            this.Text = "Thư Viện Trực Tuyến";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MinimumSize = new Size(900, 600);

            this.ResumeLayout(false);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            int margin = 15;
            int buttonHeight = 40;
            int spacing = 10;

            // Calculate the available width for buttons
            int availableWidth = this.ClientSize.Width - margin * 2 - spacing * 6; // 6 spaces between 7 buttons

            // Calculate the new button width
            int buttonWidth = availableWidth / 9; // 7 buttons

            // Calculate the starting X position for the buttons
            int startX = margin + 180;

            // Update button positions and widths
            this.btnHome.Location = new Point(startX, margin);
            this.btnHome.Size = new Size(buttonWidth, buttonHeight);

            this.btnBooks.Location = new Point(startX + buttonWidth + spacing, margin);
            this.btnBooks.Size = new Size(buttonWidth, buttonHeight);

            this.btnSearch.Location = new Point(startX + 2 * (buttonWidth + spacing), margin);
            this.btnSearch.Size = new Size(buttonWidth, buttonHeight);

            this.btnMyBooks.Location = new Point(startX + 3 * (buttonWidth + spacing), margin);
            this.btnMyBooks.Size = new Size(buttonWidth, buttonHeight);

            this.lblUserName.Location = new Point(startX + 4 * (buttonWidth + spacing) , margin);
            this.lblUserName.Size = new Size(buttonWidth + 15, buttonHeight);

            // Conditional display of btnLogin and btnProfile
            if (this.lblUserName.Text == "")
            {
                this.btnLogin.Location = new Point(startX + 6 * (buttonWidth + spacing) , margin);
                this.btnLogin.Size = new Size(buttonWidth, buttonHeight);
                this.btnProfile.Visible = false;
            }
            else
            {
                this.btnProfile.Location = new Point(startX + 5 * (buttonWidth + spacing) + 80, margin);
                this.btnProfile.Size = new Size(buttonWidth, buttonHeight);
                this.btnLogin.Visible = false;
            }

            this.btnLogout.Location = new Point(startX + 6 * (buttonWidth + spacing), margin);
            this.btnLogout.Size = new Size(buttonWidth, buttonHeight);
        }

        private void InitializePanels()
        {
            // Load all panels
            homePanel = new HomePanel();
            booksPanel = new BooksPanel();
            searchPanel = new SearchPanel();
            myBooksPanel = new MyBooksPanel();
            profilePanel = new ProfilePanel();

            // Set the Dock property to fill the panel
            homePanel.Dock = DockStyle.Fill;
            booksPanel.Dock = DockStyle.Fill;
            searchPanel.Dock = DockStyle.Fill;
            myBooksPanel.Dock = DockStyle.Fill;
            profilePanel.Dock = DockStyle.Fill;
        }

        public void UpdateNavbar()
        {
            bool isAuthenticated = Library.Instance.CurrentUser != null;

            btnMyBooks.Visible = isAuthenticated;
            btnProfile.Visible = isAuthenticated;
            btnLogout.Visible = isAuthenticated;
            lblUserName.Visible = isAuthenticated;
            btnLogin.Visible = !isAuthenticated;

            if (isAuthenticated)
            {
                string[] nameParts = Library.Instance.CurrentUser.Name.Split(' ');
                string firstName = nameParts[nameParts.Length - 1];
                lblUserName.Text = $"Xin chào, {firstName}";
                // Show profile panel if user is logged in
                profilePanel.UpdateProfileInfo();
            }
        }

        public void ShowPanel(Panel panel)
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
            // Update the book status
            Library.Instance.ResetBookStatus();

            // Set the current user to null
            Library.Instance.CurrentUser = null;
            Library.Instance.SaveData();

            // Update the navbar and all panels
            UpdateNavbar();
            UpdateAllPanels();
            ShowPanel(homePanel);
        }

        // Public methods for navigation from other panels
        public void ShowBooksPanel()
        {
            ShowPanel(booksPanel);
        }

        public void ShowLoginForm()
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                UpdateNavbar();
                UpdateAllPanels();
                // Show the MyBooksPanel if the user is logged in
                profilePanel.UpdateProfileInfo();
            }
        }

        // Add a public method to update all panels
        public void UpdateAllPanels()
        {
            this.SuspendLayout();

            // Load Books
            booksPanel.LoadBooks();

            // Load Popular Books
            homePanel.LoadPopularBooks();

            // Load Borrowed Books
            if (Library.Instance.CurrentUser != null)
            {
                myBooksPanel.LoadBorrowedBooks();
                profilePanel.UpdateProfileInfo();
            }

            this.ResumeLayout();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Library.Instance.ResetBookStatus();
            Library.Instance.SaveData();
        }
    }
}

