using SalesManagement.BLL;
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
        #region 初始化
        private void StockTakingCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        private void InitData() {
            string errText="";
            var warehouses = _stockManageService.GetAllStocks(out errText);
            if (warehouses==null||warehouses.Count==0) {
                MessageBox.Show(errText);
                ClearPage();
                return;
            }
            this.cmboxWarehouse.DataSource = warehouses;
            this.cmboxWarehouse.DisplayMember = "";
            
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
            dt.Columns.Add("CommodityId",typeof(Guid));
            dt.Columns.Add("CommodityNo");
            dt.Columns.Add("CommodityName");
            dt.Columns.Add("Size");
            dt.Columns.Add("Color");
            dt.Columns.Add("UnitPrice",typeof(decimal));
            dt.Columns.Add("Remark");
            dt.Columns.Add("WarehouseId", typeof(Guid));
            dt.Columns.Add("StockDetailId", typeof(Guid));
            dt.Columns.Add("Count", typeof(int));
            return dt;
        }
        #endregion
        
    }
}
