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
    public partial class SalesStaffCtrl : SalesManagement.UI.BaseCtrl {
        public SalesStaffCtrl() {
            InitializeComponent();
        }
        public SalesStaffCtrl(UserInfo userInfo)
            : this() {
            _userInfo = userInfo;
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo UserInfo1 {
            get { return _userInfo; }
            set { _userInfo = value; }
        }
        private UserInfo _userInfo;
        private Guid _salesId = Guid.NewGuid();
        private SalesInfoService _srv = new SalesInfoService();
        private StockManageService _stockSrv = new StockManageService();
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            _salesId = Guid.NewGuid();
            ClearPage();
            SetUserInfo();
            SetOrderNo(); 
        }
  
        /// <summary>
        /// 设置单号
        /// </summary>
        private void SetOrderNo() {
            var orderNo = OrderGeneratorHelper.GetOrderNo();
            if (string.IsNullOrEmpty(orderNo)) {
                orderNo = OrderGeneratorHelper.GetOrderNo();
            }
            this.lblOrderNo.Text = orderNo;
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        private void SetUserInfo() {
            if (_userInfo == null || string.IsNullOrEmpty(_userInfo.UserName)) {
                this.lblOperator.Text = "";
                MessageBox.Show("没有操作员信息！");
                return;
            }
            this.lblOperator.Text = _userInfo.UserName;
        }

        private void ClearPage() {
            this.lblOrderNo.Text = this.lblOperator.Text = this.lblPrice.Text = "";
            this.txtboxRemark.Text = txtBoxCustomer.Text="";
            this.dtPicker1.Value = DateTime.Now;
            this.dataGridView1.DataSource = CreateDtTemplate();
        }

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("SalesDetailDocId", typeof(Guid));
            dt.Columns.Add("SalesDocId", typeof(Guid));
            dt.Columns.Add("CommodityName");
            dt.Columns.Add("CommodityId", typeof(Guid));
            dt.Columns.Add("WarehouseId", typeof(Guid));
            dt.Columns.Add("Count", typeof(int));
            dt.Columns.Add("Size");
            dt.Columns.Add("Color");
            dt.Columns.Add("Unit");
            dt.Columns.Add("WarehouseName");
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("Discount", typeof(float));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("LeftCount", typeof(int));
            dt.Columns.Add("Remark");
            return dt;
        }

        /// <summary>
        ///将元数据转换为表格的数据源
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private DataTable GetDataSourceFromList(List<CommodityClientInfo> data) {
            var dt = CreateDtTemplate();
            if (data == null || data.Count == 0) {
                return null;
            }
            foreach (var item in data) {
                 string errText="";
                 StockDetailClientInfo warehouse = _stockSrv.GetCommdityWarehouse(out errText, item.CommodityId);
                 if (warehouse==null) {
                     continue;
                 }

                var row = dt.NewRow();
                row["SalesDetailDocId"] = Guid.NewGuid();
                row["SalesDocId"] = _salesId;
                row["CommodityName"] = item.CommodityName;
                row["CommodityId"] = item.CommodityId; 
                row["Count"] = 0;
                row["Size"] = item.Size;
                row["Color"] = item.Color;
                row["Unit"] = item.Unit;
                row["UnitPrice"] = item.UnitPrice;
                row["Price"] = 0;
                row["Remark"] = item.Remark;
                row["Discount"] = item.Discount;
                row["WarehouseId"] = warehouse.WarehouseId;
                row["WarehouseName"] = warehouse.WarehouseName;
                row["LeftCount"] = warehouse.Count;

                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private bool InputValidator() { 
            var data = this.dataGridView1.DataSource as DataTable;
            if (data == null || data.Rows.Count == 0) {
                MessageBox.Show("请选择销售商品！");
                return false;
            }
            foreach (DataRow item in data.Rows) {
                if (Convert.ToInt32(item["Count"]) <= 0) {
                    MessageBox.Show("商品数量设置不正确！");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 计算总金额
        /// </summary>
        /// <returns></returns>
        private decimal CaculateSum() {
            var data = this.dataGridView1.DataSource as DataTable;
            if (data == null || data.Rows.Count == 0) {
                return 0;
            }
            decimal sum = 0m;
            foreach (DataRow row in data.Rows) {
                var price = (decimal)row["Price"];
                sum += price;
            }
            return sum;
        }

        #region 事件 
        private void btnAdd_Click(object sender, EventArgs e) {
            var data = this.dataGridView1.DataSource as DataTable;
            using (AddCommodityForm form = new AddCommodityForm(data)) {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK) {
                    var list = form.SelectedInfos;
                    if (list == null || list.Count == 0) {
                        return;
                    }
                    var dataSrs = GetDataSourceFromList(list);
                    if (dataSrs == null || dataSrs.Rows.Count == 0) {
                        return;
                    }
                    if (data == null || data.Rows.Count == 0) {
                        this.dataGridView1.DataSource = dataSrs;
                        CaculateSum();
                        return;
                    }
                    data.Merge(dataSrs);
                    this.dataGridView1.DataSource = data;
                    CaculateSum();
                }
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e) {
            using (CustomerSelectForm form = new CustomerSelectForm()) {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK) {
                    var customer = form.SelectedInfo;
                    if (customer == null) {
                        this.txtBoxCustomer.Text = "";
                        this.txtBoxCustomer.Tag = null;
                        return;
                    }
                    this.txtBoxCustomer.Text = customer.CustomerName;
                    this.txtBoxCustomer.Tag = customer;
                    var lists = this.dataGridView1.DataSource as List<SalesClientInfo>;
                    if (lists == null || lists.Count == 0) {
                        return;
                    }
                    foreach (var item in lists) {
                        item.Price = item.UnitPrice * item.Count * Convert.ToDecimal(item.Discount) * 0.1m;
                    }
                    CaculateSum();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var selectedList = this.dataGridView1.SelectedRows;
            if (selectedList == null || selectedList.Count == 0) {
                MessageBox.Show("没有选中的商品！");
                return;
            }
            var data = this.BindingContext[dataGridView1.DataSource].Current as DataRowCollection;
            if (data == null || data.Count == 0) {
                return;
            }
            var dt = this.dataGridView1.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0) {
                return;
            }
            foreach (DataRow item in data) {
                dt.Rows.Remove(item);
            }

        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (!InputValidator()) {
                return;
            }   
            var data = this.dataGridView1.DataSource as DataTable;
            if (data == null || data.Rows.Count == 0) {
                MessageBox.Show("请选择采购商品！");
                return;
            }
            var customer = this.txtBoxCustomer.Tag as CustomerInfo; 
            SalesInfo salesInfo = new SalesInfo() { 
            SalesDocId=_salesId,SalesDocNo=this.lblOrderNo.Text,OperatorId=_userInfo.Id,SalesTime=this.dtPicker1.Value,CustomerId=customer==null?Guid.Empty:customer.CustomerId,
            Price=Convert.ToDecimal(this.lblPrice.Text)
            };
            List<SalesDetailInfo> details = new List<SalesDetailInfo>();
            foreach (DataRow row in data.Rows) {
                details.Add(new SalesDetailInfo() {
                    SalesDetailDocId = (Guid)row["SalesDetailDocId"], SalesDocId = (Guid)row["SalesDocId"],
                    CommodityId = (Guid)row["CommodityId"], Count = (int)row["Count"], UnitPrice = (decimal)row["UnitPrice"],
                    Discount = (float)row["Discount"], WarehouseId = (Guid)row["WarehouseId"],
                    Price = (decimal)row["Price"], Remark = row["Remark"].ToString()
                });
            }
            string errText;
            int i = _srv.SalesOrder(out errText, salesInfo, details);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("保存成功！");
            InitData();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            InitData();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) {
                return;
            }
            if (e.ColumnIndex == 5) {
                var row = this.dataGridView1.Rows[e.RowIndex];
                if (row == null) {
                    return;
                }
                var detail = row.DataBoundItem as DataRowView;
                if (detail == null) {
                    return;
                }

                var customer = this.txtBoxCustomer.Tag as CustomerInfo;
                if (customer == null) {
                    detail["Price"] = (decimal)detail["UnitPrice"] * (int)detail["Count"];
                } else
                    detail["Price"] = (decimal)detail["UnitPrice"] * (int)detail["Count"] * Convert.ToDecimal(detail["Discount"]) * 0.1m;
                this.lblPrice.Text = CaculateSum().ToString();
            }
        }

        private void SalesStaffCtrl_Load(object sender, EventArgs e) {
            InitData();
        }
        #endregion  
    }
}
