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
        private Panel searchInputPanel;

        public SearchPanel()
        {
            InitializeComponent();
            this.Resize += SearchPanel_Resize;
        }

        private void SearchPanel_Resize(object sender, EventArgs e)
        {
            // Ensure proper sizing of panels when form is resized
            this.searchInputPanel.Width = this.ClientSize.Width - 40;
            this.resultsPanel.Width = this.ClientSize.Width - 40;
            this.resultsPanel.Height = this.ClientSize.Height - this.resultsPanel.Top - 20;
            // Update the width of SearchResultCard controls
            foreach (Control control in resultsPanel.Controls)
            {
                if (control is SearchResultCard)
                {
                    control.Width = resultsPanel.ClientSize.Width - 40; 
                }
            }
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.resultsPanel = new FlowLayoutPanel();
            this.cmbSearchType = new ComboBox();
            this.searchInputPanel = new Panel();

            // SearchPanel
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.Padding = new Padding(20);

            // lblTitle - Moved down and font size reduced
            this.lblTitle.Text = "Tìm kiếm sách";
            this.lblTitle.Font = new Font("Arial", 20, FontStyle.Bold); 
            this.lblTitle.Size = new Size(400, 35); 
            this.lblTitle.Location = new Point(20, 55); 
            this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // lblSubtitle - Adjusted position
            this.lblSubtitle.Text = "Tìm kiếm sách theo tên, tác giả hoặc thể loại";
            this.lblSubtitle.Font = new Font("Arial", 10);
            this.lblSubtitle.ForeColor = Color.Gray;
            this.lblSubtitle.Size = new Size(400, 20);
            this.lblSubtitle.Location = new Point(20, 95); 
            this.lblSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Search Panel - Adjusted position
            this.searchInputPanel.Location = new Point(20, 120); 
            this.searchInputPanel.Size = new Size(860, 50);
            this.searchInputPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // txtSearch
            this.txtSearch.Location = new Point(0, 10);
            this.txtSearch.Size = new Size(400, 30);
            this.txtSearch.Font = new Font("Arial", 12);
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.Padding = new Padding(5);
            this.txtSearch.KeyDown += new KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            // cmbSearchType
            this.cmbSearchType.Location = new Point(410, 13);
            this.cmbSearchType.Size = new Size(150, 30);
            this.cmbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSearchType.Items.AddRange(new object[] { "Tất cả", "Tên sách", "Tác giả", "Thể loại" });
            this.cmbSearchType.SelectedIndex = 0;
            this.cmbSearchType.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            // btnSearch
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Location = new Point(570, 10);
            this.btnSearch.Size = new Size(100, 30);
            this.btnSearch.BackColor = Color.FromArgb(17, 24, 39);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            this.btnSearch.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            // Add controls to search panel
            this.searchInputPanel.Controls.Add(this.txtSearch);
            this.searchInputPanel.Controls.Add(this.cmbSearchType);
            this.searchInputPanel.Controls.Add(this.btnSearch);

            // resultsPanel - Positioned and sized to fill remaining space
            this.resultsPanel.Location = new Point(20, 180); 
            this.resultsPanel.Size = new Size(860, 430);
            this.resultsPanel.AutoScroll = true;
            this.resultsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.resultsPanel.FlowDirection = FlowDirection.TopDown;
            this.resultsPanel.WrapContents = false;

            // Add all controls to the main panel
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.searchInputPanel);
            this.Controls.Add(this.resultsPanel);

            // Add resize handler
            this.Resize += new EventHandler(this.SearchPanel_Resize);
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
                lblNoResults.Size = new Size(resultsPanel.Width - 20, 30);
                lblNoResults.TextAlign = ContentAlignment.MiddleCenter;
                lblNoResults.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                resultsPanel.Controls.Add(lblNoResults);
            }
            else
            {
                Label lblResultCount = new Label();
                lblResultCount.Text = $"Tìm thấy {results.Count} kết quả cho \"{query}\"";
                lblResultCount.Font = new Font("Arial", 12, FontStyle.Bold);
                lblResultCount.Size = new Size(resultsPanel.Width - 20, 30);
                lblResultCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                resultsPanel.Controls.Add(lblResultCount);

                foreach (Book book in results)
                {
                    SearchResultCard bookCard = new SearchResultCard(book);
                    bookCard.Width = resultsPanel.Width - 40; 
                    bookCard.Margin = new Padding(10, 15, 10, 15); 
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