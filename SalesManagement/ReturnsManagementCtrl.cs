using SalesManagement.BLL;
using SalesManagement.Common;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.UI {
    public partial class ReturnsManagementCtrl : SalesManagement.UI.BaseCtrl {
        public ReturnsManagementCtrl() {
            InitializeComponent();
        }

        public ReturnsManagementCtrl(UserInfo userInfo):this() {
            _userInfo = userInfo;
        }

        private UserInfo _userInfo;
        private SalesInfoService _salesInfoService = new SalesInfoService();
        private ReturnInfoService _returnInfoService = new ReturnInfoService();
        private ReturnInfo _info;
        private void InitData() {
            this.txtBoxQuery.Text = "";
            this.txtReason.Text = "";
            this.lblOperatorName.Text = _userInfo.UserName;
            this.lblReturnNo.Text = OrderGeneratorHelper.GetOrderNo();
            this.dtPickerStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtPickerEnd.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
            this.cmboxSelect.SelectedIndex = 0;
            this.dataGridView1.DataSource = CreateDtTemplate();
            QueryData();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void QueryData() {
            var docNo = this.lblReturnNo.Text;
            var startDate = this.dtPickerStart.Value;
            var endDate = this.dtPickerEnd.Value;
            string errText = "";
            List<SalesClientInfo> list = _salesInfoService.QuerySalesInfo(out errText, startDate, endDate);
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            var result = CreateDtTemplate(list);
            if (result == null || result.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = result;
        }

        /// <summary>
        /// 创建数据模板
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<ReturnClientInfo> CreateDtTemplate(List<SalesClientInfo> list) {
            List<ReturnClientInfo> result = new List<ReturnClientInfo>();
            if (list==null||list.Count==0) {
                return null;
            }
            foreach (var item in list) {
                ReturnClientInfo info = new ReturnClientInfo();
                info.IsSelected = "False";
                info.CommodityId = item.CommodityId;
                info.CommodityNo=item.CommodityNo;
                info.CommodityName=item.CommodityName;
                info.Size=item.Size;
                info.Color=item.Color;
                info.Count=item.Count; 
                info.WarehouseId=item.WarehouseId;
                info.UnitPrice = item.Price / item.Count;
                info.Price = item.Price;
                result.Add(info);
            }
            return result;
        }

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("IsSelected");
            dt.Columns.Add("CommodityId", typeof(Guid));
            dt.Columns.Add("ReturnDetailDocId", typeof(Guid));
            dt.Columns.Add("ReturnDocId", typeof(Guid));
            dt.Columns.Add("UnitPrice", typeof(decimal)); 
            dt.Columns.Add("CommodityNo");
            dt.Columns.Add("CommodityName");
            dt.Columns.Add("Size");
            dt.Columns.Add("Color");
            dt.Columns.Add("Count",typeof(int)); 
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("WarehouseId", typeof(Guid));  
            return dt;
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private bool InputValidator() {
            var startDate = this.dtPickerStart.Value;
            var endDate = this.dtPickerEnd.Value;
            if (startDate == null || endDate == null || startDate > endDate) {
                MessageBox.Show("销售日期不正确！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxQuery.Text)) {
                MessageBox.Show("查询关键字不可为空！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 计算总金额
        /// </summary>
        /// <returns></returns>
        private decimal CaculateSum() {
            var data = this.dataGridView1.DataSource as List<ReturnClientInfo>;
            if (data == null || data.Count == 0) {
                return 0;
            }
            decimal sum = 0m;
            foreach (var row in data) {
                if (row.IsSelected=="True") {
                    sum += row.Price;
                }
            }
            return sum;
        }

        /// <summary>
        /// 清除界面信息
        /// </summary>
        private void ClearPage() {
            this.lblOperatorName.Text = this.lblReturnNo.Text = "";
            this.lblPrice.Text = "0";
            this.txtBoxQuery.Text = "";
            this.dataGridView1.DataSource = CreateDtTemplate();
        }
        #region 事件
        private void ReturnsManagementCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e) {
            if (!InputValidator()) {
                return;
            }
            List<SalesClientInfo> list;
            string errText;
            if (this.cmboxSelect.SelectedIndex == 0) {
                list = _salesInfoService.QueryDataWithCommodityNo(out errText,this.txtBoxQuery.Text,this.dtPickerStart.Value,this.dtPickerEnd.Value);
            } else {
                list = _salesInfoService.QueryDataWithSalesNo(out errText, this.txtBoxQuery.Text, this.dtPickerStart.Value, this.dtPickerEnd.Value);
            }
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = CreateDtTemplate(list);
        }

         private void btnReturn_Click(object sender, EventArgs e) {
             var reason = this.txtReason.Text;
             if (string.IsNullOrEmpty(reason)) {
                 MessageBox.Show("请填写退货原因！");
                 return;
             }
             ReturnInfo info = new ReturnInfo() {ReturnDocId=Guid.NewGuid(),ReturnDocNo=this.lblReturnNo.Text,ReturnTime=DateTime.Now,OperatorId=_userInfo.Id,
             Price=Convert.ToDecimal(this.lblPrice.Text),Reason=this.txtReason.Text
             };
             var dt = this.dataGridView1.DataSource as List<ReturnClientInfo>;
             if (dt==null||dt.Count==0) {
                 MessageBox.Show("没有可以退货的产品！");
                 return;
             }
             var rows = dt.FindAll(p => p.IsSelected == "True");
             if (rows==null||rows.Count==0) {
                 MessageBox.Show("请选择要退货的商品！");
                 return;
             }
             List<ReturnDetailInfo> details = new List<ReturnDetailInfo>();
             foreach (var item in rows) {
                 ReturnDetailInfo detail = new ReturnDetailInfo() {
                     ReturnDetailDocId = Guid.NewGuid(), ReturnDocId=info.ReturnDocId,CommodityId=item.CommodityId,Count=item.Count,
                     WarehouseId=item.WarehouseId,Price=item.Price
                 };
                 details.Add(detail);
             }
             string errText="";
             int i = _returnInfoService.ReturnOrder(out errText, info, details);
             if (i<=0) {
                 MessageBox.Show(errText);
                 return;
             }
             MessageBox.Show("退货成功！");
        }

         private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
             if (e.ColumnIndex < 0 || e.RowIndex < 0) {
                 return;
             }
             if (e.ColumnIndex == 9) {
                 var row = this.dataGridView1.Rows[e.RowIndex];
                 if (row == null) {
                     return;
                 }
                 var detail = row.DataBoundItem as ReturnClientInfo;
                 if (detail == null) {
                     return;
                 }
                 detail.Price = detail.UnitPrice * detail.Count;
                
                 this.lblPrice.Text = CaculateSum().ToString();
                 return;
             }
             if (e.ColumnIndex==0) {
                 this.lblPrice.Text = CaculateSum().ToString();
             }
         }
        #endregion

        #region 显示退货明细
         public ReturnsManagementCtrl(ReturnInfo info)
            : this() {
            this.Load -= ReturnsManagementCtrl_Load;
            this.Load += ReturnsManagementCtrl_Load2;
            _info = info;
        }

         private void ReturnsManagementCtrl_Load2(object sender, EventArgs e) {
            SetReadOnlyPage(_info);
        }

        /// <summary>
        /// 设置只读页面信息
        /// </summary>
        /// <param name="info"></param>
        private void SetReadOnlyPage(ReturnInfo info) {
            if (_info == null) {
                ClearPage();
            }
            this.lblReturnNo.Text = info.ReturnDocNo.ToString();
            UserInfoService _userInfoService = new UserInfoService();
            string errText = "";
            var operatorName = _userInfoService.GetUserNameById(out errText, info.OperatorId);
            this.lblOperatorName.Text = string.IsNullOrEmpty(operatorName) ? "" : operatorName;
            this.dtPickerStart.Value = info.ReturnTime;
            this.dtPickerStart.Enabled = false;
            this.label4.Visible = this.dtPickerEnd.Visible = this.btnQuery.Visible = false;
            this.cmboxSelect.Visible = this.txtBoxQuery.Visible = this.btnReturn.Visible = false;
            this.txtReason.Text = info.Reason;
            this.txtReason.Enabled = false;
            SetDetailInfo(info.ReturnDocId);
        }

        /// <summary>
        /// 设置商品明细
        /// </summary>
        /// <param name="id"></param>
        private void SetDetailInfo(Guid id) {
            this.dataGridView1.Columns["Column3"].ReadOnly = true;
            this.dataGridView1.Columns["Column6"].Visible = false;
            if (id == Guid.Empty) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            ReturnInfoService _srv = new ReturnInfoService();
            string errText = "";
            DataTable dt = _srv.GetDetailsByDocId(out errText, id);
            if (dt == null || dt.Rows.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = dt;
            CaculateSum();
        }
        #endregion
    }
}
