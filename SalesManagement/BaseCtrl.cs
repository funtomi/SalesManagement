using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
