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
    public partial class ColorManagementCtrl : SalesManagement.UI.BaseCtrl {
        public ColorManagementCtrl() {
            InitializeComponent();
        }
        private ColorInfoService _ColorInfoService = new ColorInfoService();
        private Guid _currentId;

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("ColorId", typeof(Guid));
            dt.Columns.Add("ColorName");
            dt.Columns.Add("Remark");
            return dt;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            string errText = "";
            if (_ColorInfoService == null) {
                _ColorInfoService = new ColorInfoService();
            }
            var list = _ColorInfoService.GetEntityList(out errText);
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 查找颜色
        /// </summary>
        /// <param name="colorName"></param>
        private void QueryData(string colorName) {
            if (string.IsNullOrEmpty(colorName)) {
                MessageBox.Show("请输入查询的颜色！");
                return;
            }
            if (_ColorInfoService == null) {
                _ColorInfoService = new ColorInfoService();
            }
            string errText;
            var result = _ColorInfoService.QueryColorInfo(out errText, colorName);
            if (result == null || result.Count == 0) {
                MessageBox.Show("没有找到匹配的颜色！");
                return;
            }
            this.dataGridView1.DataSource = result;
        }

        /// <summary>
        /// 清除界面
        /// </summary>
        private void ClearPage() {
            this.txtBoxColor.Text = this.txtBoxRemark.Text = "";
        }

        /// <summary>
        /// 验证输入的颜色信息
        /// </summary>
        /// <returns></returns>
        private bool InputValidate() {
            if (string.IsNullOrEmpty(this.txtBoxColor.Text)) {
                MessageBox.Show("颜色不可为空！");
                return false;
            }
            if (this.txtBoxColor.Text.Length > 10) {
                MessageBox.Show("颜色长度不可大于10个字符！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否存在重复的颜色名校验
        /// </summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        private bool HasUserNameValidator(string colorName, bool isModify) {
            if (string.IsNullOrEmpty(colorName)) {
                MessageBox.Show("颜色为空！");
                return false;
            }
            string errText = "";
            var list = _ColorInfoService.ExactQueryColorInfo(out errText, colorName);
            if (!isModify) {
                if (list != null && list.Count != 0) {
                    MessageBox.Show("颜色已存在，请重新输入！");
                    return false;
                }
            } else {
                if (list != null && list.Count > 1) {
                    MessageBox.Show("颜色已存在，请重新输入！");
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
            if (!HasUserNameValidator(this.txtBoxColor.Text, false)) {
                return;
            }
            string errText;
            var ColorInfo = new ColorInfo() {
                ColorId = _currentId, ColorName = this.txtBoxColor.Text,
                Remark = this.txtBoxRemark.Text
            };
            var i = _ColorInfoService.InsertEntity(out errText, ColorInfo);
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
            if (!HasUserNameValidator(this.txtBoxColor.Text, true)) {
                return;
            }
            string errText;
            var ColorInfo = new ColorInfo() {
                ColorId = _currentId, ColorName = this.txtBoxColor.Text,
                Remark = this.txtBoxRemark.Text
            };
            var i = _ColorInfoService.UpdateEntity(out errText, ColorInfo);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("修改成功！");
            ClearPage();
            InitData();
        }


        private void ColorManagementCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            ClearPage();
            QueryData(this.txtBoxColorQuery.Text);
        }

        private void btnAll_Click(object sender, EventArgs e) {
            ClearPage();
            InitData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string errText;
            if (_ColorInfoService == null) {
                _ColorInfoService = new ColorInfoService();
            }
            var i = _ColorInfoService.DeleteEntity(out errText, _currentId);
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
                _currentId = (Guid)row["ColorId"];
                this.txtBoxColor.Text = row["ColorName"] == null ? "" : row["ColorName"].ToString();
                this.txtBoxRemark.Text = row["Remark"] == null ? "" : row["Remark"].ToString();
                return;
            }
            var list = this.dataGridView1.DataSource as List<ColorInfo>;
            if (list != null && list.Count > 0) {
                var info = list[e.RowIndex];
                _currentId = info.ColorId;
                this.txtBoxColor.Text = info.ColorName;
                this.txtBoxRemark.Text = info.Remark;
                return;
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
