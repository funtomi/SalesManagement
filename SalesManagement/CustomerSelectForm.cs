using SalesManagement.BLL;
using SalesManagement.Model;
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
    public partial class CustomerSelectForm : Form {
        public CustomerSelectForm() {
            InitializeComponent();
        }

        private CustomerInfoService _customerInfoService = new CustomerInfoService();
        private Guid _currentId;

        public CustomerInfo SelectedInfo {
            get { return _selectedInfo; }
            set { _selectedInfo = value; }
        }
        private CustomerInfo _selectedInfo;
        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerId", typeof(Guid));
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("Sex", typeof(int));
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

        #region 事件 

        private void CustomerSelectForm_Load(object sender, EventArgs e) {
            InitData();
        } 

        private void btnQuery_Click(object sender, EventArgs e) {
            QueryData(this.txtBoxCustomerQuery.Text);
        }

        private void btnAllUser_Click(object sender, EventArgs e) {
            InitData();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            var list = this.dataGridView1.DataSource as List<CustomerInfo>;
            var rows = this.dataGridView1.SelectedRows;
            if (rows ==null||rows.Count==0) {
                MessageBox.Show("没有选中的会员！");
                return;
            }
            var row = rows[0].DataBoundItem as CustomerInfo;
            _selectedInfo = row;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        #endregion 
    }
}
