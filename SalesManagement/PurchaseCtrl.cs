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
    public partial class PurchaseCtrl : SalesManagement.UI.BaseCtrl {
        public PurchaseCtrl() {
            InitializeComponent();
        }

        public PurchaseCtrl(UserInfo userInfo)
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
        private Guid _purchaseDocId = Guid.NewGuid();
        private PurchaseOrderDocService _srv = new PurchaseOrderDocService();
        private PurchaseDocClientInfo _info;
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            _purchaseDocId = Guid.NewGuid();
            ClearPage();
            SetUserInfo();
            SetOrderNo();
            SetSupplierInfo();
            SetWarehouseInfo();
        }

        /// <summary>
        /// 设置仓库信息
        /// </summary>
        private void SetWarehouseInfo() {
            this.cmboxWarehouse.DataSource = null;
            var warehouseInfoService = new WarehouseInfoService();
            string errText;
            var warehouses = warehouseInfoService.GetEntityList(out errText);
            if (warehouses == null || warehouses.Count == 0) {
                return;
            }
            this.cmboxWarehouse.DataSource = warehouses;
            this.cmboxWarehouse.DisplayMember = "WarehouseName";
            this.cmboxWarehouse.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置供应商信息
        /// </summary>
        private void SetSupplierInfo() {
            this.cmboxSupplier.DataSource = null;
            var supplierInfoService = new SupplierInfoService();
            string errText;
            var suppliers = supplierInfoService.GetEntityList(out errText);
            if (suppliers == null || suppliers.Count == 0) {
                return;
            }
            this.cmboxSupplier.DataSource = suppliers;
            this.cmboxSupplier.DisplayMember = "SupplierName";
            this.cmboxSupplier.SelectedIndex = 0;
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
            this.txtboxRemark.Text = "";
            this.dtPicker1.Value = DateTime.Now;
            this.dataGridView1.DataSource = CreateDtTemplate();
        }

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("PurchaseDetailDocId", typeof(Guid));
            dt.Columns.Add("PurchaseDocId", typeof(Guid));
            dt.Columns.Add("CommodityName");
            dt.Columns.Add("CommodityId", typeof(Guid));
            dt.Columns.Add("Count", typeof(int));
            dt.Columns.Add("Size");
            dt.Columns.Add("Color");
            dt.Columns.Add("Unit");
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("Price", typeof(decimal));
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
                var row = dt.NewRow();
                row["PurchaseDetailDocId"] = Guid.NewGuid();
                row["PurchaseDocId"] = _purchaseDocId;
                row["CommodityName"] = item.CommodityName;
                row["CommodityId"] = item.CommodityId;
                row["Count"] = 0;
                row["Size"] = item.Size;
                row["Color"] = item.Color;
                row["Unit"] = item.Unit;
                row["UnitPrice"] = item.UnitPrice;
                row["Price"] = 0;
                row["Remark"] = item.Remark;
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private bool InputValidator() {
            if (this.cmboxSupplier.SelectedValue == null) {
                MessageBox.Show("请选择供应商！");
                return false;
            }
            if (this.cmboxWarehouse.SelectedValue == null) {
                MessageBox.Show("请选择仓库！");
                return false;
            }
            var data = this.dataGridView1.DataSource as DataTable;
            if (data == null || data.Rows.Count == 0) {
                MessageBox.Show("请选择进货商品！");
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
        private void PurchaseCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

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
            var supplier = this.cmboxSupplier.SelectedValue as SupplierInfo;
            if (supplier == null) {
                MessageBox.Show("请选择供应商！");
                return;
            }
            var warehouse = this.cmboxWarehouse.SelectedValue as WarehouseInfo;
            if (warehouse == null) {
                MessageBox.Show("请选择仓库！");
                return;
            }
            PurchaseDocInfo purchaseDocInfo = new PurchaseDocInfo() {
                PurchaseDocId = _purchaseDocId, PurchaseDocNo = this.lblOrderNo.Text, SupplierId = supplier.SupplierId, PurchaseTime = this.dtPicker1.Value,
                OperatorId = _userInfo.Id, WarehouseId = warehouse.WarehouseId, Remark = this.txtboxRemark.Text,Price=Convert.ToInt32(this.lblPrice.Text)
            };
            var data = this.dataGridView1.DataSource as DataTable;
            if (data == null || data.Rows.Count == 0) {
                MessageBox.Show("请选择采购商品！");
                return;
            }
            List<PurchaseDetailDocInfo> details = new List<PurchaseDetailDocInfo>();
            foreach (DataRow row in data.Rows) {
                details.Add(new PurchaseDetailDocInfo() {
                    PurchaseDetailDocId = (Guid)row["PurchaseDetailDocId"], PurchaseDocId = (Guid)row["PurchaseDocId"],
                    CommodityId = (Guid)row["CommodityId"], Count = (int)row["Count"], Price = (decimal)row["Price"], Remark = row["Remark"].ToString()
                });
            }
            string errText;
            int i = _srv.PurchaseOrder(out errText, purchaseDocInfo, details);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("采购成功！");
            InitData();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            InitData();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) {
                return;
            }
            if (e.ColumnIndex == 4) {
                var row = this.dataGridView1.Rows[e.RowIndex];
                if (row == null) {
                    return;
                }
                var detail = row.DataBoundItem as DataRowView;
                if (detail == null) {
                    return;
                }
                detail["Price"] = (decimal)detail["UnitPrice"] * (int)detail["Count"];
                this.lblPrice.Text = CaculateSum().ToString();
            }
        }

        #endregion

        #region 显示进货明细
        public PurchaseCtrl(PurchaseDocClientInfo info)
            : this() {
            this.Load -= PurchaseCtrl_Load;
            this.Load += PurchaseCtrl_Load2;
            _info = info;
        }

        private void PurchaseCtrl_Load2(object sender, EventArgs e) {
            SetReadOnlyPage(_info);
        }

        /// <summary>
        /// 设置只读页面信息
        /// </summary>
        /// <param name="info"></param>
        private void SetReadOnlyPage(PurchaseDocClientInfo info) {
            if (_info == null) {
                ClearPage();
            }
            this.lblOrderNo.Text = info.PurchaseDocNo.ToString();
            UserInfoService _userInfoService = new UserInfoService();
            string errText = "";
            var operatorName = _userInfoService.GetUserNameById(out errText, info.OperatorId);
            this.lblOperator.Text = string.IsNullOrEmpty(operatorName) ? "" : operatorName;
            this.cmboxSupplier.Items.Add(info.SupplierName);
            this.cmboxSupplier.SelectedIndex = 0;
            this.cmboxWarehouse.Items.Add(info.WarehouseName);
            this.cmboxWarehouse.SelectedIndex = 0;

            this.dtPicker1.Value = info.PurchaseTime;
            this.dtPicker1.Enabled = false;
            this.btnAdd.Visible = this.btnDelete.Visible = this.btnCancel.Visible = this.btnOk.Visible = false;
            this.txtboxRemark.Text = info.Remark;
            this.txtboxRemark.Enabled = false;
            SetDetailInfo(info.PurchaseDocId);

        }

        /// <summary>
        /// 设置商品明细
        /// </summary>
        /// <param name="purchaseDocId"></param>
        private void SetDetailInfo(Guid purchaseDocId) {
            this.dataGridView1.Columns["Column6"].ReadOnly = true;
            if (purchaseDocId == Guid.Empty) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            PurchaseOrderDocService _srv = new PurchaseOrderDocService();
            string errText = "";
            DataTable dt = _srv.GetDetailsByDocNo(out errText, purchaseDocId);
            if (dt == null || dt.Rows.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = dt;
            CaculateSum();
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
