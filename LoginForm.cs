using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public class LoginForm : Form
    {
        private Label lblTitle;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;
        private LinkLabel lnkRegister;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnRegister = new Button();
            this.lnkRegister = new LinkLabel();

            // LoginForm
            this.ClientSize = new Size(450, 400);
            this.Text = "Đăng nhập";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(30);

            // lblTitle
            this.lblTitle.Text = "Đăng nhập";
            this.lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(0, 30);
            this.lblTitle.Size = new Size(450, 50);
            this.lblTitle.ForeColor = Color.FromArgb(17, 24, 39);

            // lblEmail
            this.lblEmail.Text = "Email:";
            this.lblEmail.Font = new Font("Segoe UI", 11);
            this.lblEmail.Location = new Point(50, 100);
            this.lblEmail.Size = new Size(100, 25);
            this.lblEmail.ForeColor = Color.FromArgb(75, 85, 99);

            // txtEmail
            this.txtEmail.Location = new Point(50, 125);
            this.txtEmail.Size = new Size(350, 30);
            this.txtEmail.Font = new Font("Segoe UI", 11);
            this.txtEmail.BorderStyle = BorderStyle.FixedSingle;
            this.txtEmail.Padding = new Padding(5);

            // lblPassword
            this.lblPassword.Text = "Mật khẩu:";
            this.lblPassword.Font = new Font("Segoe UI", 11);
            this.lblPassword.Location = new Point(50, 175);
            this.lblPassword.Size = new Size(100, 25);
            this.lblPassword.ForeColor = Color.FromArgb(75, 85, 99);

            // txtPassword
            this.txtPassword.Location = new Point(50, 200);
            this.txtPassword.Size = new Size(350, 30);
            this.txtPassword.Font = new Font("Segoe UI", 11);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.Padding = new Padding(5);
            this.txtPassword.KeyDown += new KeyEventHandler(this.txtPassword_KeyDown);

            // btnLogin
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Location = new Point(50, 260);
            this.btnLogin.Size = new Size(350, 45);
            this.btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
            // Bo góc cho nút đăng nhập
            this.btnLogin.Paint += (sender, e) => {
                var button = sender as Button;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(button.Width - 20, 0, 20, 20, 270, 90);
                path.AddArc(button.Width - 20, button.Height - 20, 20, 20, 0, 90);
                path.AddArc(0, button.Height - 20, 20, 20, 90, 90);
                button.Region = new Region(path);
            };

            // lnkRegister
            this.lnkRegister.Text = "Chưa có tài khoản? Đăng ký ngay";
            this.lnkRegister.Font = new Font("Segoe UI", 10);
            this.lnkRegister.Location = new Point(50, 320);
            this.lnkRegister.Size = new Size(350, 25);
            this.lnkRegister.TextAlign = ContentAlignment.MiddleCenter;
            this.lnkRegister.LinkColor = Color.FromArgb(37, 99, 235);
            this.lnkRegister.ActiveLinkColor = Color.FromArgb(29, 78, 216);
            this.lnkRegister.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lnkRegister.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lnkRegister);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void PerformLogin()
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ email và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = Library.Instance.FindUser(email, password);

            if (user != null)
            {
                Library.Instance.CurrentUser = user;
                user.RestoreBorrowedBooks();
                Library.Instance.SaveData();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Email hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();

            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Show();
            }
        }
    }

    public class RegisterForm : Form
    {
        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Button btnRegister;
        private Button btnCancel;

        public RegisterForm()
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
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblAddress = new Label();
            this.txtAddress = new TextBox();
            this.btnRegister = new Button();
            this.btnCancel = new Button();

            // RegisterForm
            this.ClientSize = new Size(400, 500);
            this.Text = "Đăng ký";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // lblTitle
            this.lblTitle.Text = "Đăng ký tài khoản";
            this.lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(0, 20);
            this.lblTitle.Size = new Size(400, 40);

            // lblName
            this.lblName.Text = "Họ tên:";
            this.lblName.Location = new Point(50, 70);
            this.lblName.Size = new Size(100, 20);

            // txtName
            this.txtName.Location = new Point(50, 90);
            this.txtName.Size = new Size(300, 25);

            // lblEmail
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new Point(50, 120);
            this.lblEmail.Size = new Size(100, 20);

            // txtEmail
            this.txtEmail.Location = new Point(50, 140);
            this.txtEmail.Size = new Size(300, 25);

            // lblPassword
            this.lblPassword.Text = "Mật khẩu:";
            this.lblPassword.Location = new Point(50, 170);
            this.lblPassword.Size = new Size(100, 20);

            // txtPassword
            this.txtPassword.Location = new Point(50, 190);
            this.txtPassword.Size = new Size(300, 25);
            this.txtPassword.PasswordChar = '*';

            // lblConfirmPassword
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu:";
            this.lblConfirmPassword.Location = new Point(50, 220);
            this.lblConfirmPassword.Size = new Size(150, 20);

            // txtConfirmPassword
            this.txtConfirmPassword.Location = new Point(50, 240);
            this.txtConfirmPassword.Size = new Size(300, 25);
            this.txtConfirmPassword.PasswordChar = '*';

            // lblPhone
            this.lblPhone.Text = "Số điện thoại:";
            this.lblPhone.Location = new Point(50, 270);
            this.lblPhone.Size = new Size(100, 20);

            // txtPhone
            this.txtPhone.Location = new Point(50, 290);
            this.txtPhone.Size = new Size(300, 25);

            // lblAddress
            this.lblAddress.Text = "Địa chỉ:";
            this.lblAddress.Location = new Point(50, 320);
            this.lblAddress.Size = new Size(100, 20);

            // txtAddress
            this.txtAddress.Location = new Point(50, 340);
            this.txtAddress.Size = new Size(300, 25);

            // btnRegister
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.Location = new Point(50, 380);
            this.btnRegister.Size = new Size(140, 35);
            this.btnRegister.BackColor = Color.FromArgb(37, 99, 235);
            this.btnRegister.ForeColor = Color.White;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            // btnCancel
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Location = new Point(210, 380);
            this.btnCancel.Size = new Size(140, 35);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email đã tồn tại chưa
            if (Library.Instance.IsEmailRegistered(email))
            {
                MessageBox.Show("Email này đã được đăng ký. Vui lòng sử dụng email khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo người dùng mới
            User newUser = new User(Guid.NewGuid().ToString(), name, email, password, phone, address);
            Library.Instance.AddUser(newUser);
            Library.Instance.CurrentUser = newUser;
            Library.Instance.SaveData();

            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

