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
    public partial class SupplierManagementCtrl : SalesManagement.UI.BaseCtrl {
        public SupplierManagementCtrl() {
            InitializeComponent();
        }

        private SupplierInfoService _supplierInfoService = new SupplierInfoService();
        private Guid _currentId;

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("SupplierId", typeof(Guid));
            dt.Columns.Add("SupplierName");
            dt.Columns.Add("PhoneNum");
            dt.Columns.Add("Address");
            dt.Columns.Add("Remark");
            return dt;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            string errText = "";
            if (_supplierInfoService == null) {
                _supplierInfoService = new SupplierInfoService();
            }
            var list = _supplierInfoService.GetEntityList(out errText);
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 查找供应商
        /// </summary>
        /// <param name="supplierName"></param>
        private void QueryData(string supplierName) {
            if (string.IsNullOrEmpty(supplierName)) {
                MessageBox.Show("请输入查询的供应商名！");
                return;
            }
            if (_supplierInfoService == null) {
                _supplierInfoService = new SupplierInfoService();
            }
            string errText;
            var result = _supplierInfoService.QuerySupplierInfo(out errText, supplierName);
            if (result == null || result.Count == 0) {
                MessageBox.Show("没有找到匹配的供应商！");
                return;
            }
            this.dataGridView1.DataSource = result;
        }

        /// <summary>
        /// 清除界面
        /// </summary>
        private void ClearPage() {
            this.txtBoxSupplierName.Text = this.txtBoxAddress.Text = this.txtBoxAddress.Text = this.txtBoxPhoneNum.Text = "";
        }

        /// <summary>
        /// 获取管理员字段值
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        private bool GetUserPermission(string permission) {
            switch (permission) {
                default:
                case "操作员":
                    return false;
                case "管理员":
                    return true;
            }
        }

        /// <summary>
        /// 验证输入的供应商信息
        /// </summary>
        /// <returns></returns>
        private bool InputValidate() {
            if (string.IsNullOrEmpty(this.txtBoxSupplierName.Text)) {
                MessageBox.Show("供应商名不可为空！");
                return false;
            }
            if (this.txtBoxSupplierName.Text.Length > 10) {
                MessageBox.Show("供应商名长度不可大于20个字符！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxPhoneNum.Text)) {
                MessageBox.Show("联系方式不可为空！");
                return false;
            }
            if (this.txtBoxPhoneNum.Text.Length > 20) {
                MessageBox.Show("请输入正确的联系方式！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxAddress.Text)) {
                MessageBox.Show("供应商地址不可为空！！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否存在重复的供应商名校验
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        private bool HasUserNameValidator(string supplierName, bool isModify) {
            if (string.IsNullOrEmpty(supplierName)) {
                MessageBox.Show("供应商名为空！");
                return false;
            }
            string errText = "";
            var list = _supplierInfoService.ExactQuerySupplierInfo(out errText, supplierName);
            if (!isModify) {
                if (list != null && list.Count != 0) {
                    MessageBox.Show("供应商名已存在，请重新输入！");
                    return false;
                }
            } else {
                if (list != null && list.Count > 1) {
                    MessageBox.Show("供应商名已存在，请重新输入！");
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(errText)) {
                MessageBox.Show(errText);
                return false;
            }
            return true;
        }

        #region 事件
        private void btnAdd_Click(object sender, EventArgs e) {
            if (!InputValidate()) {
                return;
            }
            if (!HasUserNameValidator(this.txtBoxSupplierName.Text, false)) {
                return;
            }
            string errText;
            var supplierInfo = new SupplierInfo() {
                SupplierId = _currentId, SupplierName = this.txtBoxSupplierName.Text, PhoneNum = this.txtBoxPhoneNum.Text,
                Address = this.txtBoxAddress.Text, Remark = this.txtBoxRemark.Text
            };
            var i = _supplierInfoService.InsertEntity(out errText, supplierInfo);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("添加成功！");
            ClearPage();
            InitData();
        }

        private void btnModify_Click(object sender, EventArgs e) {
            if (!InputValidate()) {
                return;
            }
            if (!HasUserNameValidator(this.txtBoxSupplierName.Text, true)) {
                return;
            }
            string errText;
            var supplierInfo = new SupplierInfo() {
                SupplierId = _currentId, SupplierName = this.txtBoxSupplierName.Text, PhoneNum = this.txtBoxPhoneNum.Text,
                Address = this.txtBoxAddress.Text, Remark = this.txtBoxRemark.Text
            };
            var i = _supplierInfoService.UpdateEntity(out errText, supplierInfo);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("修改成功！");
            ClearPage();
            InitData();
        }
 
        private void SupplierManagementCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            ClearPage();
            QueryData(this.txtBoxSupplierQuery.Text);
        }

        private void btnAllUser_Click(object sender, EventArgs e) {
            ClearPage();
            InitData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string errText;
            if (_supplierInfoService == null) {
                _supplierInfoService = new SupplierInfoService();
            }
            var i = _supplierInfoService.DeleteEntity(out errText, _currentId);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("删除成功！");
            ClearPage();
            InitData();

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) {
                return;
            }
            ClearPage();
            var dt = this.dataGridView1.DataSource as DataTable;
            if (dt != null && dt.Rows.Count != 0) {
                var row = dt.Rows[e.RowIndex];
                _currentId = (Guid)row["SupplierId"];
                this.txtBoxSupplierName.Text = row["SupplierName"] == null ? "" : row["SupplierName"].ToString();
                this.txtBoxPhoneNum.Text = row["PhoneNum"] == null ? "" : row["PhoneNum"].ToString();
                this.txtBoxAddress.Text = row["Address"] == null ? "" : row["Address"].ToString();
                this.txtBoxRemark.Text = row["Remark"] == null ? "" : row["Remark"].ToString();
                return;
            }
            var list = this.dataGridView1.DataSource as List<SupplierInfo>;
            if (list != null && list.Count > 0) {
                var info = list[e.RowIndex];
                _currentId = info.SupplierId;
                this.txtBoxSupplierName.Text = info.SupplierName;
                this.txtBoxPhoneNum.Text = info.PhoneNum;
                this.txtBoxAddress.Text = info.Address;
                this.txtBoxRemark.Text = info.Remark;
                return;
            }

        }
        #endregion  
          
    }
}
