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
    public partial class PermissionsCtrl : SalesManagement.UI.BaseCtrl {
        public PermissionsCtrl() {
            InitializeComponent();
        }
        private UserInfoService _userInfoService = new UserInfoService();
        private Guid _currentId;

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Guid));
            dt.Columns.Add("Name");
            dt.Columns.Add("Password");
            dt.Columns.Add("Permission",typeof(bool));
            dt.Columns.Add("Remark");
            return dt;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            string errText = "";
            if (_userInfoService==null) {
                _userInfoService = new UserInfoService();
            }
            var list = _userInfoService.GetEntityList(out errText);
            if (list == null||list.Count==0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName"></param>
        private void QueryData(string userName) {
            if (string.IsNullOrEmpty(userName)) {
                MessageBox.Show("请输入查询的用户名！");
                return;
            }
            if (_userInfoService==null) {
                _userInfoService = new UserInfoService();
            }
            string errText;
            var result = _userInfoService.QueryUserInfo(out errText, userName);
            if (result==null||result.Count==0) {
                MessageBox.Show("没有找到匹配的用户！");
                return;
            }
            this.dataGridView1.DataSource = result;
        }

        /// <summary>
        /// 清除界面
        /// </summary>
        private void ClearPage() {
            this.txtBoxUserName.Text = this.txtBoxPassword.Text = this.txtBoxRemark.Text = "";
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
        /// 验证输入的用户信息
        /// </summary>
        /// <returns></returns>
        private bool InputValidate() {
            if (string.IsNullOrEmpty(this.txtBoxUserName.Text)) {
                MessageBox.Show("用户名不可为空！");
                return false;
            }
            if (this.txtBoxUserName.Text.Length > 10) {
                MessageBox.Show("用户名长度不可大于20个字符！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxPassword.Text)) {
                MessageBox.Show("密码不可为空！");
                return false;
            }
            if (this.txtBoxPassword.Text.Length > 20) {
                MessageBox.Show("密码长度不可大于20个字符！");
                return false;
            }
            if (string.IsNullOrEmpty(this.cmBoxPermission.Text)) {
                MessageBox.Show("请选择用户权限！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否存在重复的用户名校验
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private bool HasUserNameValidator(string userName, bool isModify) {
            if (string.IsNullOrEmpty(userName)) {
                MessageBox.Show("用户名为空！");
                return false;
            }
            string errText = "";
            var list = _userInfoService.ExactQueryUserInfo(out errText, userName);
            if (!isModify) {
                if (list != null && list.Count != 0) {
                    MessageBox.Show("用户名已存在，请重新输入！");
                    return false;
                }
            } else {
                if (list != null && list.Count > 1) {
                    MessageBox.Show("用户名已存在，请重新输入！");
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
            if (!HasUserNameValidator(this.txtBoxUserName.Text,false)) {
                return;
            }
            string errText;
            var userInfo = new UserInfo() {
                Id = _currentId, UserName = this.txtBoxUserName.Text, Password = this.txtBoxPassword.Text,
                Permission = GetUserPermission(this.cmBoxPermission.Text),Remark =this.txtBoxRemark.Text};
            var i = _userInfoService.InsertEntity(out errText, userInfo);
            if (i==0) {
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
            if (!HasUserNameValidator(this.txtBoxUserName.Text, true)) {
                return;
            }
            string errText;
            var userInfo = new UserInfo() {
                Id = _currentId, UserName = this.txtBoxUserName.Text, Password = this.txtBoxPassword.Text,
                Permission = GetUserPermission(this.cmBoxPermission.Text), Remark = this.txtBoxRemark.Text
            };
            var i = _userInfoService.UpdateEntity(out errText, userInfo);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("修改成功！");
            ClearPage();
            InitData();
        }

        private void PermissionsCtrl_Load(object sender, EventArgs e) {
            InitData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            ClearPage();
            QueryData(this.txtBoxUserNameQuery.Text);
       }

        private void btnAllUser_Click(object sender, EventArgs e) {
            ClearPage();
            InitData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string errText;
            if (_userInfoService==null) {
                _userInfoService = new UserInfoService();
            }
            var i = _userInfoService.DeleteEntity(out errText, _currentId);
            if (i==0) {
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
                _currentId = (Guid)row["Id"];
                this.txtBoxUserName.Text = row["Name"] == null ? "" : row["Name"].ToString();
                this.txtBoxPassword.Text = row["Password"] == null ? "" : row["Password"].ToString();
                this.txtBoxRemark.Text = row["Remark"] == null ? "" : row["Remark"].ToString();
                this.cmBoxPermission.SelectedIndex = row["Permission"] == null || row["Permission"].ToString() == "操作员" ? 1 : 0;
                return;
            }
            var list = this.dataGridView1.DataSource as List<UserInfo>;
            if (list!=null&&list.Count>0) {
                var info = list[e.RowIndex];
                _currentId = info.Id;
                this.txtBoxUserName.Text = info.UserName;
                this.txtBoxPassword.Text = info.Password;
                this.txtBoxRemark.Text = info.Remark;
                this.cmBoxPermission.SelectedIndex =info.Permission == false ? 1 : 0;
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
