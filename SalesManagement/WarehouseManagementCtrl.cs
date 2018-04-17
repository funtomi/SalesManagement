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
    public partial class WarehouseManagementCtrl : SalesManagement.UI.BaseCtrl {
        public WarehouseManagementCtrl() {
            InitializeComponent();
        }

        private WarehouseInfoService _warehouseInfoService = new WarehouseInfoService();
        private Guid _currentId;

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("WarehouseId", typeof(Guid));
            dt.Columns.Add("WarehouseName");
            dt.Columns.Add("Capicity"); 
            dt.Columns.Add("Remark");
            return dt;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            string errText = "";
            if (_warehouseInfoService == null) {
                _warehouseInfoService = new WarehouseInfoService();
            }
            var list = _warehouseInfoService.GetEntityList(out errText);
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 查找仓库
        /// </summary>
        /// <param name="warehouseName"></param>
        private void QueryData(string warehouseName) {
            if (string.IsNullOrEmpty(warehouseName)) {
                MessageBox.Show("请输入查询的仓库名！");
                return;
            }
            if (_warehouseInfoService == null) {
                _warehouseInfoService = new WarehouseInfoService();
            }
            string errText;
            var result = _warehouseInfoService.QueryWarehouseInfo(out errText, warehouseName);
            if (result == null || result.Count == 0) {
                MessageBox.Show("没有找到匹配的仓库！");
                return;
            }
            this.dataGridView1.DataSource = result;
        }

        /// <summary>
        /// 清除界面
        /// </summary>
        private void ClearPage() {
            this.txtBoxWarehouse.Text = this.txtBoxCapicity.Text = this.txtBoxRemark.Text = "";
        }
          
        /// <summary>
        /// 验证输入的仓库信息
        /// </summary>
        /// <returns></returns>
        private bool InputValidate() {
            if (string.IsNullOrEmpty(this.txtBoxWarehouse.Text)) {
                MessageBox.Show("仓库名不可为空！");
                return false;
            }
            if (this.txtBoxWarehouse.Text.Length > 10) {
                MessageBox.Show("仓库名长度不可大于10个字符！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxCapicity.Text)) {
                MessageBox.Show("库存量不可为空！");
                return false;
            } 
            return true;
        }

        /// <summary>
        /// 是否存在重复的仓库名校验
        /// </summary>
        /// <param name="warehouseName"></param>
        /// <returns></returns>
        private bool HasUserNameValidator(string warehouseName, bool isModify) {
            if (string.IsNullOrEmpty(warehouseName)) {
                MessageBox.Show("仓库名为空！");
                return false;
            }
            string errText = "";
            var list = _warehouseInfoService.ExactQueryWarehouseInfo(out errText, warehouseName);
            if (!isModify) {
                if (list != null && list.Count != 0) {
                    MessageBox.Show("仓库名已存在，请重新输入！");
                    return false;
                }
            } else {
                if (list != null && list.Count > 1) {
                    MessageBox.Show("仓库名已存在，请重新输入！");
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
            if (!HasUserNameValidator(this.txtBoxWarehouse.Text, false)) {
                return;
            }
            string errText;
            var warehouseInfo = new WarehouseInfo() {
                WarehouseId = _currentId, WarehouseName = this.txtBoxWarehouse.Text, Capicity = this.txtBoxCapicity.Text,
                Remark = this.txtBoxRemark.Text
            };
            var i = _warehouseInfoService.InsertEntity(out errText, warehouseInfo);
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
            if (!HasUserNameValidator(this.txtBoxWarehouse.Text, true)) {
                return;
            }
            string errText;
            var warehouseInfo = new WarehouseInfo() {
                WarehouseId = _currentId, WarehouseName = this.txtBoxWarehouse.Text, Capicity = this.txtBoxCapicity.Text,
                 Remark = this.txtBoxRemark.Text
            };
            var i = _warehouseInfoService.UpdateEntity(out errText, warehouseInfo);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("修改成功！");
            ClearPage();
            InitData();
        }

        private void WarehouseManagementCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            ClearPage();
            QueryData(this.txtBoxWarehouseQuery.Text);
        }
         
        private void btnAll_Click(object sender, EventArgs e) {
            ClearPage();
            InitData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string errText;
            if (_warehouseInfoService == null) {
                _warehouseInfoService = new WarehouseInfoService();
            }
            var i = _warehouseInfoService.DeleteEntity(out errText, _currentId);
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
                _currentId = (Guid)row["WarehouseId"];
                this.txtBoxWarehouse.Text = row["WarehouseName"] == null ? "" : row["WarehouseName"].ToString();
                this.txtBoxCapicity.Text = row["Capicity"] == null ? "" : row["Capicity"].ToString();
                this.txtBoxRemark.Text = row["Remark"] == null ? "" : row["Remark"].ToString();
                return;
            }
            var list = this.dataGridView1.DataSource as List<WarehouseInfo>;
            if (list != null && list.Count > 0) {
                var info = list[e.RowIndex];
                _currentId = info.WarehouseId;
                this.txtBoxWarehouse.Text = info.WarehouseName;
                this.txtBoxCapicity.Text = info.Capicity;
                this.txtBoxRemark.Text = info.Remark;
                return;
            }

        }
        #endregion    
      
    }
}
