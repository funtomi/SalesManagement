using SalesManagement.BLL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.UI {
    public partial class StockTakingCtrl : SalesManagement.UI.BaseCtrl {
        public StockTakingCtrl() {
            InitializeComponent();
        }
        private StockManageService _stockManageService = new StockManageService();
        BindingSource _bindingSource = new BindingSource();
        #region 初始化
        private void StockTakingCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitData() {
            InitWarehouses();
            StockClientInfo currentStock = this.cmboxWarehouse.SelectedItem as StockClientInfo;

            SetStockInfo(currentStock);
        }

        /// <summary>
        /// 设置库存信息
        /// </summary>
        /// <param name="currentStock"></param>
        private void SetStockInfo(StockClientInfo currentStock) {
            if (currentStock == null) {
                this.lblCapacity.Text = "0";
                this.lblCount.Text = "0";
                return;
            }
            this.lblCapacity.Text = currentStock.Capacity.ToString();
            this.lblCount.Text = currentStock.Count.ToString();

        }
        /// <summary>
        /// 初始化仓库信息
        /// </summary>
        private void InitWarehouses() {
            string errText = "";
            var warehouses = _stockManageService.GetAllStocks(out errText);
            if (warehouses == null || warehouses.Count == 0) {
                MessageBox.Show(errText);
                ClearPage();
                return;
            }

            _bindingSource.DataSource = warehouses;
            this.cmboxWarehouse.DataSource = _bindingSource.DataSource;
            this.cmboxWarehouse.DisplayMember = "WarehouseName";
            this.cmboxWarehouse.SelectedIndex = 0;
        }

        /// <summary>
        /// 选择的仓库改变时，修改显示的库存信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboxWarehouse_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.cmboxWarehouse.SelectedIndex < 0) {
                return;
            }
            var currentWarehouse = this.cmboxWarehouse.SelectedItem as StockClientInfo;
            SetStockInfo(currentWarehouse);
        }

        private void ClearPage() {
            this.cmboxWarehouse.DataSource = null;
            this.dataGridView1.DataSource = CreateTemplateDt();
            this.lblCapacity.Text = this.lblCount.Text = "";
        }

        /// <summary>
        /// 创建数据模板
        /// </summary>
        /// <returns></returns>
        private DataTable CreateTemplateDt() {
            DataTable dt = new DataTable();
            dt.Columns.Add("CommodityId", typeof(Guid));
            dt.Columns.Add("CommodityNo");
            dt.Columns.Add("CommodityName");
            dt.Columns.Add("Size");
            dt.Columns.Add("Color");
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("Remark");
            dt.Columns.Add("WarehouseId", typeof(Guid));
            dt.Columns.Add("StockDetailId", typeof(Guid));
            dt.Columns.Add("Count", typeof(int));
            return dt;
        }
        #endregion

        #region 库存盘点
        private void btnQuery_Click(object sender, EventArgs e) {
            var currentWarehouse = this.cmboxWarehouse.SelectedItem as StockClientInfo;
            SetDetailInfo(currentWarehouse);
        }

        /// <summary>
        /// 设置库存明细信息
        /// </summary>
        /// <param name="currentWarehouse"></param>
        private void SetDetailInfo(StockClientInfo currentWarehouse) {
            if (currentWarehouse == null) {
                this.dataGridView1.DataSource = CreateTemplateDt();
                return;
            }
            string errText = "";
            var details = _stockManageService.GetStockManageInfos(out errText, currentWarehouse.WarehouseId);
            if (details == null || details.Count == 0) {
                this.dataGridView1.DataSource = CreateTemplateDt();
                return;
            }
            this.dataGridView1.DataSource = details;
        }
        #endregion

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            //显示在HeaderCell上
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++) {
                DataGridViewRow r = this.dataGridView1.Rows[i];
                r.HeaderCell.Value = string.Format("{0}", i + 1);
            }
            this.dataGridView1.Refresh();
        }




    }
}
