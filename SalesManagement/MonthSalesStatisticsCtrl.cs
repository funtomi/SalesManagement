using SalesManagement.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.UI {
    public partial class MonthSalesStatisticsCtrl : SalesManagement.UI.BaseCtrl {
        public MonthSalesStatisticsCtrl() {
            InitializeComponent();
        }

        private SalesInfoService _srv = new SalesInfoService();

        private void InitData() { 
            this.dtPicker1.Value = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            QueryData(); 
        }

        private void QueryData() {
            if (this.dtPicker1.Value == null) {
                MessageBox.Show("请选择统计时间！");
                return;
            }
            string errText;
            DataTable data = _srv.GetMonthSalesStatistic(out errText, this.dtPicker1.Value);
            if (data == null || data.Rows.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            var sumData = GetSumRow(data);
            if (sumData == null || sumData.Rows.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = sumData;
        }

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private object CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("CommodityNo");
            dt.Columns.Add("CommodityName");
            dt.Columns.Add("CommodityId", typeof(Guid));
            dt.Columns.Add("Count", typeof(int));
            dt.Columns.Add("Price", typeof(decimal));
            return dt;
        }

        /// <summary>
        /// 合计
        /// </summary>
        /// <param name="data"></param>
        private DataTable GetSumRow(DataTable data) {
            if (data == null || data.Rows.Count == 0) {
                return null;
            }
            var row = data.NewRow();
            row["CommodityNo"] = "合计";
            row["Count"] = 0;
            row["Price"] = 0;
            foreach (DataRow item in data.Rows) {
                row["Count"] = (int)row["Count"] + (int)item["Count"];
                row["Price"] = (decimal)row["Price"] + (decimal)item["Price"];
            }
            data.Rows.Add(row);
            return data;
        }
        #region 事件 
        private void btnQuery_Click(object sender, EventArgs e) {
            QueryData();
        }

        private void MonthSalesStatisticsCtrl_Load(object sender, EventArgs e) {
            InitData();
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
