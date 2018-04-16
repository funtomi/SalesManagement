using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement.UI {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            this.skinEngine1.SkinFile = "mp10maroon.ssk";
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void tSMenuItemPurchase_Click(object sender, EventArgs e) {
            PurchaseCtrl ctrl = new PurchaseCtrl(); 
            ChangeFormTo(ctrl);
        }

        private void ChangeFormTo(UserControl ctrl) {
            this.panelChild.Visible = true;
            foreach (Control item in this.panelChild.Controls) {
                item.Dispose();
            }
            this.panelChild.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            this.panelChild.Controls.Add(ctrl);
        }

        private void tSMenuItemSalesStaff_Click(object sender, EventArgs e) {
            SalesStaffCtrl ctrl = new SalesStaffCtrl();
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemReturnsManagement_Click(object sender, EventArgs e) {
            ReturnsManagementCtrl ctrl = new ReturnsManagementCtrl();
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemPurchaseInfoQuery_Click(object sender, EventArgs e) {
            PurchaseInfoQueryCtrl ctrl = new PurchaseInfoQueryCtrl();
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemSalesInfoQuery_Click(object sender, EventArgs e) {
            SalesInfoQueryCtrl ctrl = new SalesInfoQueryCtrl();
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemReturnsInfoQuery_Click(object sender, EventArgs e) {
            ReturnsInfoQueryCtrl ctrl = new ReturnsInfoQueryCtrl();
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemCommodityInfoQuery_Click(object sender, EventArgs e) {
            CommodityInfoQueryCtrl ctrl = new CommodityInfoQueryCtrl();
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemPurchaseStatistics_Click(object sender, EventArgs e) {
            PurchaseStatisticsCtrl ctrl = new PurchaseStatisticsCtrl();
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemReturnsStatistics_Click(object sender, EventArgs e) {
            ReturnsStatisticsCtrl ctrl = new ReturnsStatisticsCtrl();
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemDailySalesStatistics_Click(object sender, EventArgs e) {
            DailySalesStatisticsCtrl ctrl = new DailySalesStatisticsCtrl();
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemMonthSalesStatistics_Click(object sender, EventArgs e) {
            ChangeFormTo(new MonthSalesStatisticsCtrl());
        }

        private void tSMenuItemStockTakingCtrl_Click(object sender, EventArgs e) {
            ChangeFormTo(new StockTakingCtrl());

        }

        private void tSMenuItemSupplierManagement_Click(object sender, EventArgs e) {
            ChangeFormTo(new SupplierManagementCtrl());
        }

        private void tSMenuItemWarehouseManagement_Click(object sender, EventArgs e) {
            ChangeFormTo(new WarehouseManagementCtrl());
        }

        private void tSMenuItemSizeManagement_Click(object sender, EventArgs e) {
            ChangeFormTo(new SizeManagementCtrl());
        }

        private void tSMenuItemCommodityManagement_Click(object sender, EventArgs e) {
            ChangeFormTo(new CommodityManagementCtrl());
        }

        private void tSMenuItemCustomerManagement_Click(object sender, EventArgs e) {
            ChangeFormTo(new CustomerManagementCtrl());
        }

        private void tSMenuItemColorManagement_Click(object sender, EventArgs e) {
            ChangeFormTo(new ColorManagementCtrl());
        }

        private void TsMenuItemPermissions_Click(object sender, EventArgs e) {
            ChangeFormTo(new PermissionsCtrl());
        }

        
    }
}
