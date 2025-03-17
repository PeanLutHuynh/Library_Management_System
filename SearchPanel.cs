using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public class SearchPanel : Panel
    {
        private Label lblTitle;
        private Label lblSubtitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private FlowLayoutPanel resultsPanel;
        private ComboBox cmbSearchType;

        public SearchPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.resultsPanel = new FlowLayoutPanel();
            this.cmbSearchType = new ComboBox();

            // lblTitle
            this.lblTitle.Text = "Tìm kiếm sách";
            this.lblTitle.Font = new Font("Arial", 24, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(400, 40);

            // lblSubtitle
            this.lblSubtitle.Text = "Tìm kiếm sách theo tên, tác giả hoặc thể loại";
            this.lblSubtitle.Font = new Font("Arial", 10);
            this.lblSubtitle.ForeColor = Color.Gray;
            this.lblSubtitle.Location = new Point(20, 60);
            this.lblSubtitle.Size = new Size(400, 20);

            // Search Panel
            Panel searchInputPanel = new Panel();
            searchInputPanel.Location = new Point(20, 90);
            searchInputPanel.Size = new Size(860, 50);

            // txtSearch
            this.txtSearch.Location = new Point(0, 10);
            this.txtSearch.Size = new Size(400, 30);
            this.txtSearch.Font = new Font("Arial", 12);
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.Padding = new Padding(5);
            this.txtSearch.KeyDown += new KeyEventHandler(this.txtSearch_KeyDown);

            // cmbSearchType
            this.cmbSearchType.Location = new Point(410, 10);
            this.cmbSearchType.Size = new Size(150, 30);
            this.cmbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSearchType.Items.AddRange(new object[] { "Tất cả", "Tên sách", "Tác giả", "Thể loại" });
            this.cmbSearchType.SelectedIndex = 0;

            // btnSearch
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Location = new Point(570, 10);
            this.btnSearch.Size = new Size(100, 30);
            this.btnSearch.BackColor = Color.FromArgb(17, 24, 39);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // Add controls to search panel
            searchInputPanel.Controls.Add(this.txtSearch);
            searchInputPanel.Controls.Add(this.cmbSearchType);
            searchInputPanel.Controls.Add(this.btnSearch);

            // resultsPanel
            this.resultsPanel.Location = new Point(20, 150);
            this.resultsPanel.Size = new Size(860, 430);
            this.resultsPanel.AutoScroll = true;

            // SearchPanel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(searchInputPanel);
            this.Controls.Add(this.resultsPanel);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void PerformSearch()
        {
            string query = txtSearch.Text.Trim();
            string searchType = cmbSearchType.SelectedItem.ToString();

            if (string.IsNullOrEmpty(query))
            {
                return;
            }

            List<Book> results = Library.Instance.SearchBooks(query, searchType);

            resultsPanel.Controls.Clear();

            if (results.Count == 0)
            {
                Label lblNoResults = new Label();
                lblNoResults.Text = $"Không tìm thấy kết quả nào phù hợp với từ khóa \"{query}\"";
                lblNoResults.Font = new Font("Arial", 12);
                lblNoResults.Location = new Point(0, 0);
                lblNoResults.Size = new Size(860, 30);
                lblNoResults.TextAlign = ContentAlignment.MiddleCenter;
                resultsPanel.Controls.Add(lblNoResults);
            }
            else
            {
                Label lblResultCount = new Label();
                lblResultCount.Text = $"Tìm thấy {results.Count} kết quả cho \"{query}\"";
                lblResultCount.Font = new Font("Arial", 12, FontStyle.Bold);
                lblResultCount.Location = new Point(0, 0);
                lblResultCount.Size = new Size(860, 30);
                resultsPanel.Controls.Add(lblResultCount);

                foreach (Book book in results)
                {
                    SearchResultCard bookCard = new SearchResultCard(book);
                    resultsPanel.Controls.Add(bookCard);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }
    }
}