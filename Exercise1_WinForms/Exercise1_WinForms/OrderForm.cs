using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BusinessLogicLayer;
using Models;

namespace Exercise1_WinForms
{
    public partial class OrderForm : Form
    {
        private OrderBLL orderBLL;
        private AgentBLL agentBLL;
        private ItemBLL itemBLL;
        private int selectedOrderId = 0;
        private List<OrderDetail> orderDetails;

        public OrderForm()
        {
            InitializeComponent();
            orderBLL = new OrderBLL();
            agentBLL = new AgentBLL();
            itemBLL = new ItemBLL();
            orderDetails = new List<OrderDetail>();
        }

        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.cboAgent = new System.Windows.Forms.ComboBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtShippingAddress = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtUnitAmount = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.btnClearOrder = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpOrderHeader = new System.Windows.Forms.GroupBox();
            this.grpOrderDetails = new System.Windows.Forms.GroupBox();
            this.lblAgent = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblUnitAmount = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.grpOrderHeader.SuspendLayout();
            this.grpOrderDetails.SuspendLayout();
            this.SuspendLayout();

            // dgvOrders
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 12);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(960, 200);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(890, 220);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 25);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // grpOrderHeader
            this.grpOrderHeader.Controls.Add(this.lblAgent);
            this.grpOrderHeader.Controls.Add(this.cboAgent);
            this.grpOrderHeader.Controls.Add(this.lblOrderDate);
            this.grpOrderHeader.Controls.Add(this.dtpOrderDate);
            this.grpOrderHeader.Controls.Add(this.lblStatus);
            this.grpOrderHeader.Controls.Add(this.cboStatus);
            this.grpOrderHeader.Controls.Add(this.lblShippingAddress);
            this.grpOrderHeader.Controls.Add(this.txtShippingAddress);
            this.grpOrderHeader.Controls.Add(this.lblNotes);
            this.grpOrderHeader.Controls.Add(this.txtNotes);
            this.grpOrderHeader.Location = new System.Drawing.Point(12, 255);
            this.grpOrderHeader.Name = "grpOrderHeader";
            this.grpOrderHeader.Size = new System.Drawing.Size(960, 150);
            this.grpOrderHeader.TabIndex = 2;
            this.grpOrderHeader.TabStop = false;
            this.grpOrderHeader.Text = "Order Information";

            // lblAgent
            this.lblAgent.AutoSize = true;
            this.lblAgent.Location = new System.Drawing.Point(20, 30);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(41, 13);
            this.lblAgent.Text = "Agent:";

            // cboAgent
            this.cboAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgent.FormattingEnabled = true;
            this.cboAgent.Location = new System.Drawing.Point(110, 27);
            this.cboAgent.Name = "cboAgent";
            this.cboAgent.Size = new System.Drawing.Size(300, 21);
            this.cboAgent.TabIndex = 0;

            // lblOrderDate
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(450, 30);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(64, 13);
            this.lblOrderDate.Text = "Order Date:";

            // dtpOrderDate
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(530, 27);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 20);
            this.dtpOrderDate.TabIndex = 1;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(760, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.Text = "Status:";

            // cboStatus
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] { "Pending", "Confirmed", "Shipped", "Delivered", "Cancelled" });
            this.cboStatus.Location = new System.Drawing.Point(810, 27);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(130, 21);
            this.cboStatus.TabIndex = 2;

            // lblShippingAddress
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Location = new System.Drawing.Point(20, 60);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(95, 13);
            this.lblShippingAddress.Text = "Shipping Address:";

            // txtShippingAddress
            this.txtShippingAddress.Location = new System.Drawing.Point(110, 57);
            this.txtShippingAddress.Multiline = true;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new System.Drawing.Size(830, 35);
            this.txtShippingAddress.TabIndex = 3;

            // lblNotes
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(20, 105);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.Text = "Notes:";

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(110, 102);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(830, 35);
            this.txtNotes.TabIndex = 4;

            // grpOrderDetails
            this.grpOrderDetails.Controls.Add(this.dgvOrderDetails);
            this.grpOrderDetails.Controls.Add(this.lblItem);
            this.grpOrderDetails.Controls.Add(this.cboItem);
            this.grpOrderDetails.Controls.Add(this.lblQuantity);
            this.grpOrderDetails.Controls.Add(this.txtQuantity);
            this.grpOrderDetails.Controls.Add(this.lblUnitAmount);
            this.grpOrderDetails.Controls.Add(this.txtUnitAmount);
            this.grpOrderDetails.Controls.Add(this.lblDiscount);
            this.grpOrderDetails.Controls.Add(this.txtDiscount);
            this.grpOrderDetails.Controls.Add(this.btnAddItem);
            this.grpOrderDetails.Controls.Add(this.btnRemoveItem);
            this.grpOrderDetails.Location = new System.Drawing.Point(12, 415);
            this.grpOrderDetails.Name = "grpOrderDetails";
            this.grpOrderDetails.Size = new System.Drawing.Size(960, 250);
            this.grpOrderDetails.TabIndex = 3;
            this.grpOrderDetails.TabStop = false;
            this.grpOrderDetails.Text = "Order Items";

            // dgvOrderDetails
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(20, 80);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderDetails.Size = new System.Drawing.Size(920, 160);
            this.dgvOrderDetails.TabIndex = 0;

            // lblItem
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(20, 30);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(30, 13);
            this.lblItem.Text = "Item:";

            // cboItem
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(80, 27);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(250, 21);
            this.cboItem.TabIndex = 0;
            this.cboItem.SelectedIndexChanged += new System.EventHandler(this.cboItem_SelectedIndexChanged);

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(350, 30);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.Text = "Quantity:";

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(410, 27);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(80, 20);
            this.txtQuantity.TabIndex = 1;
            this.txtQuantity.Text = "1";

            // lblUnitAmount
            this.lblUnitAmount.AutoSize = true;
            this.lblUnitAmount.Location = new System.Drawing.Point(510, 30);
            this.lblUnitAmount.Name = "lblUnitAmount";
            this.lblUnitAmount.Size = new System.Drawing.Size(34, 13);
            this.lblUnitAmount.Text = "Price:";

            // txtUnitAmount
            this.txtUnitAmount.Location = new System.Drawing.Point(560, 27);
            this.txtUnitAmount.Name = "txtUnitAmount";
            this.txtUnitAmount.Size = new System.Drawing.Size(100, 20);
            this.txtUnitAmount.TabIndex = 2;

            // lblDiscount
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(680, 30);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(61, 13);
            this.lblDiscount.Text = "Discount %:";

            // txtDiscount
            this.txtDiscount.Location = new System.Drawing.Point(750, 27);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(60, 20);
            this.txtDiscount.TabIndex = 3;
            this.txtDiscount.Text = "0";

            // btnAddItem
            this.btnAddItem.Location = new System.Drawing.Point(820, 25);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(60, 23);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);

            // btnRemoveItem
            this.btnRemoveItem.Location = new System.Drawing.Point(820, 54);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveItem.TabIndex = 5;
            this.btnRemoveItem.Text = "Remove";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);

            // lblTotalAmount
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(680, 680);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(105, 17);
            this.lblTotalAmount.Text = "Total Amount:";

            // txtTotalAmount
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotalAmount.Location = new System.Drawing.Point(790, 677);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(150, 23);
            this.txtTotalAmount.TabIndex = 4;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // btnSaveOrder
            this.btnSaveOrder.Location = new System.Drawing.Point(680, 710);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(120, 35);
            this.btnSaveOrder.TabIndex = 5;
            this.btnSaveOrder.Text = "Save Order";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);

            // btnClearOrder
            this.btnClearOrder.Location = new System.Drawing.Point(820, 710);
            this.btnClearOrder.Name = "btnClearOrder";
            this.btnClearOrder.Size = new System.Drawing.Size(120, 35);
            this.btnClearOrder.TabIndex = 6;
            this.btnClearOrder.Text = "Clear";
            this.btnClearOrder.UseVisualStyleBackColor = true;
            this.btnClearOrder.Click += new System.EventHandler(this.btnClearOrder_Click);

            // OrderForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.btnClearOrder);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.grpOrderDetails);
            this.Controls.Add(this.grpOrderHeader);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Management";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.grpOrderHeader.ResumeLayout(false);
            this.grpOrderHeader.PerformLayout();
            this.grpOrderDetails.ResumeLayout(false);
            this.grpOrderDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.ComboBox cboAgent;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.TextBox txtShippingAddress;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtUnitAmount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Button btnClearOrder;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpOrderHeader;
        private System.Windows.Forms.GroupBox grpOrderDetails;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblShippingAddress;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblUnitAmount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotalAmount;

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
            LoadAgents();
            LoadItems();
            cboStatus.SelectedIndex = 0;
        }

        private void LoadOrders()
        {
            try
            {
                DataTable dt = orderBLL.GetAllOrders();
                dgvOrders.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAgents()
        {
            try
            {
                DataTable dt = agentBLL.GetActiveAgents();
                cboAgent.DataSource = dt;
                cboAgent.DisplayMember = "AgentName";
                cboAgent.ValueMember = "AgentID";
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
                cboItem.DataSource = dt;
                cboItem.DisplayMember = "ItemName";
                cboItem.ValueMember = "ItemID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
                selectedOrderId = Convert.ToInt32(row.Cells["OrderID"].Value);

                try
                {
                    Order order = orderBLL.GetOrderById(selectedOrderId);
                    if (order != null)
                    {
                        cboAgent.SelectedValue = order.AgentID;
                        dtpOrderDate.Value = order.OrderDate;
                        cboStatus.Text = order.Status;
                        txtShippingAddress.Text = order.ShippingAddress;
                        txtNotes.Text = order.Notes;

                        DataTable dt = orderBLL.GetOrderDetails(selectedOrderId);
                        dgvOrderDetails.DataSource = dt;

                        CalculateTotalAmount(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading order details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboItem.SelectedValue != null)
            {
                try
                {
                    int itemId = Convert.ToInt32(cboItem.SelectedValue);
                    Item item = itemBLL.GetItemById(itemId);
                    if (item != null)
                    {
                        txtUnitAmount.Text = item.Price.ToString("0.00");
                    }
                }
                catch { }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboItem.SelectedValue == null)
                {
                    MessageBox.Show("Please select an item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int itemId = Convert.ToInt32(cboItem.SelectedValue);
                string itemName = cboItem.Text;
                int quantity = int.Parse(txtQuantity.Text);
                decimal unitAmount = decimal.Parse(txtUnitAmount.Text);
                decimal discount = decimal.Parse(txtDiscount.Text);

                OrderDetail detail = new OrderDetail
                {
                    ItemID = itemId,
                    ItemName = itemName,
                    Quantity = quantity,
                    UnitAmount = unitAmount,
                    Discount = discount,
                    TotalAmount = quantity * unitAmount * (1 - discount / 100)
                };

                orderDetails.Add(detail);
                RefreshOrderDetailsGrid();
                CalculateTotalFromList();

                txtQuantity.Text = "1";
                txtDiscount.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.CurrentRow != null && dgvOrderDetails.CurrentRow.Index >= 0)
            {
                int index = dgvOrderDetails.CurrentRow.Index;
                orderDetails.RemoveAt(index);
                RefreshOrderDetailsGrid();
                CalculateTotalFromList();
            }
        }

        private void RefreshOrderDetailsGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemID", typeof(int));
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitAmount", typeof(decimal));
            dt.Columns.Add("Discount", typeof(decimal));
            dt.Columns.Add("TotalAmount", typeof(decimal));

            foreach (var detail in orderDetails)
            {
                dt.Rows.Add(detail.ItemID, detail.ItemName, detail.Quantity, detail.UnitAmount, detail.Discount, detail.TotalAmount);
            }

            dgvOrderDetails.DataSource = dt;
        }

        private void CalculateTotalFromList()
        {
            decimal total = 0;
            foreach (var detail in orderDetails)
            {
                total += detail.TotalAmount;
            }
            txtTotalAmount.Text = total.ToString("0.00");
        }

        private void CalculateTotalAmount(DataTable dt)
        {
            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["TotalAmount"]);
            }
            txtTotalAmount.Text = total.ToString("0.00");
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboAgent.SelectedValue == null)
                {
                    MessageBox.Show("Please select an agent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (orderDetails.Count == 0)
                {
                    MessageBox.Show("Please add at least one item to the order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Order order = new Order
                {
                    AgentID = Convert.ToInt32(cboAgent.SelectedValue),
                    OrderDate = dtpOrderDate.Value,
                    Status = cboStatus.Text,
                    ShippingAddress = txtShippingAddress.Text,
                    Notes = txtNotes.Text,
                    CreatedBy = SessionManager.CurrentUser?.UserID
                };

                int orderId = orderBLL.CreateOrder(order, orderDetails);

                if (orderId > 0)
                {
                    MessageBox.Show("Order created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders();
                    ClearOrder();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            ClearOrder();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void ClearOrder()
        {
            selectedOrderId = 0;
            if (cboAgent.Items.Count > 0)
                cboAgent.SelectedIndex = 0;
            dtpOrderDate.Value = DateTime.Now;
            if (cboStatus.Items.Count > 0)
                cboStatus.SelectedIndex = 0;
            txtShippingAddress.Clear();
            txtNotes.Clear();
            txtQuantity.Text = "1";
            txtDiscount.Text = "0";
            txtTotalAmount.Text = "0.00";
            orderDetails.Clear();
            dgvOrderDetails.DataSource = null;
        }
    }
}
