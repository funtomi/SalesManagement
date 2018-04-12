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
            this.库存盘点ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.基础信息维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供货商管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仓库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.尺码管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.颜色管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.权限设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelChild = new System.Windows.Forms.Panel();
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
            this.权限设置ToolStripMenuItem});
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
            this.库存盘点ToolStripMenuItem1});
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
            // 库存盘点ToolStripMenuItem1
            // 
            this.库存盘点ToolStripMenuItem1.Name = "库存盘点ToolStripMenuItem1";
            this.库存盘点ToolStripMenuItem1.Size = new System.Drawing.Size(180, 28);
            this.库存盘点ToolStripMenuItem1.Text = "库存盘点";
            // 
            // 基础信息维护ToolStripMenuItem
            // 
            this.基础信息维护ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.供货商管理ToolStripMenuItem,
            this.仓库管理ToolStripMenuItem,
            this.商品管理ToolStripMenuItem,
            this.尺码管理ToolStripMenuItem,
            this.颜色管理ToolStripMenuItem,
            this.客户管理ToolStripMenuItem});
            this.基础信息维护ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.基础信息维护ToolStripMenuItem.Name = "基础信息维护ToolStripMenuItem";
            this.基础信息维护ToolStripMenuItem.Size = new System.Drawing.Size(124, 27);
            this.基础信息维护ToolStripMenuItem.Text = "基础信息维护";
            // 
            // 供货商管理ToolStripMenuItem
            // 
            this.供货商管理ToolStripMenuItem.Name = "供货商管理ToolStripMenuItem";
            this.供货商管理ToolStripMenuItem.Size = new System.Drawing.Size(171, 28);
            this.供货商管理ToolStripMenuItem.Text = "供货商管理";
            // 
            // 仓库管理ToolStripMenuItem
            // 
            this.仓库管理ToolStripMenuItem.Name = "仓库管理ToolStripMenuItem";
            this.仓库管理ToolStripMenuItem.Size = new System.Drawing.Size(171, 28);
            this.仓库管理ToolStripMenuItem.Text = "仓库管理";
            // 
            // 商品管理ToolStripMenuItem
            // 
            this.商品管理ToolStripMenuItem.Name = "商品管理ToolStripMenuItem";
            this.商品管理ToolStripMenuItem.Size = new System.Drawing.Size(171, 28);
            this.商品管理ToolStripMenuItem.Text = "商品管理";
            // 
            // 尺码管理ToolStripMenuItem
            // 
            this.尺码管理ToolStripMenuItem.Name = "尺码管理ToolStripMenuItem";
            this.尺码管理ToolStripMenuItem.Size = new System.Drawing.Size(171, 28);
            this.尺码管理ToolStripMenuItem.Text = "尺码管理";
            // 
            // 颜色管理ToolStripMenuItem
            // 
            this.颜色管理ToolStripMenuItem.Name = "颜色管理ToolStripMenuItem";
            this.颜色管理ToolStripMenuItem.Size = new System.Drawing.Size(171, 28);
            this.颜色管理ToolStripMenuItem.Text = "颜色管理";
            // 
            // 客户管理ToolStripMenuItem
            // 
            this.客户管理ToolStripMenuItem.Name = "客户管理ToolStripMenuItem";
            this.客户管理ToolStripMenuItem.Size = new System.Drawing.Size(171, 28);
            this.客户管理ToolStripMenuItem.Text = "客户管理";
            // 
            // 权限设置ToolStripMenuItem
            // 
            this.权限设置ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.权限设置ToolStripMenuItem.Name = "权限设置ToolStripMenuItem";
            this.权限设置ToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.权限设置ToolStripMenuItem.Text = "权限设置";
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
            this.panelChild.Location = new System.Drawing.Point(5, 40);
            this.panelChild.Margin = new System.Windows.Forms.Padding(2);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(910, 656);
            this.panelChild.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 726);
            this.Controls.Add(this.panelChild);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
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
        private System.Windows.Forms.ToolStripMenuItem 供货商管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仓库管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 尺码管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 颜色管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 权限设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 库存盘点ToolStripMenuItem1;
        private System.Windows.Forms.Panel panelChild;
    }
}