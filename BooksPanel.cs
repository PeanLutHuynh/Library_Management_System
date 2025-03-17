using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public class BooksPanel : Panel
    {
        private Label lblTitle;
        private Label lblSubtitle;
        private FlowLayoutPanel booksPanel;
        private ComboBox cmbGenreFilter;
        private Label lblFilter;
        private Button btnViewAll;

        public BooksPanel()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.booksPanel = new FlowLayoutPanel();
            this.cmbGenreFilter = new ComboBox();
            this.lblFilter = new Label();
            this.btnViewAll = new Button();

            // lblTitle
            this.lblTitle.Text = "Danh sách sách";
            this.lblTitle.Font = new Font("Arial", 24, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(400, 40);

            // lblSubtitle
            this.lblSubtitle.Text = "Khám phá bộ sưu tập sách đa dạng của chúng tôi";
            this.lblSubtitle.Font = new Font("Arial", 10);
            this.lblSubtitle.ForeColor = Color.Gray;
            this.lblSubtitle.Location = new Point(20, 60);
            this.lblSubtitle.Size = new Size(400, 20);

            // Filter section
            Panel filterPanel = new Panel();
            filterPanel.Location = new Point(20, 90);
            filterPanel.Size = new Size(860, 40);

            // lblFilter
            this.lblFilter.Text = "Lọc theo thể loại:";
            this.lblFilter.Location = new Point(0, 10);
            this.lblFilter.Size = new Size(100, 20);
            this.lblFilter.Font = new Font("Arial", 9);

            // cmbGenreFilter
            this.cmbGenreFilter.Location = new Point(110, 8);
            this.cmbGenreFilter.Size = new Size(150, 25);
            this.cmbGenreFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGenreFilter.Items.AddRange(new object[] { "Tất cả", "Tâm lý - Kỹ năng sống", "Tiểu thuyết", "Kỹ năng sống", "Tùy bút", "Kinh tế", "Tâm linh" });
            this.cmbGenreFilter.SelectedIndex = 0;
            this.cmbGenreFilter.SelectedIndexChanged += new EventHandler(this.cmbGenreFilter_SelectedIndexChanged);

            // btnViewAll
            this.btnViewAll.Text = "Xem tất cả";
            this.btnViewAll.Location = new Point(270, 7);
            this.btnViewAll.Size = new Size(100, 25);
            this.btnViewAll.FlatStyle = FlatStyle.Flat;
            this.btnViewAll.Click += new EventHandler(this.btnViewAll_Click);

            // Add controls to filter panel
            filterPanel.Controls.Add(this.lblFilter);
            filterPanel.Controls.Add(this.cmbGenreFilter);
            filterPanel.Controls.Add(this.btnViewAll);

            // booksPanel
            this.booksPanel.Location = new Point(20, 140);
            this.booksPanel.Size = new Size(860, 440);
            this.booksPanel.AutoScroll = true;

            // BooksPanel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(filterPanel);
            this.Controls.Add(this.booksPanel);
        }

        private void cmbGenreFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGenre = cmbGenreFilter.SelectedItem.ToString();
            LoadBooks(selectedGenre);
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            cmbGenreFilter.SelectedIndex = 0;
            LoadBooks();
        }

        public void LoadBooks(string genreFilter = "")
        {
            booksPanel.Controls.Clear();

            foreach (Book book in Library.Instance.Books)
            {
                if (string.IsNullOrEmpty(genreFilter) || genreFilter == "Tất cả" || book.Genre == genreFilter)
                {
                    EnhancedBookCard bookCard = new EnhancedBookCard(book);
                    booksPanel.Controls.Add(bookCard);
                }
            }
        }
    }
}