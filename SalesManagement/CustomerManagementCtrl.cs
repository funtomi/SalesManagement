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
    public partial class CustomerManagementCtrl : SalesManagement.UI.BaseCtrl {
        public CustomerManagementCtrl() {
            InitializeComponent();
        }

        private CustomerInfoService _customerInfoService = new CustomerInfoService();
        private Guid _currentId;

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerId", typeof(Guid));
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("Sex",typeof(int));
            dt.Columns.Add("PhoneNum");
            dt.Columns.Add("Age");
            dt.Columns.Add("Remark");
            return dt;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            string errText = "";
            if (_customerInfoService == null) {
                _customerInfoService = new CustomerInfoService();
            }
            var list = _customerInfoService.GetEntityList(out errText);
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 查找会员
        /// </summary>
        /// <param name="customerName"></param>
        private void QueryData(string customerName) {
            if (string.IsNullOrEmpty(customerName)) {
                MessageBox.Show("请输入查询的会员名！");
                return;
            }
            if (_customerInfoService == null) {
                _customerInfoService = new CustomerInfoService();
            }
            string errText;
            var result = _customerInfoService.QueryCustomerInfo(out errText, customerName);
            if (result == null || result.Count == 0) {
                MessageBox.Show("没有找到匹配的会员！");
                return;
            }
            this.dataGridView1.DataSource = result;
        }

        /// <summary>
        /// 清除界面
        /// </summary>
        private void ClearPage() {
            this.txtBoxCustomer.Text = this.txtBoxAge.Text = this.txtBoxPhoneNum.Text = this.txtBoxRemark.Text = "";
        }
         
        /// <summary>
        /// 验证输入的会员信息
        /// </summary>
        /// <returns></returns>
        private bool InputValidate() {
            if (string.IsNullOrEmpty(this.txtBoxCustomer.Text)) {
                MessageBox.Show("会员名不可为空！");
                return false;
            }
            if (this.txtBoxCustomer.Text.Length > 10) {
                MessageBox.Show("会员名长度不可大于10个字符！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxAge.Text)) {
                MessageBox.Show("年龄不可为空！");
                return false;
            }
            var age = Convert.ToInt32(this.txtBoxAge.Text);
            if (age < 0 || age > 120) {
                MessageBox.Show("请输入正确的年龄！");
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
            return true;
        }

        /// <summary>
        /// 是否存在重复的会员名校验
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        private bool HasUserNameValidator(string customerName, bool isModify) {
            if (string.IsNullOrEmpty(customerName)) {
                MessageBox.Show("会员名为空！");
                return false;
            }
            string errText = "";
            var list = _customerInfoService.ExactQueryCustomerInfo(out errText, customerName);
            if (!isModify) {
                if (list != null && list.Count != 0) {
                    MessageBox.Show("会员名已存在，请重新输入！");
                    return false;
                }
            } else {
                if (list != null && list.Count > 1) {
                    MessageBox.Show("会员名已存在，请重新输入！");
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
            if (!HasUserNameValidator(this.txtBoxCustomer.Text, false)) {
                return;
            }
            string errText;
            var customerInfo = new CustomerInfo() {
                CustomerId = _currentId, CustomerName = this.txtBoxCustomer.Text, Sex = string.IsNullOrEmpty(this.cmboxSex.Text)?"男":this.cmboxSex.Text,
                PhoneNum = this.txtBoxPhoneNum.Text, Age = string.IsNullOrEmpty(this.txtBoxAge.Text)?0:Convert.ToInt32(this.txtBoxAge.Text), Remark = this.txtBoxRemark.Text
            };
            var i = _customerInfoService.InsertEntity(out errText, customerInfo);
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
            if (!HasUserNameValidator(this.txtBoxCustomer.Text, true)) {
                return;
            }
            string errText;
            var customerInfo = new CustomerInfo() {
                CustomerId = _currentId, CustomerName = this.txtBoxCustomer.Text, Sex = string.IsNullOrEmpty(this.cmboxSex.Text) ? "男" : this.cmboxSex.Text,
                PhoneNum = this.txtBoxPhoneNum.Text, Age = string.IsNullOrEmpty(this.txtBoxAge.Text) ? 0 : Convert.ToInt32(this.txtBoxAge.Text), Remark = this.txtBoxRemark.Text
            };
            var i = _customerInfoService.UpdateEntity(out errText, customerInfo);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("修改成功！");
            ClearPage();
            InitData();
        }

        private void CustomerManagementCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            ClearPage();
            QueryData(this.txtBoxCustomerQuery.Text);
        }

        private void btnAllUser_Click(object sender, EventArgs e) {
            ClearPage();
            InitData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string errText;
            if (_customerInfoService == null) {
                _customerInfoService = new CustomerInfoService();
            }
            var i = _customerInfoService.DeleteEntity(out errText, _currentId);
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
                _currentId = (Guid)row["CustomerId"];
                this.txtBoxCustomer.Text = row["CustomerName"] == null ? "" : row["CustomerName"].ToString();
                this.cmboxSex.SelectedIndex = row["Sex"] == null ? 0 :1;
                this.txtBoxPhoneNum.Text = row["PhoneNum"] == null ? "" : row["PhoneNum"].ToString();
                this.txtBoxAge.Text = row["Age"] == null ? "0" : row["Age"].ToString();
                this.txtBoxRemark.Text = row["Remark"] == null ? "" : row["Remark"].ToString();
                return;
            }
            var list = this.dataGridView1.DataSource as List<CustomerInfo>;
            if (list != null && list.Count > 0) {
                var info = list[e.RowIndex];
                _currentId = info.CustomerId;
                this.txtBoxCustomer.Text = info.CustomerName;
                this.cmboxSex.SelectedIndex = string.IsNullOrEmpty(info.Sex) || info.Sex == "男" ? 0 : 1;
                this.txtBoxPhoneNum.Text = info.PhoneNum;
                this.txtBoxAge.Text = info.Age.ToString();
                this.txtBoxRemark.Text = info.Remark;
                return;
            }

        }
        #endregion

    }
}
