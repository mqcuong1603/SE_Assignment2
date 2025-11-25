using System;
using System.Data;
using System.Windows.Forms;
using BusinessLogicLayer;
using Models;

namespace Exercise1_WinForms
{
    public partial class AgentForm : Form
    {
        private AgentBLL agentBLL;
        private int selectedAgentId = 0;

        public AgentForm()
        {
            InitializeComponent();
            agentBLL = new AgentBLL();
        }

        private void InitializeComponent()
        {
            this.dgvAgents = new System.Windows.Forms.DataGridView();
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtTaxCode = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpAgentDetails = new System.Windows.Forms.GroupBox();
            this.lblAgentName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblTaxCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgents)).BeginInit();
            this.grpAgentDetails.SuspendLayout();
            this.SuspendLayout();

            // dgvAgents
            this.dgvAgents.AllowUserToAddRows = false;
            this.dgvAgents.AllowUserToDeleteRows = false;
            this.dgvAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgents.Location = new System.Drawing.Point(12, 50);
            this.dgvAgents.Name = "dgvAgents";
            this.dgvAgents.ReadOnly = true;
            this.dgvAgents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgents.Size = new System.Drawing.Size(760, 300);
            this.dgvAgents.TabIndex = 0;
            this.dgvAgents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgents_CellClick);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(12, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 1;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(220, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(305, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // grpAgentDetails
            this.grpAgentDetails.Controls.Add(this.lblAgentName);
            this.grpAgentDetails.Controls.Add(this.txtAgentName);
            this.grpAgentDetails.Controls.Add(this.lblCompanyName);
            this.grpAgentDetails.Controls.Add(this.txtCompanyName);
            this.grpAgentDetails.Controls.Add(this.lblAddress);
            this.grpAgentDetails.Controls.Add(this.txtAddress);
            this.grpAgentDetails.Controls.Add(this.lblPhone);
            this.grpAgentDetails.Controls.Add(this.txtPhone);
            this.grpAgentDetails.Controls.Add(this.lblEmail);
            this.grpAgentDetails.Controls.Add(this.txtEmail);
            this.grpAgentDetails.Controls.Add(this.lblTaxCode);
            this.grpAgentDetails.Controls.Add(this.txtTaxCode);
            this.grpAgentDetails.Controls.Add(this.chkIsActive);
            this.grpAgentDetails.Location = new System.Drawing.Point(12, 360);
            this.grpAgentDetails.Name = "grpAgentDetails";
            this.grpAgentDetails.Size = new System.Drawing.Size(760, 200);
            this.grpAgentDetails.TabIndex = 4;
            this.grpAgentDetails.TabStop = false;
            this.grpAgentDetails.Text = "Agent Details";

            // lblAgentName
            this.lblAgentName.AutoSize = true;
            this.lblAgentName.Location = new System.Drawing.Point(20, 30);
            this.lblAgentName.Name = "lblAgentName";
            this.lblAgentName.Size = new System.Drawing.Size(69, 13);
            this.lblAgentName.Text = "Agent Name:";

            // txtAgentName
            this.txtAgentName.Location = new System.Drawing.Point(110, 27);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.Size = new System.Drawing.Size(250, 20);
            this.txtAgentName.TabIndex = 0;

            // lblCompanyName
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(400, 30);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(85, 13);
            this.lblCompanyName.Text = "Company Name:";

            // txtCompanyName
            this.txtCompanyName.Location = new System.Drawing.Point(490, 27);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(250, 20);
            this.txtCompanyName.TabIndex = 1;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 60);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.Text = "Address:";

            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(110, 57);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(630, 40);
            this.txtAddress.TabIndex = 2;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 110);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.Text = "Phone:";

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(110, 107);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 20);
            this.txtPhone.TabIndex = 3;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(400, 110);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(490, 107);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 20);
            this.txtEmail.TabIndex = 4;

            // lblTaxCode
            this.lblTaxCode.AutoSize = true;
            this.lblTaxCode.Location = new System.Drawing.Point(20, 140);
            this.lblTaxCode.Name = "lblTaxCode";
            this.lblTaxCode.Size = new System.Drawing.Size(56, 13);
            this.lblTaxCode.Text = "Tax Code:";

            // txtTaxCode
            this.txtTaxCode.Location = new System.Drawing.Point(110, 137);
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Size = new System.Drawing.Size(250, 20);
            this.txtTaxCode.TabIndex = 5;

            // chkIsActive
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(110, 170);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(67, 17);
            this.chkIsActive.TabIndex = 6;
            this.chkIsActive.Text = "Is Active";

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(122, 570);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(230, 570);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(338, 570);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(446, 570);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // AgentForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grpAgentDetails);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvAgents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AgentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agent Management";
            this.Load += new System.EventHandler(this.AgentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgents)).EndInit();
            this.grpAgentDetails.ResumeLayout(false);
            this.grpAgentDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvAgents;
        private System.Windows.Forms.TextBox txtAgentName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtTaxCode;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpAgentDetails;
        private System.Windows.Forms.Label lblAgentName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblTaxCode;

        private void AgentForm_Load(object sender, EventArgs e)
        {
            LoadAgents();
        }

        private void LoadAgents()
        {
            try
            {
                DataTable dt = agentBLL.GetAllAgents();
                dgvAgents.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading agents: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAgents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAgents.Rows[e.RowIndex];
                selectedAgentId = Convert.ToInt32(row.Cells["AgentID"].Value);
                txtAgentName.Text = row.Cells["AgentName"].Value.ToString();
                txtCompanyName.Text = row.Cells["CompanyName"].Value?.ToString();
                txtAddress.Text = row.Cells["Address"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtTaxCode.Text = row.Cells["TaxCode"].Value?.ToString();
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Agent agent = new Agent
                {
                    AgentName = txtAgentName.Text,
                    CompanyName = txtCompanyName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    TaxCode = txtTaxCode.Text,
                    IsActive = chkIsActive.Checked
                };

                if (agentBLL.InsertAgent(agent))
                {
                    MessageBox.Show("Agent added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAgents();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding agent: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAgentId == 0)
            {
                MessageBox.Show("Please select an agent to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Agent agent = new Agent
                {
                    AgentID = selectedAgentId,
                    AgentName = txtAgentName.Text,
                    CompanyName = txtCompanyName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    TaxCode = txtTaxCode.Text,
                    IsActive = chkIsActive.Checked
                };

                if (agentBLL.UpdateAgent(agent))
                {
                    MessageBox.Show("Agent updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAgents();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating agent: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAgentId == 0)
            {
                MessageBox.Show("Please select an agent to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this agent?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (agentBLL.DeleteAgent(selectedAgentId))
                    {
                    MessageBox.Show("Agent deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAgents();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting agent: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = agentBLL.SearchAgents(txtSearch.Text);
                dgvAgents.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching agents: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAgents();
            txtSearch.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedAgentId = 0;
            txtAgentName.Clear();
            txtCompanyName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtTaxCode.Clear();
            chkIsActive.Checked = true;
        }
    }
}
