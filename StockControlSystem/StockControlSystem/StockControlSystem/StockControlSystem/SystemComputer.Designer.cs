namespace StockControlSystem
{
    partial class SystemComputer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadSuppliers = new System.Windows.Forms.Button();
            this.btnLoadStock = new System.Windows.Forms.Button();
            this.btnListAllSuppliers = new System.Windows.Forms.Button();
            this.btnListAllStock = new System.Windows.Forms.Button();
            this.btnListScarceStock = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStockItemKey = new System.Windows.Forms.TextBox();
            this.txtNumOfItemsToOrder = new System.Windows.Forms.TextBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnListOutstandingOrders = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRestock = new System.Windows.Forms.Button();
            this.txtStockItemKey2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadSuppliers
            // 
            this.btnLoadSuppliers.Location = new System.Drawing.Point(25, 23);
            this.btnLoadSuppliers.Name = "btnLoadSuppliers";
            this.btnLoadSuppliers.Size = new System.Drawing.Size(99, 23);
            this.btnLoadSuppliers.TabIndex = 0;
            this.btnLoadSuppliers.Text = "Load Suppliers";
            this.btnLoadSuppliers.UseVisualStyleBackColor = true;
            this.btnLoadSuppliers.Click += new System.EventHandler(this.btnLoadSuppliers_Click);
            // 
            // btnLoadStock
            // 
            this.btnLoadStock.Location = new System.Drawing.Point(152, 23);
            this.btnLoadStock.Name = "btnLoadStock";
            this.btnLoadStock.Size = new System.Drawing.Size(99, 23);
            this.btnLoadStock.TabIndex = 1;
            this.btnLoadStock.Text = "Load Stock";
            this.btnLoadStock.UseVisualStyleBackColor = true;
            this.btnLoadStock.Click += new System.EventHandler(this.btnLoadStock_Click);
            // 
            // btnListAllSuppliers
            // 
            this.btnListAllSuppliers.Location = new System.Drawing.Point(25, 69);
            this.btnListAllSuppliers.Name = "btnListAllSuppliers";
            this.btnListAllSuppliers.Size = new System.Drawing.Size(99, 23);
            this.btnListAllSuppliers.TabIndex = 2;
            this.btnListAllSuppliers.Text = "List All Suppliers";
            this.btnListAllSuppliers.UseVisualStyleBackColor = true;
            this.btnListAllSuppliers.Click += new System.EventHandler(this.btnListAllSuppliers_Click);
            // 
            // btnListAllStock
            // 
            this.btnListAllStock.Location = new System.Drawing.Point(152, 69);
            this.btnListAllStock.Name = "btnListAllStock";
            this.btnListAllStock.Size = new System.Drawing.Size(99, 23);
            this.btnListAllStock.TabIndex = 3;
            this.btnListAllStock.Text = "List All Stock";
            this.btnListAllStock.UseVisualStyleBackColor = true;
            this.btnListAllStock.Click += new System.EventHandler(this.btnListAllStock_Click);
            // 
            // btnListScarceStock
            // 
            this.btnListScarceStock.Location = new System.Drawing.Point(152, 108);
            this.btnListScarceStock.Name = "btnListScarceStock";
            this.btnListScarceStock.Size = new System.Drawing.Size(99, 23);
            this.btnListScarceStock.TabIndex = 4;
            this.btnListScarceStock.Text = "List Scarce Stock";
            this.btnListScarceStock.UseVisualStyleBackColor = true;
            this.btnListScarceStock.Click += new System.EventHandler(this.btnListScarceStock_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stock Item Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "# of Items To Order";
            // 
            // txtStockItemKey
            // 
            this.txtStockItemKey.Location = new System.Drawing.Point(10, 32);
            this.txtStockItemKey.Name = "txtStockItemKey";
            this.txtStockItemKey.Size = new System.Drawing.Size(86, 20);
            this.txtStockItemKey.TabIndex = 7;
            // 
            // txtNumOfItemsToOrder
            // 
            this.txtNumOfItemsToOrder.Location = new System.Drawing.Point(124, 32);
            this.txtNumOfItemsToOrder.Name = "txtNumOfItemsToOrder";
            this.txtNumOfItemsToOrder.Size = new System.Drawing.Size(86, 20);
            this.txtNumOfItemsToOrder.TabIndex = 8;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(71, 58);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 9;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOrder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumOfItemsToOrder);
            this.groupBox1.Controls.Add(this.txtStockItemKey);
            this.groupBox1.Location = new System.Drawing.Point(28, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 87);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnListOutstandingOrders
            // 
            this.btnListOutstandingOrders.Location = new System.Drawing.Point(104, 256);
            this.btnListOutstandingOrders.Name = "btnListOutstandingOrders";
            this.btnListOutstandingOrders.Size = new System.Drawing.Size(147, 23);
            this.btnListOutstandingOrders.TabIndex = 11;
            this.btnListOutstandingOrders.Text = "List Outstanding Orders";
            this.btnListOutstandingOrders.UseVisualStyleBackColor = true;
            this.btnListOutstandingOrders.Click += new System.EventHandler(this.btnListOutstandingOrders_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRestock);
            this.groupBox2.Controls.Add(this.txtStockItemKey2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(28, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 60);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // btnRestock
            // 
            this.btnRestock.Location = new System.Drawing.Point(124, 29);
            this.btnRestock.Name = "btnRestock";
            this.btnRestock.Size = new System.Drawing.Size(75, 23);
            this.btnRestock.TabIndex = 10;
            this.btnRestock.Text = "Restock";
            this.btnRestock.UseVisualStyleBackColor = true;
            this.btnRestock.Click += new System.EventHandler(this.btnRestock_Click);
            // 
            // txtStockItemKey2
            // 
            this.txtStockItemKey2.Location = new System.Drawing.Point(10, 32);
            this.txtStockItemKey2.Name = "txtStockItemKey2";
            this.txtStockItemKey2.Size = new System.Drawing.Size(86, 20);
            this.txtStockItemKey2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stock Item Key";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(99, 391);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // SystemComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 443);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnListOutstandingOrders);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnListScarceStock);
            this.Controls.Add(this.btnListAllStock);
            this.Controls.Add(this.btnListAllSuppliers);
            this.Controls.Add(this.btnLoadStock);
            this.Controls.Add(this.btnLoadSuppliers);
            this.Name = "SystemComputer";
            this.Text = "System Computer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadSuppliers;
        private System.Windows.Forms.Button btnLoadStock;
        private System.Windows.Forms.Button btnListAllSuppliers;
        private System.Windows.Forms.Button btnListAllStock;
        private System.Windows.Forms.Button btnListScarceStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStockItemKey;
        private System.Windows.Forms.TextBox txtNumOfItemsToOrder;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnListOutstandingOrders;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRestock;
        private System.Windows.Forms.TextBox txtStockItemKey2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
    }
}

