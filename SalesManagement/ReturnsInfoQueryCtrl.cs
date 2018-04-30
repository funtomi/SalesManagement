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
    public partial class ReturnsInfoQueryCtrl : SalesManagement.UI.BaseCtrl {
        public ReturnsInfoQueryCtrl() {
            InitializeComponent();
        }

        private ReturnInfoService _srv = new ReturnInfoService();

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            ClearPage();
            QueryAllData();
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        private void QueryAllData() {
            string errText;
            List<ReturnInfo> list = _srv.QueryAllData(out errText);
            if (list == null || list.Count == 0) {
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 清除界面
        /// </summary>
        private void ClearPage() {
            this.txtReturnNo.Text = "";
            this.dtPickerStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtPickerEnd.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
            this.dataGridView1.DataSource = CreateDtTemplate();
        }

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private object CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("ReturnDocId", typeof(Guid));
            dt.Columns.Add("ReturnDocNo");
            dt.Columns.Add("OperatorId", typeof(Guid));
            dt.Columns.Add("ReturnTime", typeof(DateTime));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Reason");
            return dt;
        }

        /// <summary>
        /// 输入校验
        /// </summary>
        /// <returns></returns>
        private bool InputValidator() {
            if (string.IsNullOrEmpty(this.txtReturnNo.Text)) {
                MessageBox.Show("请输入查询单号！");
                return false;
            }
            var startValue = this.dtPickerStart.Value;
            var endValue = this.dtPickerEnd.Value;
            if (startValue == null || endValue == null) {
                MessageBox.Show("请选择查询的退货时间！");
                return false;
            }
            if (startValue > endValue) {
                MessageBox.Show("开始时间不能大于结束时间！");
                return false;
            }
            return true;
        }
        #region 事件
        private void btnQueryAll_Click(object sender, EventArgs e) {
            QueryAllData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            if (!InputValidator()) {
                return;
            }
            string errText;
            List<ReturnInfo> list = _srv.QueryWithSalesNoAndDate(out errText, this.txtReturnNo.Text, this.dtPickerStart.Value, this.dtPickerEnd.Value);
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        private void ReturnsInfoQueryCtrl_Load(object sender, EventArgs e) {
            InitData();

        }

        #endregion

        #region 打开明细界面
        public delegate void ViewDetailsDelegate(ReturnInfo info);
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
            var item = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as ReturnInfo;
            if (item == null) {
                return;
            }
            if (ViewDetailsEvent != null) {
                ViewDetailsEvent(item);
            }
        }
        #endregion
       
    }
}
