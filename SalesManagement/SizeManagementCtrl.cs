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
    public partial class SizeManagementCtrl : SalesManagement.UI.BaseCtrl {
        public SizeManagementCtrl() {
            InitializeComponent();
        }

        private SizeInfoService _SizeInfoService = new SizeInfoService();
        private Guid _currentId;

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("SizeId", typeof(Guid));
            dt.Columns.Add("SizeName"); 
            dt.Columns.Add("Remark");
            return dt;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            string errText = "";
            if (_SizeInfoService == null) {
                _SizeInfoService = new SizeInfoService();
            }
            var list = _SizeInfoService.GetEntityList(out errText);
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 查找尺码
        /// </summary>
        /// <param name="SizeName"></param>
        private void QueryData(string SizeName) {
            if (string.IsNullOrEmpty(SizeName)) {
                MessageBox.Show("请输入查询的尺码！");
                return;
            }
            if (_SizeInfoService == null) {
                _SizeInfoService = new SizeInfoService();
            }
            string errText;
            var result = _SizeInfoService.QuerySizeInfo(out errText, SizeName);
            if (result == null || result.Count == 0) {
                MessageBox.Show("没有找到匹配的尺码！");
                return;
            }
            this.dataGridView1.DataSource = result;
        }

        /// <summary>
        /// 清除界面
        /// </summary>
        private void ClearPage() {
            this.txtBoxSize.Text = this.txtBoxRemark.Text = "";
        }

        /// <summary>
        /// 验证输入的尺码信息
        /// </summary>
        /// <returns></returns>
        private bool InputValidate() {
            if (string.IsNullOrEmpty(this.txtBoxSize.Text)) {
                MessageBox.Show("尺码不可为空！");
                return false;
            }
            if (this.txtBoxSize.Text.Length > 10) {
                MessageBox.Show("尺码长度不可大于10个字符！");
                return false;
            } 
            return true;
        }

        /// <summary>
        /// 是否存在重复的尺码名校验
        /// </summary>
        /// <param name="SizeName"></param>
        /// <returns></returns>
        private bool HasUserNameValidator(string SizeName, bool isModify) {
            if (string.IsNullOrEmpty(SizeName)) {
                MessageBox.Show("尺码为空！");
                return false;
            }
            string errText = "";
            var list = _SizeInfoService.ExactQuerySizeInfo(out errText, SizeName);
            if (!isModify) {
                if (list != null && list.Count != 0) {
                    MessageBox.Show("尺码已存在，请重新输入！");
                    return false;
                }
            } else {
                if (list != null && list.Count > 1) {
                    MessageBox.Show("尺码已存在，请重新输入！");
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
            if (!HasUserNameValidator(this.txtBoxSize.Text, false)) {
                return;
            }
            string errText;
            var SizeInfo = new SizeInfo() {
                SizeId = _currentId, SizeName = this.txtBoxSize.Text,
                Remark = this.txtBoxRemark.Text
            };
            var i = _SizeInfoService.InsertEntity(out errText, SizeInfo);
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
            if (!HasUserNameValidator(this.txtBoxSize.Text, true)) {
                return;
            }
            string errText;
            var SizeInfo = new SizeInfo() {
                SizeId = _currentId, SizeName = this.txtBoxSize.Text,
                Remark = this.txtBoxRemark.Text
            };
            var i = _SizeInfoService.UpdateEntity(out errText, SizeInfo);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("修改成功！");
            ClearPage();
            InitData();
        }

         
        private void SizeManagementCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            ClearPage();
            QueryData(this.txtBoxSizeQuery.Text);
        }

        private void btnAll_Click(object sender, EventArgs e) {
            ClearPage();
            InitData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string errText;
            if (_SizeInfoService == null) {
                _SizeInfoService = new SizeInfoService();
            }
            var i = _SizeInfoService.DeleteEntity(out errText, _currentId);
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
                _currentId = (Guid)row["SizeId"];
                this.txtBoxSize.Text = row["SizeName"] == null ? "" : row["SizeName"].ToString();
                this.txtBoxRemark.Text = row["Remark"] == null ? "" : row["Remark"].ToString();
                return;
            }
            var list = this.dataGridView1.DataSource as List<SizeInfo>;
            if (list != null && list.Count > 0) {
                var info = list[e.RowIndex];
                _currentId = info.SizeId;
                this.txtBoxSize.Text = info.SizeName;
                this.txtBoxRemark.Text = info.Remark;
                return;
            }

        }
        #endregion       
    }
}
