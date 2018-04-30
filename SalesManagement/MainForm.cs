using SalesManagement.Model;
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

        public MainForm(UserInfo userInfo):this() {
            if (userInfo==null) {
                MessageBox.Show("无效的用户信息！");
                this.Close();
            }
            _userInfo = userInfo;
        }

        /// <summary>
        /// 当前登录的用户信息
        /// </summary>
        public UserInfo UserInfo {
            get { return _userInfo; }
            set { _userInfo = value; }
        }
        private UserInfo _userInfo;

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #region 事件

        private void tSMenuItemPurchase_Click(object sender, EventArgs e) {
            PurchaseCtrl ctrl = new PurchaseCtrl(_userInfo);
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
            SalesStaffCtrl ctrl = new SalesStaffCtrl(_userInfo);
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemReturnsManagement_Click(object sender, EventArgs e) {
            ReturnsManagementCtrl ctrl = new ReturnsManagementCtrl(_userInfo);
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemPurchaseInfoQuery_Click(object sender, EventArgs e) {
            PurchaseInfoQueryCtrl ctrl = new PurchaseInfoQueryCtrl();
            ctrl.ViewDetailsEvent += new PurchaseInfoQueryCtrl.ViewDetailsDelegate(PurchaseInfoQueryCtrl_ViewDetailsEvent);
            ChangeFormTo(ctrl);
        }

        private void PurchaseInfoQueryCtrl_ViewDetailsEvent(PurchaseDocClientInfo info) {
            PurchaseCtrl ctrl = new PurchaseCtrl(info);
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemSalesInfoQuery_Click(object sender, EventArgs e) {
            SalesInfoQueryCtrl ctrl = new SalesInfoQueryCtrl();
            ctrl.ViewDetailsEvent += new SalesInfoQueryCtrl.ViewDetailsDelegate(SalesInfoQueryCtrl_ViewDetailsEvent);
            ChangeFormTo(ctrl);
        }

        private void SalesInfoQueryCtrl_ViewDetailsEvent(SalesInfo info) {
            SalesStaffCtrl ctrl = new SalesStaffCtrl(info);
            ChangeFormTo(ctrl);
        }

        private void tSMenuItemReturnsInfoQuery_Click(object sender, EventArgs e) {
            ReturnsInfoQueryCtrl ctrl = new ReturnsInfoQueryCtrl();
            ctrl.ViewDetailsEvent += new ReturnsInfoQueryCtrl.ViewDetailsDelegate(ReturnsInfoQueryCtrl_ViewDetailsEvent);
            ChangeFormTo(ctrl);
        }

        private void ReturnsInfoQueryCtrl_ViewDetailsEvent(ReturnInfo info) {
            ReturnsManagementCtrl ctrl = new ReturnsManagementCtrl(info);
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

        #endregion

        protected override void WndProc(ref Message msg) {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE)) {
                // 点击winform右上关闭按钮 
                System.Environment.Exit(0);
                return;
            }
            base.WndProc(ref msg);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if (_userInfo==null) {
                return;
            }
            this.tSStatusLabelUserName.Text = _userInfo.UserName;
            this.tSStatusLabelPermission.Text = _userInfo.Permission ? "操作员" : "管理员";
            SetPermissionView(_userInfo.Permission);
        }

        private void SetPermissionView(bool isAdmin) {
            if (isAdmin) {
                return;
            }
            this.TsMenuItemPermissions.Visible = false;
            this.tSMenuItemSupplierManagement.Visible = false;
            this.tSMenuItemWarehouseManagement.Visible = false;
            this.tSMenuItemSizeManagement.Visible = false;
            this.tSMenuItemColorManagement.Visible = false;
            this.tSMenuItemCommodityManagement.Visible = false;
        }

    }
}
