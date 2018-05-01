using SalesManagement.BLL;
using SalesManagement.Common;
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
    public partial class AddCommodityForm : Form {
        public AddCommodityForm() {
            InitializeComponent();
            this.skinEngine1.SkinFile = "mp10maroon.ssk";
            this.Column12.FalseValue = false;
            this.Column12.TrueValue = true;
        }

        public AddCommodityForm(DataTable dt)
            : this() {
            _currentDt = dt;
        }
        private DataTable _currentDt;
        private CommodityInfoService _commodityInfoService = new CommodityInfoService();
        private TypeInfoService _typeInfoService = new TypeInfoService();
        /// <summary>
        /// 需要添加的商品
        /// </summary>
        public List<CommodityClientInfo> SelectedInfos {
            get { return _selectedInfos; }
            set { _selectedInfos = value; }
        }
        private List<CommodityClientInfo> _selectedInfos = new List<CommodityClientInfo>();

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

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("CommodityId", typeof(Guid));
            dt.Columns.Add("IsSelected", typeof(bool));
            dt.Columns.Add("CommodityNo");
            dt.Columns.Add("TypeId", typeof(Guid));
            dt.Columns.Add("CommodityName");
            dt.Columns.Add("TypeName");
            dt.Columns.Add("Size");
            dt.Columns.Add("Color");
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("Discount", typeof(int));
            dt.Columns.Add("Unit");
            dt.Columns.Add("Remark");
            return dt;
        }

        /// <summary>
        /// 查找商品
        /// </summary>
        /// <param name="commodityNo"></param>
        private void QueryData(string commodityNo) {
            if (string.IsNullOrEmpty(commodityNo)) {
                MessageBox.Show("请输入查询的商品编号！");
                return;
            }
            if (_commodityInfoService == null) {
                _commodityInfoService = new CommodityInfoService();
            }
            string errText;
            var result = _commodityInfoService.QueryCommodityInfo(out errText, commodityNo);
            if (result == null || result.Count == 0) {
                MessageBox.Show("没有找到匹配的商品！");
                return;
            }
            var data = EntityHelper.CreateInstanceCollection(result);
            this.dataGridView1.DataSource = data;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitCommodityData() {
            string errText = "";
            if (_commodityInfoService == null) {
                _commodityInfoService = new CommodityInfoService();
            }
            List<CommodityInfo> list;
            list = _commodityInfoService.GetEntityList(out errText);
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            var data = GetDistinctData(_currentDt, list);
            this.dataGridView1.DataSource = EntityHelper.CreateInstanceCollection(data);
        }

        /// <summary>
        /// 去除已包含的商品
        /// </summary>
        /// <param name="oldData"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<CommodityInfo> GetDistinctData(DataTable oldData, List<CommodityInfo> list) {
            if (oldData == null || oldData.Rows.Count == 0) {
                return list;
            }
            foreach (DataRow row in oldData.Rows) {
                var id = (Guid)row["CommodityId"];
                list.RemoveAll(l => l.CommodityId == id);
            }
            return list;
        }

        #region 事件
        private void AddCommodityForm_Load(object sender, EventArgs e) {
            InitCommodityData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            QueryData(this.txtBoxCommodityQuery.Text);
        }

        private void btnAllUser_Click(object sender, EventArgs e) {
            InitCommodityData();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            var list = this.dataGridView1.DataSource as List<CommodityClientInfo>;
            _selectedInfos.Clear();
            if (list == null || list.Count == 0) {
                MessageBox.Show("没有选中的商品！");
                return;
            }
            foreach (var commodity in list) {
                if (commodity.IsSelected) {
                    _selectedInfos.Add(commodity);
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
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
