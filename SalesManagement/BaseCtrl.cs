using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManagement.Model;

namespace SalesManagement.UI {
    public partial class BaseCtrl : UserControl {
        public BaseCtrl() {
            InitializeComponent();
        }

        [Browsable(true)]
        public string TitleText { 
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo UserInfo {
            get { return _userInfo; }
            set { _userInfo = value; }
        }
        private UserInfo _userInfo;

    }
}
