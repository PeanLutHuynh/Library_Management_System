using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class ProfilePanel : Panel
    {
        private Label lblTitle;
        private Label lblSubtitle;
        private TabControl tabControl;
        private TabPage tabPersonalInfo;
        private TabPage tabBorrowHistory;

        // Personal Info Controls
        private Label lblName;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblMemberSince;
        private TextBox txtMemberSince;
        private Button btnSave;

        // Borrow History Controls
        private FlowLayoutPanel historyPanel;

        public ProfilePanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialize controls
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.tabControl = new TabControl();
            this.tabPersonalInfo = new TabPage();
            this.tabBorrowHistory = new TabPage();

            // Personal Info Controls
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblAddress = new Label();
            this.txtAddress = new TextBox();
            this.lblMemberSince = new Label();
            this.txtMemberSince = new TextBox();
            this.btnSave = new Button();

            // Borrow History Controls
            this.historyPanel = new FlowLayoutPanel();

            // Title
            this.lblTitle = new Label();
            this.lblTitle.Text = "Tài khoản của tôi";
            this.lblTitle.Font = new Font("Arial", 24, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(400, 40);

            //// Subtitle
            //this.lblSubtitle = new Label();
            //this.lblSubtitle.Text = "Quản lý thông tin cá nhân và xem lịch sử mượn sách";
            //this.lblSubtitle.Font = new Font("Arial", 12);
            //this.lblSubtitle.Location = new Point(20, 60);
            //this.lblSubtitle.Size = new Size(400, 20);

            // TabControl
            this.tabControl.Location = new Point(20, 90);
            this.tabControl.Size = new Size(860, 450);
            this.tabControl.SelectedIndexChanged += new EventHandler(this.tabControl_SelectedIndexChanged);

            // Personal Info Tab
            this.tabPersonalInfo.Text = "Thông tin cá nhân";
            this.tabPersonalInfo.Padding = new Padding(20);

            // Personal Info Controls Layout
            int startY = 20;
            int labelWidth = 120;
            int textBoxWidth = 300;
            int spacing = 30;

            // Name
            this.lblName.Text = "Họ tên:";
            this.lblName.Location = new Point(20, startY);
            this.lblName.Size = new Size(labelWidth, 20);

            this.txtName.Location = new Point(140, startY);
            this.txtName.Size = new Size(textBoxWidth, 20);

            // Email
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new Point(20, startY + spacing);
            this.lblEmail.Size = new Size(labelWidth, 20);

            this.txtEmail.Location = new Point(140, startY + spacing);
            this.txtEmail.Size = new Size(textBoxWidth, 20);

            // Phone
            this.lblPhone.Text = "Số điện thoại:";
            this.lblPhone.Location = new Point(20, startY + spacing * 2);
            this.lblPhone.Size = new Size(labelWidth, 20);

            this.txtPhone.Location = new Point(140, startY + spacing * 2);
            this.txtPhone.Size = new Size(textBoxWidth, 20);

            // Address
            this.lblAddress.Text = "Địa chỉ:";
            this.lblAddress.Location = new Point(20, startY + spacing * 3);
            this.lblAddress.Size = new Size(labelWidth, 20);

            this.txtAddress.Location = new Point(140, startY + spacing * 3);
            this.txtAddress.Size = new Size(textBoxWidth, 20);

            // Member Since
            this.lblMemberSince.Text = "Ngày tham gia:";
            this.lblMemberSince.Location = new Point(20, startY + spacing * 4);
            this.lblMemberSince.Size = new Size(labelWidth, 20);

            this.txtMemberSince.Location = new Point(140, startY + spacing * 4);
            this.txtMemberSince.Size = new Size(textBoxWidth, 20);
            this.txtMemberSince.ReadOnly = true;

            // Save Button
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.Location = new Point(140, startY + spacing * 5);
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // Add controls to Personal Info tab
            this.tabPersonalInfo.Controls.Add(this.lblName);
            this.tabPersonalInfo.Controls.Add(this.txtName);
            this.tabPersonalInfo.Controls.Add(this.lblEmail);
            this.tabPersonalInfo.Controls.Add(this.txtEmail);
            this.tabPersonalInfo.Controls.Add(this.lblPhone);
            this.tabPersonalInfo.Controls.Add(this.txtPhone);
            this.tabPersonalInfo.Controls.Add(this.lblAddress);
            this.tabPersonalInfo.Controls.Add(this.txtAddress);
            this.tabPersonalInfo.Controls.Add(this.lblMemberSince);
            this.tabPersonalInfo.Controls.Add(this.txtMemberSince);
            this.tabPersonalInfo.Controls.Add(this.btnSave);

            // Borrow History Tab
            this.tabBorrowHistory.Text = "Lịch sử mượn sách";
            this.tabBorrowHistory.Padding = new Padding(20);

            // History Panel
            this.historyPanel.Location = new Point(0, 0);
            this.historyPanel.Size = new Size(820, 400);
            this.historyPanel.AutoScroll = true;
            this.historyPanel.Dock = DockStyle.Fill;

            // Add controls to Borrow History tab
            this.tabBorrowHistory.Controls.Add(this.historyPanel);

            // Add tabs to TabControl
            this.tabControl.Controls.Add(this.tabPersonalInfo);
            this.tabControl.Controls.Add(this.tabBorrowHistory);

            // Add controls to ProfilePanel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.tabControl);

            // Load user data
            this.VisibleChanged += new EventHandler(this.ProfilePanel_VisibleChanged);
        }

        private void ProfilePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                UpdateProfileInfo();
                LoadBorrowHistory();
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabBorrowHistory)
            {
                LoadBorrowHistory();
            }
        }

        public void UpdateProfileInfo()
        {
            if (Library.Instance.CurrentUser != null)
            {
                User user = Library.Instance.CurrentUser;
                txtName.Text = user.Name;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                txtAddress.Text = user.Address;
                txtMemberSince.Text = user.MemberSince;
            }
        }

        private void LoadBorrowHistory()
        {
            historyPanel.Controls.Clear();

            if (Library.Instance.CurrentUser != null /*&& Library.Instance.CurrentUser.BorrowHistory != null*/)
            {
                List<BorrowHistory> history = Library.Instance.CurrentUser.BorrowHistory;

                if (history.Count == 0)
                {
                    Label lblNoHistory = new Label();
                    lblNoHistory.Text = "Bạn chưa có lịch sử mượn sách nào";
                    lblNoHistory.Location = new Point(0, 0);
                    lblNoHistory.Size = new Size(400, 30);
                    historyPanel.Controls.Add(lblNoHistory);
                }
                else
                {
                    // Sắp xếp lịch sử mượn sách theo thời gian mượn (mới nhất lên đầu)
                    history.Sort((a, b) => {
                        try
                        {
                            DateTime dateA = DateTime.ParseExact(a.BorrowDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            DateTime dateB = DateTime.ParseExact(b.BorrowDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            return dateB.CompareTo(dateA);
                        }
                        catch
                        {
                            return 0;
                        }
                    });

                    foreach (BorrowHistory borrow in history)
                    {
                        HistoryCard historyCard = new HistoryCard(borrow);
                        historyPanel.Controls.Add(historyCard);
                    }
                }
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

                // Update the navbar display name
                if (MainForm.FormManager.MainForm != null)
                {
                    MainForm.FormManager.MainForm.UpdateNavbar();
                }
            }
        }
    }

    // Card hiển thị lịch sử mượn sách
    public class HistoryCard : Panel
    {
        private BorrowHistory borrowHistory;
        private PictureBox picCover;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblBorrowDate;
        private Label lblDueDate;
        private Label lblStatus;
        private Label lblReturnDate;

        public HistoryCard(BorrowHistory borrowHistory)
        {
            this.borrowHistory = borrowHistory;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.picCover = new PictureBox();
            this.lblTitle = new Label();
            this.lblAuthor = new Label();
            this.lblBorrowDate = new Label();
            this.lblDueDate = new Label();
            this.lblStatus = new Label();
            this.lblReturnDate = new Label();

            // HistoryCard
            this.Size = new Size(780, 120);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(10);
            this.BackColor = Color.White;

            // picCover
            this.picCover.Size = new Size(80, 100);
            this.picCover.Location = new Point(10, 10);
            this.picCover.BackColor = Color.LightGray;
            this.picCover.SizeMode = PictureBoxSizeMode.Zoom;

            // lblTitle
            this.lblTitle.Text = borrowHistory.Book.Title;
            this.lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            this.lblTitle.Location = new Point(100, 10);
            this.lblTitle.Size = new Size(400, 20);

            // lblAuthor
            this.lblAuthor.Text = borrowHistory.Book.Author;
            this.lblAuthor.Location = new Point(100, 35);
            this.lblAuthor.Size = new Size(400, 20);
            this.lblAuthor.ForeColor = Color.Gray;

            // lblBorrowDate
            this.lblBorrowDate.Text = $"Ngày mượn: {borrowHistory.BorrowDate}";
            this.lblBorrowDate.Location = new Point(100, 60);
            this.lblBorrowDate.Size = new Size(200, 20);

            // lblDueDate
            this.lblDueDate.Text = $"Hạn trả: {borrowHistory.DueDate}";
            this.lblDueDate.Location = new Point(100, 85);
            this.lblDueDate.Size = new Size(200, 20);

            // lblStatus
            this.lblStatus.Text = borrowHistory.Returned ? "Đã trả" : "Đang mượn";
            this.lblStatus.Location = new Point(650, 35);
            this.lblStatus.Size = new Size(100, 20);
            this.lblStatus.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblStatus.ForeColor = borrowHistory.Returned ? Color.Green : Color.Blue;
            this.lblStatus.TextAlign = ContentAlignment.MiddleRight;

            // lblReturnDate
            if (borrowHistory.Returned && !string.IsNullOrEmpty(borrowHistory.ReturnDate))
            {
                this.lblReturnDate.Text = $"Ngày trả: {borrowHistory.ReturnDate}";
                this.lblReturnDate.Location = new Point(500, 60);
                this.lblReturnDate.Size = new Size(250, 20);
                this.lblReturnDate.TextAlign = ContentAlignment.MiddleRight;
            }

            // Add controls
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblReturnDate);
        }
    }
}

