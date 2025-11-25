using System;
using System.Data;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace Exercise1_WinForms
{
    public partial class FilterForm : Form
    {
        private ItemBLL itemBLL;
        private AgentBLL agentBLL;
        private OrderBLL orderBLL;

        public FilterForm()
        {
            InitializeComponent();
            itemBLL = new ItemBLL();
            agentBLL = new AgentBLL();
            orderBLL = new OrderBLL();
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBestSellingItems = new System.Windows.Forms.TabPage();
            this.tabTopCustomers = new System.Windows.Forms.TabPage();
            this.tabItemsByCustomer = new System.Windows.Forms.TabPage();
            this.tabCustomersByItem = new System.Windows.Forms.TabPage();
            this.tabOrdersByStatus = new System.Windows.Forms.TabPage();
            this.dgvBestSellingItems = new System.Windows.Forms.DataGridView();
            this.dgvTopCustomers = new System.Windows.Forms.DataGridView();
            this.dgvItemsByCustomer = new System.Windows.Forms.DataGridView();
            this.dgvCustomersByItem = new System.Windows.Forms.DataGridView();
            this.dgvOrdersByStatus = new System.Windows.Forms.DataGridView();
            this.cboAgentForItems = new System.Windows.Forms.ComboBox();
            this.cboItemForCustomers = new System.Windows.Forms.ComboBox();
            this.cboOrderStatus = new System.Windows.Forms.ComboBox();
            this.btnLoadItemsByCustomer = new System.Windows.Forms.Button();
            this.btnLoadCustomersByItem = new System.Windows.Forms.Button();
            this.btnLoadOrdersByStatus = new System.Windows.Forms.Button();
            this.lblSelectAgent = new System.Windows.Forms.Label();
            this.lblSelectItem = new System.Windows.Forms.Label();
            this.lblSelectStatus = new System.Windows.Forms.Label();
            this.btnExportBestItems = new System.Windows.Forms.Button();
            this.btnExportTopCustomers = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabBestSellingItems.SuspendLayout();
            this.tabTopCustomers.SuspendLayout();
            this.tabItemsByCustomer.SuspendLayout();
            this.tabCustomersByItem.SuspendLayout();
            this.tabOrdersByStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSellingItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsByCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersByItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersByStatus)).BeginInit();
            this.SuspendLayout();

            // tabControl1
            this.tabControl1.Controls.Add(this.tabBestSellingItems);
            this.tabControl1.Controls.Add(this.tabTopCustomers);
            this.tabControl1.Controls.Add(this.tabItemsByCustomer);
            this.tabControl1.Controls.Add(this.tabCustomersByItem);
            this.tabControl1.Controls.Add(this.tabOrdersByStatus);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;

            // tabBestSellingItems
            this.tabBestSellingItems.Controls.Add(this.btnExportBestItems);
            this.tabBestSellingItems.Controls.Add(this.dgvBestSellingItems);
            this.tabBestSellingItems.Location = new System.Drawing.Point(4, 22);
            this.tabBestSellingItems.Name = "tabBestSellingItems";
            this.tabBestSellingItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabBestSellingItems.Size = new System.Drawing.Size(792, 424);
            this.tabBestSellingItems.TabIndex = 0;
            this.tabBestSellingItems.Text = "Best Selling Items";
            this.tabBestSellingItems.UseVisualStyleBackColor = true;

            // dgvBestSellingItems
            this.dgvBestSellingItems.AllowUserToAddRows = false;
            this.dgvBestSellingItems.AllowUserToDeleteRows = false;
            this.dgvBestSellingItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBestSellingItems.Location = new System.Drawing.Point(10, 10);
            this.dgvBestSellingItems.Name = "dgvBestSellingItems";
            this.dgvBestSellingItems.ReadOnly = true;
            this.dgvBestSellingItems.Size = new System.Drawing.Size(770, 370);
            this.dgvBestSellingItems.TabIndex = 0;

            // btnExportBestItems
            this.btnExportBestItems.Location = new System.Drawing.Point(650, 386);
            this.btnExportBestItems.Name = "btnExportBestItems";
            this.btnExportBestItems.Size = new System.Drawing.Size(130, 30);
            this.btnExportBestItems.TabIndex = 1;
            this.btnExportBestItems.Text = "Export to CSV";
            this.btnExportBestItems.UseVisualStyleBackColor = true;
            this.btnExportBestItems.Click += new System.EventHandler(this.btnExportBestItems_Click);

            // tabTopCustomers
            this.tabTopCustomers.Controls.Add(this.btnExportTopCustomers);
            this.tabTopCustomers.Controls.Add(this.dgvTopCustomers);
            this.tabTopCustomers.Location = new System.Drawing.Point(4, 22);
            this.tabTopCustomers.Name = "tabTopCustomers";
            this.tabTopCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabTopCustomers.Size = new System.Drawing.Size(792, 424);
            this.tabTopCustomers.TabIndex = 1;
            this.tabTopCustomers.Text = "Top Customers";
            this.tabTopCustomers.UseVisualStyleBackColor = true;

            // dgvTopCustomers
            this.dgvTopCustomers.AllowUserToAddRows = false;
            this.dgvTopCustomers.AllowUserToDeleteRows = false;
            this.dgvTopCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopCustomers.Location = new System.Drawing.Point(10, 10);
            this.dgvTopCustomers.Name = "dgvTopCustomers";
            this.dgvTopCustomers.ReadOnly = true;
            this.dgvTopCustomers.Size = new System.Drawing.Size(770, 370);
            this.dgvTopCustomers.TabIndex = 0;

            // btnExportTopCustomers
            this.btnExportTopCustomers.Location = new System.Drawing.Point(650, 386);
            this.btnExportTopCustomers.Name = "btnExportTopCustomers";
            this.btnExportTopCustomers.Size = new System.Drawing.Size(130, 30);
            this.btnExportTopCustomers.TabIndex = 1;
            this.btnExportTopCustomers.Text = "Export to CSV";
            this.btnExportTopCustomers.UseVisualStyleBackColor = true;
            this.btnExportTopCustomers.Click += new System.EventHandler(this.btnExportTopCustomers_Click);

            // tabItemsByCustomer
            this.tabItemsByCustomer.Controls.Add(this.btnLoadItemsByCustomer);
            this.tabItemsByCustomer.Controls.Add(this.cboAgentForItems);
            this.tabItemsByCustomer.Controls.Add(this.lblSelectAgent);
            this.tabItemsByCustomer.Controls.Add(this.dgvItemsByCustomer);
            this.tabItemsByCustomer.Location = new System.Drawing.Point(4, 22);
            this.tabItemsByCustomer.Name = "tabItemsByCustomer";
            this.tabItemsByCustomer.Size = new System.Drawing.Size(792, 424);
            this.tabItemsByCustomer.TabIndex = 2;
            this.tabItemsByCustomer.Text = "Items by Customer";
            this.tabItemsByCustomer.UseVisualStyleBackColor = true;

            // lblSelectAgent
            this.lblSelectAgent.AutoSize = true;
            this.lblSelectAgent.Location = new System.Drawing.Point(10, 15);
            this.lblSelectAgent.Name = "lblSelectAgent";
            this.lblSelectAgent.Size = new System.Drawing.Size(83, 13);
            this.lblSelectAgent.Text = "Select Customer:";

            // cboAgentForItems
            this.cboAgentForItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgentForItems.FormattingEnabled = true;
            this.cboAgentForItems.Location = new System.Drawing.Point(100, 12);
            this.cboAgentForItems.Name = "cboAgentForItems";
            this.cboAgentForItems.Size = new System.Drawing.Size(300, 21);
            this.cboAgentForItems.TabIndex = 0;

            // btnLoadItemsByCustomer
            this.btnLoadItemsByCustomer.Location = new System.Drawing.Point(410, 10);
            this.btnLoadItemsByCustomer.Name = "btnLoadItemsByCustomer";
            this.btnLoadItemsByCustomer.Size = new System.Drawing.Size(100, 25);
            this.btnLoadItemsByCustomer.TabIndex = 1;
            this.btnLoadItemsByCustomer.Text = "Load Items";
            this.btnLoadItemsByCustomer.UseVisualStyleBackColor = true;
            this.btnLoadItemsByCustomer.Click += new System.EventHandler(this.btnLoadItemsByCustomer_Click);

            // dgvItemsByCustomer
            this.dgvItemsByCustomer.AllowUserToAddRows = false;
            this.dgvItemsByCustomer.AllowUserToDeleteRows = false;
            this.dgvItemsByCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsByCustomer.Location = new System.Drawing.Point(10, 45);
            this.dgvItemsByCustomer.Name = "dgvItemsByCustomer";
            this.dgvItemsByCustomer.ReadOnly = true;
            this.dgvItemsByCustomer.Size = new System.Drawing.Size(770, 370);
            this.dgvItemsByCustomer.TabIndex = 2;

            // tabCustomersByItem
            this.tabCustomersByItem.Controls.Add(this.btnLoadCustomersByItem);
            this.tabCustomersByItem.Controls.Add(this.cboItemForCustomers);
            this.tabCustomersByItem.Controls.Add(this.lblSelectItem);
            this.tabCustomersByItem.Controls.Add(this.dgvCustomersByItem);
            this.tabCustomersByItem.Location = new System.Drawing.Point(4, 22);
            this.tabCustomersByItem.Name = "tabCustomersByItem";
            this.tabCustomersByItem.Size = new System.Drawing.Size(792, 424);
            this.tabCustomersByItem.TabIndex = 3;
            this.tabCustomersByItem.Text = "Customers by Item";
            this.tabCustomersByItem.UseVisualStyleBackColor = true;

            // lblSelectItem
            this.lblSelectItem.AutoSize = true;
            this.lblSelectItem.Location = new System.Drawing.Point(10, 15);
            this.lblSelectItem.Name = "lblSelectItem";
            this.lblSelectItem.Size = new System.Drawing.Size(63, 13);
            this.lblSelectItem.Text = "Select Item:";

            // cboItemForCustomers
            this.cboItemForCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemForCustomers.FormattingEnabled = true;
            this.cboItemForCustomers.Location = new System.Drawing.Point(80, 12);
            this.cboItemForCustomers.Name = "cboItemForCustomers";
            this.cboItemForCustomers.Size = new System.Drawing.Size(320, 21);
            this.cboItemForCustomers.TabIndex = 0;

            // btnLoadCustomersByItem
            this.btnLoadCustomersByItem.Location = new System.Drawing.Point(410, 10);
            this.btnLoadCustomersByItem.Name = "btnLoadCustomersByItem";
            this.btnLoadCustomersByItem.Size = new System.Drawing.Size(120, 25);
            this.btnLoadCustomersByItem.TabIndex = 1;
            this.btnLoadCustomersByItem.Text = "Load Customers";
            this.btnLoadCustomersByItem.UseVisualStyleBackColor = true;
            this.btnLoadCustomersByItem.Click += new System.EventHandler(this.btnLoadCustomersByItem_Click);

            // dgvCustomersByItem
            this.dgvCustomersByItem.AllowUserToAddRows = false;
            this.dgvCustomersByItem.AllowUserToDeleteRows = false;
            this.dgvCustomersByItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomersByItem.Location = new System.Drawing.Point(10, 45);
            this.dgvCustomersByItem.Name = "dgvCustomersByItem";
            this.dgvCustomersByItem.ReadOnly = true;
            this.dgvCustomersByItem.Size = new System.Drawing.Size(770, 370);
            this.dgvCustomersByItem.TabIndex = 2;

            // tabOrdersByStatus
            this.tabOrdersByStatus.Controls.Add(this.btnLoadOrdersByStatus);
            this.tabOrdersByStatus.Controls.Add(this.cboOrderStatus);
            this.tabOrdersByStatus.Controls.Add(this.lblSelectStatus);
            this.tabOrdersByStatus.Controls.Add(this.dgvOrdersByStatus);
            this.tabOrdersByStatus.Location = new System.Drawing.Point(4, 22);
            this.tabOrdersByStatus.Name = "tabOrdersByStatus";
            this.tabOrdersByStatus.Size = new System.Drawing.Size(792, 424);
            this.tabOrdersByStatus.TabIndex = 4;
            this.tabOrdersByStatus.Text = "Orders by Status";
            this.tabOrdersByStatus.UseVisualStyleBackColor = true;

            // lblSelectStatus
            this.lblSelectStatus.AutoSize = true;
            this.lblSelectStatus.Location = new System.Drawing.Point(10, 15);
            this.lblSelectStatus.Name = "lblSelectStatus";
            this.lblSelectStatus.Size = new System.Drawing.Size(73, 13);
            this.lblSelectStatus.Text = "Select Status:";

            // cboOrderStatus
            this.cboOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderStatus.FormattingEnabled = true;
            this.cboOrderStatus.Items.AddRange(new object[] { "Pending", "Confirmed", "Shipped", "Delivered", "Cancelled" });
            this.cboOrderStatus.Location = new System.Drawing.Point(90, 12);
            this.cboOrderStatus.Name = "cboOrderStatus";
            this.cboOrderStatus.Size = new System.Drawing.Size(200, 21);
            this.cboOrderStatus.TabIndex = 0;

            // btnLoadOrdersByStatus
            this.btnLoadOrdersByStatus.Location = new System.Drawing.Point(300, 10);
            this.btnLoadOrdersByStatus.Name = "btnLoadOrdersByStatus";
            this.btnLoadOrdersByStatus.Size = new System.Drawing.Size(100, 25);
            this.btnLoadOrdersByStatus.TabIndex = 1;
            this.btnLoadOrdersByStatus.Text = "Load Orders";
            this.btnLoadOrdersByStatus.UseVisualStyleBackColor = true;
            this.btnLoadOrdersByStatus.Click += new System.EventHandler(this.btnLoadOrdersByStatus_Click);

            // dgvOrdersByStatus
            this.dgvOrdersByStatus.AllowUserToAddRows = false;
            this.dgvOrdersByStatus.AllowUserToDeleteRows = false;
            this.dgvOrdersByStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersByStatus.Location = new System.Drawing.Point(10, 45);
            this.dgvOrdersByStatus.Name = "dgvOrdersByStatus";
            this.dgvOrdersByStatus.ReadOnly = true;
            this.dgvOrdersByStatus.Size = new System.Drawing.Size(770, 370);
            this.dgvOrdersByStatus.TabIndex = 2;

            // FilterForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter & Reports";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabBestSellingItems.ResumeLayout(false);
            this.tabTopCustomers.ResumeLayout(false);
            this.tabItemsByCustomer.ResumeLayout(false);
            this.tabItemsByCustomer.PerformLayout();
            this.tabCustomersByItem.ResumeLayout(false);
            this.tabCustomersByItem.PerformLayout();
            this.tabOrdersByStatus.ResumeLayout(false);
            this.tabOrdersByStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSellingItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsByCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersByItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersByStatus)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBestSellingItems;
        private System.Windows.Forms.TabPage tabTopCustomers;
        private System.Windows.Forms.TabPage tabItemsByCustomer;
        private System.Windows.Forms.TabPage tabCustomersByItem;
        private System.Windows.Forms.TabPage tabOrdersByStatus;
        private System.Windows.Forms.DataGridView dgvBestSellingItems;
        private System.Windows.Forms.DataGridView dgvTopCustomers;
        private System.Windows.Forms.DataGridView dgvItemsByCustomer;
        private System.Windows.Forms.DataGridView dgvCustomersByItem;
        private System.Windows.Forms.DataGridView dgvOrdersByStatus;
        private System.Windows.Forms.ComboBox cboAgentForItems;
        private System.Windows.Forms.ComboBox cboItemForCustomers;
        private System.Windows.Forms.ComboBox cboOrderStatus;
        private System.Windows.Forms.Button btnLoadItemsByCustomer;
        private System.Windows.Forms.Button btnLoadCustomersByItem;
        private System.Windows.Forms.Button btnLoadOrdersByStatus;
        private System.Windows.Forms.Label lblSelectAgent;
        private System.Windows.Forms.Label lblSelectItem;
        private System.Windows.Forms.Label lblSelectStatus;
        private System.Windows.Forms.Button btnExportBestItems;
        private System.Windows.Forms.Button btnExportTopCustomers;

        private void FilterForm_Load(object sender, EventArgs e)
        {
            LoadBestSellingItems();
            LoadTopCustomers();
            LoadAgents();
            LoadItems();
            if (cboOrderStatus.Items.Count > 0)
                cboOrderStatus.SelectedIndex = 0;
        }

        private void LoadBestSellingItems()
        {
            try
            {
                DataTable dt = itemBLL.GetBestSellingItems();
                dgvBestSellingItems.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading best selling items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTopCustomers()
        {
            try
            {
                DataTable dt = agentBLL.GetTopCustomers();
                dgvTopCustomers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top customers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAgents()
        {
            try
            {
                DataTable dt = agentBLL.GetActiveAgents();
                cboAgentForItems.DataSource = dt;
                cboAgentForItems.DisplayMember = "AgentName";
                cboAgentForItems.ValueMember = "AgentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading agents: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItems()
        {
            try
            {
                DataTable dt = itemBLL.GetActiveItems();
                cboItemForCustomers.DataSource = dt;
                cboItemForCustomers.DisplayMember = "ItemName";
                cboItemForCustomers.ValueMember = "ItemID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadItemsByCustomer_Click(object sender, EventArgs e)
        {
            if (cboAgentForItems.SelectedValue == null)
            {
                MessageBox.Show("Please select a customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int agentId = Convert.ToInt32(cboAgentForItems.SelectedValue);
                DataTable dt = itemBLL.GetItemsByAgent(agentId);
                dgvItemsByCustomer.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items by customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadCustomersByItem_Click(object sender, EventArgs e)
        {
            if (cboItemForCustomers.SelectedValue == null)
            {
                MessageBox.Show("Please select an item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int itemId = Convert.ToInt32(cboItemForCustomers.SelectedValue);
                DataTable dt = agentBLL.GetAgentsByItem(itemId);
                dgvCustomersByItem.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers by item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadOrdersByStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboOrderStatus.Text))
            {
                MessageBox.Show("Please select a status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string status = cboOrderStatus.Text;
                DataTable dt = orderBLL.GetOrdersByStatus(status);
                dgvOrdersByStatus.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders by status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportBestItems_Click(object sender, EventArgs e)
        {
            ExportToCSV(dgvBestSellingItems, "BestSellingItems.csv");
        }

        private void btnExportTopCustomers_Click(object sender, EventArgs e)
        {
            ExportToCSV(dgvTopCustomers, "TopCustomers.csv");
        }

        private void ExportToCSV(DataGridView dgv, string fileName)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = fileName;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        sb.Append(col.HeaderText + ",");
                    }
                    sb.AppendLine();

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                sb.Append(cell.Value?.ToString() + ",");
                            }
                            sb.AppendLine();
                        }
                    }

                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
                    MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
