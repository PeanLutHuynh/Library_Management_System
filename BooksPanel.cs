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
        private Panel filterPanel;

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
            this.filterPanel = new Panel();

            // BooksPanel
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.Padding = new Padding(20);

            // lblTitle - Moved down slightly
            this.lblTitle.Text = "Danh sách sách";
            this.lblTitle.Font = new Font("Arial", 24, FontStyle.Bold);
            this.lblTitle.Size = new Size(400, 30);
            this.lblTitle.Location = new Point(15, 50); // Adjusted Y from 20 to 30
            this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // lblSubtitle - Moved down and adjusted spacing
            this.lblSubtitle.Text = "Khám phá bộ sưu tập sách đa dạng của chúng tôi";
            this.lblSubtitle.Font = new Font("Arial", 10);
            this.lblSubtitle.ForeColor = Color.Gray;
            this.lblSubtitle.Size = new Size(400, 20);
            this.lblSubtitle.Location = new Point(20, 90); // Adjusted Y from 60 to 75 (30+40+5)
            this.lblSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Filter section - Position adjusted to maintain proper spacing
            this.filterPanel.Size = new Size(860, 40);
            this.filterPanel.Location = new Point(20, 105); // Adjusted from 90 to 105 (75+20+10)
            this.filterPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // lblFilter
            this.lblFilter.Text = "Lọc theo thể loại:";
            this.lblFilter.Location = new Point(0, 15);
            this.lblFilter.Size = new Size(100, 20);
            this.lblFilter.Font = new Font("Arial", 9);

            // cmbGenreFilter
            this.cmbGenreFilter.Location = new Point(110, 13);
            this.cmbGenreFilter.Size = new Size(150, 25);
            this.cmbGenreFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGenreFilter.Items.AddRange(new object[] { "Tất cả", "Tâm lý - Kỹ năng sống", "Tiểu thuyết", "Kỹ năng sống", "Tùy bút", "Kinh tế", "Tâm linh" });
            this.cmbGenreFilter.SelectedIndex = 0;
            this.cmbGenreFilter.SelectedIndexChanged += new EventHandler(this.cmbGenreFilter_SelectedIndexChanged);

            // btnViewAll
            this.btnViewAll.Text = "Xem tất cả";
            this.btnViewAll.Location = new Point(270, 12);
            this.btnViewAll.Size = new Size(100, 25);
            this.btnViewAll.FlatStyle = FlatStyle.Flat;
            this.btnViewAll.Click += new EventHandler(this.btnViewAll_Click);

            // Add controls to filter panel
            this.filterPanel.Controls.Add(this.lblFilter);
            this.filterPanel.Controls.Add(this.cmbGenreFilter);
            this.filterPanel.Controls.Add(this.btnViewAll);

            // booksPanel - Position adjusted to account for new spacing
            this.booksPanel.Location = new Point(20, 155); // Adjusted from 140 to 155 (105+40+10)
            this.booksPanel.Size = new Size(860, 440);
            this.booksPanel.AutoScroll = true;
            this.booksPanel.FlowDirection = FlowDirection.LeftToRight;
            this.booksPanel.WrapContents = true;
            this.booksPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Add all controls to the main panel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.booksPanel);

            // Add resize handler
            this.Resize += new EventHandler(this.BooksPanel_Resize);
        }

        private void BooksPanel_Resize(object sender, EventArgs e)
        {
            // Ensure proper sizing of panels when form is resized
            this.filterPanel.Width = this.ClientSize.Width - 40; // 40 for left and right padding
            this.booksPanel.Width = this.ClientSize.Width - 40;
            this.booksPanel.Height = this.ClientSize.Height - this.booksPanel.Top - 20; // 20 for bottom padding
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
                    bookCard.Margin = new Padding(31); // Increased spacing between books
                    booksPanel.Controls.Add(bookCard);
                }
            }
        }
    }
}