using System;
using System.Drawing;
using System.Windows.Forms;

namespace Exercise1_WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.panelQuickActions = new System.Windows.Forms.Panel();
            this.btnQuickItems = new System.Windows.Forms.Button();
            this.btnQuickAgents = new System.Windows.Forms.Button();
            this.btnQuickOrders = new System.Windows.Forms.Button();
            this.btnQuickReports = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer();
            this.menuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.panelQuickActions.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // menuStrip1
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.masterDataToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 31);
            this.menuStrip1.TabIndex = 0;

            // fileToolStripMenuItem
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.fileToolStripMenuItem.Text = "File";

            // logoutToolStripMenuItem
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);

            // toolStripSeparator1
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);

            // exitToolStripMenuItem
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);

            // masterDataToolStripMenuItem
            this.masterDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsToolStripMenuItem,
            this.agentsToolStripMenuItem});
            this.masterDataToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            this.masterDataToolStripMenuItem.Size = new System.Drawing.Size(95, 23);
            this.masterDataToolStripMenuItem.Text = "Master Data";

            // itemsToolStripMenuItem
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.itemsToolStripMenuItem.Text = "Items";
            this.itemsToolStripMenuItem.Click += new System.EventHandler(this.itemsToolStripMenuItem_Click);

            // agentsToolStripMenuItem
            this.agentsToolStripMenuItem.Name = "agentsToolStripMenuItem";
            this.agentsToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.agentsToolStripMenuItem.Text = "Agents";
            this.agentsToolStripMenuItem.Click += new System.EventHandler(this.agentsToolStripMenuItem_Click);

            // transactionsToolStripMenuItem
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordersToolStripMenuItem});
            this.transactionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(95, 23);
            this.transactionsToolStripMenuItem.Text = "Transactions";

            // ordersToolStripMenuItem
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.ordersToolStripMenuItem.Text = "Orders";
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);

            // reportsToolStripMenuItem
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterReportsToolStripMenuItem});
            this.reportsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.reportsToolStripMenuItem.Text = "Reports";

            // filterReportsToolStripMenuItem
            this.filterReportsToolStripMenuItem.Name = "filterReportsToolStripMenuItem";
            this.filterReportsToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.filterReportsToolStripMenuItem.Text = "Filter Reports";
            this.filterReportsToolStripMenuItem.Click += new System.EventHandler(this.filterReportsToolStripMenuItem_Click);

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.panelTop.Controls.Add(this.lblWelcome);
            this.panelTop.Controls.Add(this.lblUserInfo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 31);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 80);
            this.panelTop.TabIndex = 1;

            // lblWelcome
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(800, 35);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Order Management System";

            // lblUserInfo
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.lblUserInfo.Location = new System.Drawing.Point(20, 50);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(800, 25);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Welcome User";

            // panelDashboard
            this.panelDashboard.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelDashboard.Controls.Add(this.lblDashboardTitle);
            this.panelDashboard.Controls.Add(this.panelQuickActions);
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(0, 111);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Padding = new System.Windows.Forms.Padding(20);
            this.panelDashboard.Size = new System.Drawing.Size(1200, 539);
            this.panelDashboard.TabIndex = 2;

            // lblDashboardTitle
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblDashboardTitle.Location = new System.Drawing.Point(20, 30);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(300, 35);
            this.lblDashboardTitle.TabIndex = 0;
            this.lblDashboardTitle.Text = "Quick Actions";

            // panelQuickActions
            this.panelQuickActions.BackColor = System.Drawing.Color.White;
            this.panelQuickActions.Controls.Add(this.btnQuickItems);
            this.panelQuickActions.Controls.Add(this.btnQuickAgents);
            this.panelQuickActions.Controls.Add(this.btnQuickOrders);
            this.panelQuickActions.Controls.Add(this.btnQuickReports);
            this.panelQuickActions.Location = new System.Drawing.Point(25, 80);
            this.panelQuickActions.Name = "panelQuickActions";
            this.panelQuickActions.Padding = new System.Windows.Forms.Padding(30);
            this.panelQuickActions.Size = new System.Drawing.Size(1150, 180);
            this.panelQuickActions.TabIndex = 1;

            // btnQuickItems
            this.btnQuickItems.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnQuickItems.FlatAppearance.BorderSize = 0;
            this.btnQuickItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickItems.ForeColor = System.Drawing.Color.White;
            this.btnQuickItems.Location = new System.Drawing.Point(40, 40);
            this.btnQuickItems.Name = "btnQuickItems";
            this.btnQuickItems.Size = new System.Drawing.Size(240, 100);
            this.btnQuickItems.TabIndex = 0;
            this.btnQuickItems.Text = "📦 Manage Items";
            this.btnQuickItems.UseVisualStyleBackColor = false;
            this.btnQuickItems.Click += new System.EventHandler(this.itemsToolStripMenuItem_Click);

            // btnQuickAgents
            this.btnQuickAgents.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnQuickAgents.FlatAppearance.BorderSize = 0;
            this.btnQuickAgents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickAgents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickAgents.ForeColor = System.Drawing.Color.White;
            this.btnQuickAgents.Location = new System.Drawing.Point(310, 40);
            this.btnQuickAgents.Name = "btnQuickAgents";
            this.btnQuickAgents.Size = new System.Drawing.Size(240, 100);
            this.btnQuickAgents.TabIndex = 1;
            this.btnQuickAgents.Text = "👥 Manage Agents";
            this.btnQuickAgents.UseVisualStyleBackColor = false;
            this.btnQuickAgents.Click += new System.EventHandler(this.agentsToolStripMenuItem_Click);

            // btnQuickOrders
            this.btnQuickOrders.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.btnQuickOrders.FlatAppearance.BorderSize = 0;
            this.btnQuickOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickOrders.ForeColor = System.Drawing.Color.White;
            this.btnQuickOrders.Location = new System.Drawing.Point(580, 40);
            this.btnQuickOrders.Name = "btnQuickOrders";
            this.btnQuickOrders.Size = new System.Drawing.Size(240, 100);
            this.btnQuickOrders.TabIndex = 2;
            this.btnQuickOrders.Text = "🛒 Manage Orders";
            this.btnQuickOrders.UseVisualStyleBackColor = false;
            this.btnQuickOrders.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);

            // btnQuickReports
            this.btnQuickReports.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnQuickReports.FlatAppearance.BorderSize = 0;
            this.btnQuickReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickReports.ForeColor = System.Drawing.Color.White;
            this.btnQuickReports.Location = new System.Drawing.Point(850, 40);
            this.btnQuickReports.Name = "btnQuickReports";
            this.btnQuickReports.Size = new System.Drawing.Size(240, 100);
            this.btnQuickReports.TabIndex = 3;
            this.btnQuickReports.Text = "📊 View Reports";
            this.btnQuickReports.UseVisualStyleBackColor = false;
            this.btnQuickReports.Click += new System.EventHandler(this.filterReportsToolStripMenuItem_Click);

            // statusStrip1
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 3;

            // toolStripStatusLabel1
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";

            // toolStripStatusLabelUser
            this.toolStripStatusLabelUser.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(1096, 17);
            this.toolStripStatusLabelUser.Spring = true;
            this.toolStripStatusLabelUser.Text = "User: ";
            this.toolStripStatusLabelUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // toolStripStatusLabelTime
            this.toolStripStatusLabelTime.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabelTime.Text = "00:00:00";

            // timer1
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 672);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Management System - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelDashboard.ResumeLayout(false);
            this.panelQuickActions.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Panel panelQuickActions;
        private System.Windows.Forms.Button btnQuickItems;
        private System.Windows.Forms.Button btnQuickAgents;
        private System.Windows.Forms.Button btnQuickOrders;
        private System.Windows.Forms.Button btnQuickReports;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.Timer timer1;

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn)
            {
                lblUserInfo.Text = $"Logged in as: {SessionManager.CurrentUser.UserName} ({SessionManager.CurrentUser.Role})";
                toolStripStatusLabelUser.Text = $"User: {SessionManager.CurrentUser.UserName} | Role: {SessionManager.CurrentUser.Role}";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm();
            itemForm.MdiParent = this;
            itemForm.Show();
            HideDashboard();
        }

        private void agentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgentForm agentForm = new AgentForm();
            agentForm.MdiParent = this;
            agentForm.Show();
            HideDashboard();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.MdiParent = this;
            orderForm.Show();
            HideDashboard();
        }

        private void filterReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm();
            filterForm.MdiParent = this;
            filterForm.Show();
            HideDashboard();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void HideDashboard()
        {
            panelDashboard.Visible = false;
        }
    }
}
