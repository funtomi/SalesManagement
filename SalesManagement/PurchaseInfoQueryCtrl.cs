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
    public partial class PurchaseInfoQueryCtrl : SalesManagement.UI.BaseCtrl {
        public PurchaseInfoQueryCtrl() {
            InitializeComponent();
        }
        private PurchaseOrderDocService _srv = new PurchaseOrderDocService();

        private void InitData() {
            this.dtPickerStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtPickerEnd.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
            this.dataGridView1.DataSource = CreateDtTemplate();
            QueryData();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void QueryData() {
            var docNo = this.txtboxPurchaseNo.Text;
            var startDate = this.dtPickerStart.Value;
            var endDate = this.dtPickerEnd.Value;
            string errText = "";
            var list = _srv.QueryPurchaseDocInfo(out errText, docNo, startDate, endDate);
            if (list==null||list.Count==0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("PurchaseDocId", typeof(Guid));
            dt.Columns.Add("PurchaseDocNo");
            dt.Columns.Add("SupplierId", typeof(Guid));
            dt.Columns.Add("PurchaseTime", typeof(DateTime));
            dt.Columns.Add("OperatorId", typeof(Guid));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("WarehouseId", typeof(Guid));
            dt.Columns.Add("SupplierName");
            dt.Columns.Add("UserName");
            dt.Columns.Add("WarehouseName");
            dt.Columns.Add("Remark");
            return dt;
        }

        /// <summary>
        /// 输入校验
        /// </summary>
        /// <returns></returns>
        private bool InputValidator() {
            var docNo = this.txtboxPurchaseNo.Text;
            var startDt = this.dtPickerStart.Value;
            var endDt = this.dtPickerEnd.Value;
            if (startDt == null || endDt == null || startDt > endDt) {
                MessageBox.Show("日期格式输入不正确！");
                return false;
            }
            return true;
        }
        #region 事件
        private void PurchaseInfoQueryCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            if (!InputValidator()) {
                return;
            }
            string errText="";
            var list = _srv.QueryPurchaseDocInfo(out errText, this.txtboxPurchaseNo.Text, this.dtPickerStart.Value, this.dtPickerEnd.Value);
            if (list==null||list.Count==0) { 
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        private void btnQueryAll_Click(object sender, EventArgs e) {
            string errText = "";
            var list = _srv.QueryPurchaseDocInfo(out errText);
            if (list == null || list.Count == 0) {
                MessageBox.Show(errText);
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }
        
        #endregion
    
        #region 打开明细界面
        public delegate void ViewDetailsDelegate(PurchaseDocClientInfo info);
        public ViewDetailsDelegate ViewDetailsEvent;

        /// <summary>
        /// 双击某一个订单时打开明细界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0) {
                return;
            }
            var item = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PurchaseDocClientInfo;
            if (item == null) {
                return;
            }
            if (ViewDetailsEvent!=null) {
                ViewDetailsEvent(item);
            }
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
