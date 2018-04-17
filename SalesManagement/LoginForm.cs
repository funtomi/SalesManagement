using SalesManagement.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement.UI {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
        }

       
        /// <summary>
        /// 验证输入
        /// </summary>
        /// <returns></returns>
        private bool CheckUserInfo() {
            if (string.IsNullOrEmpty(this.txtBoxUserName.Text)) {
                MessageBox.Show("请输入用户名");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxPassword.Text)) {
                MessageBox.Show("请输入密码！");
                return false;
            }
            return true;
        }

        private void UserLogin() {
            string errText;
            var userInfoService = new UserInfoService();
            var userInfo = userInfoService.GetLoginUserInfo(out errText, this.txtBoxUserName.Text, this.txtBoxPassword.Text);
            if (userInfo ==null) {
                if (string.IsNullOrEmpty(errText)) {
                    MessageBox.Show("用户名或密码错误！");
                    return;
                }
                MessageBox.Show(errText);
                return;
            }
            MainForm form = new MainForm(userInfo);
            form.Show();
            this.Dispose(false);
        }

        protected override void WndProc(ref Message msg) {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE)) {
                // 点击winform右上关闭按钮 
                System.Environment.Exit(0);
                return;
            }
            base.WndProc(ref msg);
        }

        #region 事件
        
        private void btnLogin_Click(object sender, EventArgs e) {
            if (!CheckUserInfo()) {
                return;
            }
            UserLogin();
        }

        private void txtBoxUserName_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                if (!CheckUserInfo()) {
                    return;
                }
                UserLogin();
            }
        }

        private void txtBoxPassword_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                if (!CheckUserInfo()) {
                    return;
                }
                UserLogin();
            }
        }
         
  
        #endregion 
    }
}
