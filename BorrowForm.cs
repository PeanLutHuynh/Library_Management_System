using System;
using System.Windows.Forms;
using System.Drawing;

namespace LibraryManagementSystem
{
    public class BorrowForm : Form
    {
        private DateTimePicker dtpBorrowDate;
        private DateTimePicker dtpReturnDate;
        private Button btnBorrow;
        private Button btnCancel;
        private Book book;
        private Label lblTitle;
        private Label lblBorrowDate;
        private Label lblReturnDate;
        private Label lblBookTitle;

        public BorrowForm(Book book)
        {
            InitializeComponent();
            this.book = book;
            this.lblBookTitle.Text = book.Title;
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblBookTitle = new Label();
            this.lblBorrowDate = new Label();
            this.lblReturnDate = new Label();
            this.dtpBorrowDate = new DateTimePicker();
            this.dtpReturnDate = new DateTimePicker();
            this.btnBorrow = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // Form settings
            this.ClientSize = new System.Drawing.Size(450, 350);
            this.Text = "Mượn sách";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.Padding = new Padding(20);

            // lblTitle
            this.lblTitle = new Label();
            this.lblTitle.Text = "Mượn sách";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.Size = new System.Drawing.Size(450, 40);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblBookTitle
            this.lblBookTitle = new Label();
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.Location = new System.Drawing.Point(50, 70);
            this.lblBookTitle.Size = new System.Drawing.Size(350, 25);
            this.lblBookTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBookTitle.ForeColor = Color.FromArgb(37, 99, 235);

            // lblBorrowDate
            this.lblBorrowDate = new Label();
            this.lblBorrowDate.Text = "Ngày mượn:";
            this.lblBorrowDate.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblBorrowDate.Location = new System.Drawing.Point(50, 120);
            this.lblBorrowDate.Size = new System.Drawing.Size(120, 25);

            // dtpBorrowDate
            this.dtpBorrowDate.Location = new System.Drawing.Point(180, 120);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new System.Drawing.Size(220, 25);
            this.dtpBorrowDate.Font = new System.Drawing.Font("Segoe UI", 10);
            this.dtpBorrowDate.TabIndex = 0;
            this.dtpBorrowDate.Value = DateTime.Now;
            this.dtpBorrowDate.Format = DateTimePickerFormat.Short;
            this.dtpBorrowDate.MinDate = DateTime.Now;
            this.dtpBorrowDate.MaxDate = DateTime.Now.AddDays(7);

            // lblReturnDate
            this.lblReturnDate = new Label();
            this.lblReturnDate.Text = "Ngày trả:";
            this.lblReturnDate.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblReturnDate.Location = new System.Drawing.Point(50, 170);
            this.lblReturnDate.Size = new System.Drawing.Size(120, 25);

            // dtpReturnDate
            this.dtpReturnDate.Location = new System.Drawing.Point(180, 170);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(220, 25);
            this.dtpReturnDate.Font = new System.Drawing.Font("Segoe UI", 10);
            this.dtpReturnDate.TabIndex = 1;
            this.dtpReturnDate.Value = DateTime.Now.AddDays(1);
            this.dtpReturnDate.Format = DateTimePickerFormat.Short;
            this.dtpReturnDate.MinDate = DateTime.Now.AddDays(1);
            this.dtpReturnDate.MaxDate = DateTime.Now.AddDays(30);

            // btnBorrow
            this.btnBorrow.Location = new System.Drawing.Point(100, 240);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(120, 40);
            this.btnBorrow.TabIndex = 2;
            this.btnBorrow.Text = "Mượn sách";
            this.btnBorrow.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            this.btnBorrow.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.FlatStyle = FlatStyle.Flat;
            this.btnBorrow.FlatAppearance.BorderSize = 0;
            this.btnBorrow.Cursor = Cursors.Hand;
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(230, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls to form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblBookTitle);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.dtpBorrowDate);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            // Check if user is logged in
            if (Library.Instance.CurrentUser == null)
            {
                DialogResult result = MessageBox.Show("Bạn cần đăng nhập để mượn sách. Bạn có muốn đăng nhập ngay bây giờ không?",
                    "Yêu cầu đăng nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Show login form
                    LoginForm loginForm = new LoginForm();
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // If login successful, proceed to borrow book
                        ProcessBorrowBook();
                    }
                    else
                    {
                        // If login failed, close the form
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                return;
            }

            ProcessBorrowBook();
        }

        private void ProcessBorrowBook()
        {
            DateTime borrowDate = dtpBorrowDate.Value;
            DateTime returnDate = dtpReturnDate.Value;

            if (returnDate <= borrowDate)
            {
                MessageBox.Show("Ngày trả sách phải sau ngày mượn sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message = Library.Instance.CurrentUser.BorrowBook(book, borrowDate, returnDate);

            MessageBox.Show($"Chúc mừng! {message}\nVui lòng đến thư viện vào ngày {borrowDate.ToString("dd/MM/yyyy")} để nhận sách.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Update all panels
            if (MainForm.FormManager.MainForm != null)
            {
                MainForm.FormManager.MainForm.Invoke((MethodInvoker)delegate
                {
                    MainForm.FormManager.MainForm.UpdateAllPanels();
                });
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

