namespace SalesManagement.UI {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.日常事务管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemSalesStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemReturnsManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.统计分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemPurchaseInfoQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemSalesInfoQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemReturnsInfoQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemCommodityInfoQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.统计分析ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemPurchaseStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemReturnsStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemDailySalesStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemMonthSalesStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemStockTakingCtrl = new System.Windows.Forms.ToolStripMenuItem();
            this.基础信息维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemSupplierManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemWarehouseManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemCommodityManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemSizeManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemColorManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemCustomerManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.TsMenuItemPermissions = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelChild = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.日常事务管理ToolStripMenuItem,
            this.统计分析ToolStripMenuItem,
            this.统计分析ToolStripMenuItem1,
            this.基础信息维护ToolStripMenuItem,
            this.TsMenuItemPermissions});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(923, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 日常事务管理ToolStripMenuItem
            // 
            this.日常事务管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuItemPurchase,
            this.tSMenuItemSalesStaff,
            this.tSMenuItemReturnsManagement});
            this.日常事务管理ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.日常事务管理ToolStripMenuItem.Name = "日常事务管理ToolStripMenuItem";
            this.日常事务管理ToolStripMenuItem.Size = new System.Drawing.Size(124, 27);
            this.日常事务管理ToolStripMenuItem.Text = "日常事务管理";
            // 
            // tSMenuItemPurchase
            // 
            this.tSMenuItemPurchase.Name = "tSMenuItemPurchase";
            this.tSMenuItemPurchase.Size = new System.Drawing.Size(154, 28);
            this.tSMenuItemPurchase.Text = "采购进货";
            this.tSMenuItemPurchase.Click += new System.EventHandler(this.tSMenuItemPurchase_Click);
            // 
            // tSMenuItemSalesStaff
            // 
            this.tSMenuItemSalesStaff.Name = "tSMenuItemSalesStaff";
            this.tSMenuItemSalesStaff.Size = new System.Drawing.Size(154, 28);
            this.tSMenuItemSalesStaff.Text = "前台销售";
            this.tSMenuItemSalesStaff.Click += new System.EventHandler(this.tSMenuItemSalesStaff_Click);
            // 
            // tSMenuItemReturnsManagement
            // 
            this.tSMenuItemReturnsManagement.Name = "tSMenuItemReturnsManagement";
            this.tSMenuItemReturnsManagement.Size = new System.Drawing.Size(154, 28);
            this.tSMenuItemReturnsManagement.Text = "退货管理";
            this.tSMenuItemReturnsManagement.Click += new System.EventHandler(this.tSMenuItemReturnsManagement_Click);
            // 
            // 统计分析ToolStripMenuItem
            // 
            this.统计分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuItemPurchaseInfoQuery,
            this.tSMenuItemSalesInfoQuery,
            this.tSMenuItemReturnsInfoQuery,
            this.tSMenuItemCommodityInfoQuery});
            this.统计分析ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.统计分析ToolStripMenuItem.Name = "统计分析ToolStripMenuItem";
            this.统计分析ToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.统计分析ToolStripMenuItem.Text = "信息查询";
            // 
            // tSMenuItemPurchaseInfoQuery
            // 
            this.tSMenuItemPurchaseInfoQuery.Name = "tSMenuItemPurchaseInfoQuery";
            this.tSMenuItemPurchaseInfoQuery.Size = new System.Drawing.Size(188, 28);
            this.tSMenuItemPurchaseInfoQuery.Text = "进货信息查询";
            this.tSMenuItemPurchaseInfoQuery.Click += new System.EventHandler(this.tSMenuItemPurchaseInfoQuery_Click);
            // 
            // tSMenuItemSalesInfoQuery
            // 
            this.tSMenuItemSalesInfoQuery.Name = "tSMenuItemSalesInfoQuery";
            this.tSMenuItemSalesInfoQuery.Size = new System.Drawing.Size(188, 28);
            this.tSMenuItemSalesInfoQuery.Text = "销售信息查询";
            this.tSMenuItemSalesInfoQuery.Click += new System.EventHandler(this.tSMenuItemSalesInfoQuery_Click);
            // 
            // tSMenuItemReturnsInfoQuery
            // 
            this.tSMenuItemReturnsInfoQuery.Name = "tSMenuItemReturnsInfoQuery";
            this.tSMenuItemReturnsInfoQuery.Size = new System.Drawing.Size(188, 28);
            this.tSMenuItemReturnsInfoQuery.Text = "退货信息查询";
            this.tSMenuItemReturnsInfoQuery.Click += new System.EventHandler(this.tSMenuItemReturnsInfoQuery_Click);
            // 
            // tSMenuItemCommodityInfoQuery
            // 
            this.tSMenuItemCommodityInfoQuery.Name = "tSMenuItemCommodityInfoQuery";
            this.tSMenuItemCommodityInfoQuery.Size = new System.Drawing.Size(188, 28);
            this.tSMenuItemCommodityInfoQuery.Text = "商品信息查询";
            this.tSMenuItemCommodityInfoQuery.Click += new System.EventHandler(this.tSMenuItemCommodityInfoQuery_Click);
            // 
            // 统计分析ToolStripMenuItem1
            // 
            this.统计分析ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuItemPurchaseStatistics,
            this.tSMenuItemReturnsStatistics,
            this.tSMenuItemDailySalesStatistics,
            this.tSMenuItemMonthSalesStatistics,
            this.tSMenuItemStockTakingCtrl});
            this.统计分析ToolStripMenuItem1.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.统计分析ToolStripMenuItem1.Name = "统计分析ToolStripMenuItem1";
            this.统计分析ToolStripMenuItem1.Size = new System.Drawing.Size(90, 27);
            this.统计分析ToolStripMenuItem1.Text = "统计分析";
            // 
            // tSMenuItemPurchaseStatistics
            // 
            this.tSMenuItemPurchaseStatistics.Name = "tSMenuItemPurchaseStatistics";
            this.tSMenuItemPurchaseStatistics.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemPurchaseStatistics.Text = "进货统计";
            this.tSMenuItemPurchaseStatistics.Click += new System.EventHandler(this.tSMenuItemPurchaseStatistics_Click);
            // 
            // tSMenuItemReturnsStatistics
            // 
            this.tSMenuItemReturnsStatistics.Name = "tSMenuItemReturnsStatistics";
            this.tSMenuItemReturnsStatistics.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemReturnsStatistics.Text = "退货统计";
            this.tSMenuItemReturnsStatistics.Click += new System.EventHandler(this.tSMenuItemReturnsStatistics_Click);
            // 
            // tSMenuItemDailySalesStatistics
            // 
            this.tSMenuItemDailySalesStatistics.Name = "tSMenuItemDailySalesStatistics";
            this.tSMenuItemDailySalesStatistics.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemDailySalesStatistics.Text = "日销售统计";
            this.tSMenuItemDailySalesStatistics.Click += new System.EventHandler(this.tSMenuItemDailySalesStatistics_Click);
            // 
            // tSMenuItemMonthSalesStatistics
            // 
            this.tSMenuItemMonthSalesStatistics.Name = "tSMenuItemMonthSalesStatistics";
            this.tSMenuItemMonthSalesStatistics.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemMonthSalesStatistics.Text = "月销售统计";
            this.tSMenuItemMonthSalesStatistics.Click += new System.EventHandler(this.tSMenuItemMonthSalesStatistics_Click);
            // 
            // tSMenuItemStockTakingCtrl
            // 
            this.tSMenuItemStockTakingCtrl.Name = "tSMenuItemStockTakingCtrl";
            this.tSMenuItemStockTakingCtrl.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemStockTakingCtrl.Text = "库存盘点";
            this.tSMenuItemStockTakingCtrl.Click += new System.EventHandler(this.tSMenuItemStockTakingCtrl_Click);
            // 
            // 基础信息维护ToolStripMenuItem
            // 
            this.基础信息维护ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuItemSupplierManagement,
            this.tSMenuItemWarehouseManagement,
            this.tSMenuItemCommodityManagement,
            this.tSMenuItemSizeManagement,
            this.tSMenuItemColorManagement,
            this.tSMenuItemCustomerManagement});
            this.基础信息维护ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.基础信息维护ToolStripMenuItem.Name = "基础信息维护ToolStripMenuItem";
            this.基础信息维护ToolStripMenuItem.Size = new System.Drawing.Size(124, 27);
            this.基础信息维护ToolStripMenuItem.Text = "基础信息维护";
            // 
            // tSMenuItemSupplierManagement
            // 
            this.tSMenuItemSupplierManagement.Name = "tSMenuItemSupplierManagement";
            this.tSMenuItemSupplierManagement.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemSupplierManagement.Text = "供货商管理";
            this.tSMenuItemSupplierManagement.Click += new System.EventHandler(this.tSMenuItemSupplierManagement_Click);
            // 
            // tSMenuItemWarehouseManagement
            // 
            this.tSMenuItemWarehouseManagement.Name = "tSMenuItemWarehouseManagement";
            this.tSMenuItemWarehouseManagement.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemWarehouseManagement.Text = "仓库管理";
            this.tSMenuItemWarehouseManagement.Click += new System.EventHandler(this.tSMenuItemWarehouseManagement_Click);
            // 
            // tSMenuItemCommodityManagement
            // 
            this.tSMenuItemCommodityManagement.Name = "tSMenuItemCommodityManagement";
            this.tSMenuItemCommodityManagement.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemCommodityManagement.Text = "商品管理";
            this.tSMenuItemCommodityManagement.Click += new System.EventHandler(this.tSMenuItemCommodityManagement_Click);
            // 
            // tSMenuItemSizeManagement
            // 
            this.tSMenuItemSizeManagement.Name = "tSMenuItemSizeManagement";
            this.tSMenuItemSizeManagement.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemSizeManagement.Text = "尺码管理";
            this.tSMenuItemSizeManagement.Click += new System.EventHandler(this.tSMenuItemSizeManagement_Click);
            // 
            // tSMenuItemColorManagement
            // 
            this.tSMenuItemColorManagement.Name = "tSMenuItemColorManagement";
            this.tSMenuItemColorManagement.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemColorManagement.Text = "颜色管理";
            this.tSMenuItemColorManagement.Click += new System.EventHandler(this.tSMenuItemColorManagement_Click);
            // 
            // tSMenuItemCustomerManagement
            // 
            this.tSMenuItemCustomerManagement.Name = "tSMenuItemCustomerManagement";
            this.tSMenuItemCustomerManagement.Size = new System.Drawing.Size(180, 28);
            this.tSMenuItemCustomerManagement.Text = "客户管理";
            this.tSMenuItemCustomerManagement.Click += new System.EventHandler(this.tSMenuItemCustomerManagement_Click);
            // 
            // TsMenuItemPermissions
            // 
            this.TsMenuItemPermissions.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TsMenuItemPermissions.Name = "TsMenuItemPermissions";
            this.TsMenuItemPermissions.Size = new System.Drawing.Size(90, 27);
            this.TsMenuItemPermissions.Text = "权限设置";
            this.TsMenuItemPermissions.Click += new System.EventHandler(this.TsMenuItemPermissions_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 704);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(923, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelChild
            // 
            this.panelChild.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChild.AutoScroll = true;
            this.panelChild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelChild.Location = new System.Drawing.Point(0, 33);
            this.panelChild.Margin = new System.Windows.Forms.Padding(2);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(921, 671);
            this.panelChild.TabIndex = 2;
            this.panelChild.Tag = "";
            this.panelChild.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 41.7479F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Salmon;
            this.label1.Location = new System.Drawing.Point(165, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 89);
            this.label1.TabIndex = 0;
            this.label1.Tag = "9999";
            this.label1.Text = "欢迎使用！！";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(923, 726);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelChild);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服装销售管理系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 日常事务管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemPurchase;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemSalesStaff;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemReturnsManagement;
        private System.Windows.Forms.ToolStripMenuItem 统计分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemPurchaseInfoQuery;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemSalesInfoQuery;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemReturnsInfoQuery;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemCommodityInfoQuery;
        private System.Windows.Forms.ToolStripMenuItem 统计分析ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemPurchaseStatistics;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemReturnsStatistics;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemDailySalesStatistics;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemMonthSalesStatistics;
        private System.Windows.Forms.ToolStripMenuItem 基础信息维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemSupplierManagement;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemWarehouseManagement;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemCommodityManagement;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemSizeManagement;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemColorManagement;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemCustomerManagement;
        private System.Windows.Forms.ToolStripMenuItem TsMenuItemPermissions;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemStockTakingCtrl;
        private System.Windows.Forms.Panel panelChild;
        private System.Windows.Forms.Label label1;
    }
}