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
    public partial class LabelAndTextBoxCtrl : UserControl {
        public LabelAndTextBoxCtrl() {
            InitializeComponent();
        }

        public LabelAndTextBoxCtrl(string label,string txtBox):this() {
            this.label1.Text = label;
            this.textBox1.Text = txtBox;
        }
        
    }
}
