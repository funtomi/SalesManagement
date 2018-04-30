using SalesManagement.BLL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace SalesManagement.UI {
    public partial class CommodityManagementCtrl : SalesManagement.UI.BaseCtrl {
        public CommodityManagementCtrl() {
            InitializeComponent();
        }

        private CommodityInfoService _commodityInfoService = new CommodityInfoService();
        private TypeInfoService _typeInfoService = new TypeInfoService();
        private Guid _currentId;
        private Guid _currentTypeId;
        private bool _isNew;

        /// <summary>
        /// 创建模板数据源
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDtTemplate() {
            DataTable dt = new DataTable();
            dt.Columns.Add("CommodityId", typeof(Guid));
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
        /// 初始化数据
        /// </summary>
        private void InitCommodityData() {
             ClearPage();
             SetSizeAndColorItems();
            string errText = "";
            if (_commodityInfoService == null) {
                _commodityInfoService = new CommodityInfoService();
            }
            List<CommodityInfo> list;
            if (_currentTypeId == Guid.Empty) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            list = _commodityInfoService.GetEntityList(out errText, _currentTypeId);
            if (list == null || list.Count == 0) {
                this.dataGridView1.DataSource = CreateDtTemplate();
                return;
            }
            this.dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 设置颜色和尺码信息
        /// </summary>
        private void SetSizeAndColorItems() {
            this.cmboxColor.Items.Clear();
            this.cmboxSize.Items.Clear();
            string errText = "";
            SizeInfoService sizeInfoService = new SizeInfoService();
            var list = sizeInfoService.GetEntityList(out errText);
            if (list!=null&&list.Count>0) {
                this.cmboxSize.Items.AddRange(list.Select(p=>p.SizeName).ToArray());
                this.cmboxSize.SelectedIndex = 0;
            }
            ColorInfoService colorInfoService = new ColorInfoService();
            var list2 = colorInfoService.GetEntityList(out errText);
            if (list2!=null&&list2.Count>0) {
                this.cmboxColor.Items.AddRange(list2.Select(p=>p.ColorName).ToArray());
                this.cmboxColor.SelectedIndex = 0;
            }
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
            this.dataGridView1.DataSource = result;
        }

        /// <summary>
        /// 清除界面
        /// </summary>
        private void ClearPage() {
            this.txtBoxCommodityNo.Text = this.txtBoxCommodityName.Text = this.txtBoxUnitPrice.Text = this.txtBoxDiscount.Text
                = this.txtBoxRemark.Text = "";
            this.cmboxSize.SelectedIndex =this.cmboxSize.SelectedIndex>0?0:this.cmboxSize.SelectedIndex;
            this.cmboxColor.SelectedIndex =this.cmboxColor.SelectedIndex>0?0:this.cmboxColor.SelectedIndex;
        }

        /// <summary>
        /// 验证输入的商品信息
        /// </summary>
        /// <returns></returns>
        private bool InputValidate() {
            if (_currentTypeId==Guid.Empty) {
                MessageBox.Show("请选择商品类型！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxCommodityNo.Text)) {
                MessageBox.Show("商品编号不可为空！");
                return false;
            }
            if (this.txtBoxCommodityNo.Text.Length > 10) {
                MessageBox.Show("商品编号长度不可大于10个字符！");
                return false;
            } if (string.IsNullOrEmpty(this.txtBoxCommodityName.Text)) {
                MessageBox.Show("商品名称不可为空！");
                return false;
            }
            if (this.txtBoxCommodityName.Text.Length > 10) {
                MessageBox.Show("商品名称长度不可大于10个字符！");
                return false;
            }
            if (string.IsNullOrEmpty(this.cmboxSize.Text)) {
                MessageBox.Show("请选择商品尺码！");
                return false;
            }
            if (string.IsNullOrEmpty(this.cmboxColor.Text)) {
                MessageBox.Show("请选择商品颜色！");
                return false;
            }
            decimal unitPrice=0;
            try {
                var price = Convert.ToDecimal(this.txtBoxUnitPrice.Text);
                if (price==0) {
                    MessageBox.Show("单价不可为0！");
                    return false;
                }
                unitPrice = price;
            } catch{
                MessageBox.Show("单价格式不正确");
                return false;
            }
            double discount = 0;
            try {
                var price = Convert.ToDouble(this.txtBoxDiscount.Text);
                if (price<=0||price>10) {
                    MessageBox.Show("折扣不正确！");
                    return false;
                }
                discount = price;
            } catch{
                MessageBox.Show("折扣格式不正确");
                return false;
            }
            var result = unitPrice * (Convert.ToDecimal(discount)) * 0.1m;
            if (result<=0||result>unitPrice) {
                MessageBox.Show("折扣不正确！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtBoxUnit.Text)) {
                MessageBox.Show("单位不可为空！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否存在重复的商品名校验
        /// </summary>
        /// <param name="commodityNo"></param>
        /// <returns></returns>
        private bool HasCommodityNoValidator(string commodityNo, bool isModify) {
            if (string.IsNullOrEmpty(commodityNo)) {
                MessageBox.Show("商品编号为空！");
                return false;
            }
            string errText = "";
            var list = _commodityInfoService.ExactQueryCommodityInfo(out errText, commodityNo);
            if (!isModify) {
                if (list != null && list.Count != 0) {
                    MessageBox.Show("商品编号已存在，请重新输入！");
                    return false;
                }
            } else {
                if (list != null && list.Count > 1) {
                    MessageBox.Show("商品编号已存在，请重新输入！");
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(errText)) {
                MessageBox.Show(errText);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否存在重复的类别名校验
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        private bool HasTypeNameValidator(string typeName) {
            if (string.IsNullOrEmpty(typeName)) {
                MessageBox.Show("类别名称为空！");
                return false;
            }
            string errText = "";
            var list = _typeInfoService.ExactQueryTypeInfo(out errText, typeName);
            if (!_isNew) {
                if (list != null && list.Count != 0) {
                    MessageBox.Show("类别已存在，请重新输入！");
                    return false;
                }
            } else {
                if (list != null && list.Count > 1) {
                    MessageBox.Show("类别已存在，请重新输入！");
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(errText)) {
                MessageBox.Show(errText);
                return false;
            }
            return true;
        }

        private void InitTypeData() {
            string errText = "";
            if (_typeInfoService == null) {
                _typeInfoService = new TypeInfoService();
            }
            var list = _typeInfoService.GetEntityList(out errText);
            if (list ==null||list.Count==0) {
                this.treeView1.Nodes.Clear();
                return;
            }
            CreatTreeViewNodes(list);
        }

        /// <summary>
        /// 创建树结构
        /// </summary>
        /// <param name="list"></param>
        private void CreatTreeViewNodes(List<TypeInfo> list) {
            if (list==null||list.Count==0) {
                this.treeView1.Nodes.Clear();
                return;
            }
            var roots = list.FindAll(p => p.ParentId == Guid.Empty);
            CreateRootNodes(roots);
            foreach (var root in roots) {
                var child = list.FindAll(p => p.ParentId == root.TypeId);
                CreatChildNode(child, root,list);
            }
        }

        /// <summary>
        /// 创建子节点
        /// </summary>
        /// <param name="child"></param>
        /// <param name="root"></param>
        /// <param name="list"></param>
        private void CreatChildNode(List<TypeInfo> child, TypeInfo root,List<TypeInfo> list) {
            if (child==null||child.Count==0||root==null) {
                return;
            }
            var rootNodes = this.treeView1.Nodes.Find(root.TypeName, true);
            if (rootNodes==null||rootNodes.Length==0) {
                return;
            }
            var rootNode = rootNodes[0];
            foreach (var item in child) {
                TreeNode node = new TreeNode();
                node.ContextMenuStrip = this.contextMenuStrip1;
                node.Name = item.TypeName;
                node.Text = item.TypeName;
                node.Tag = item;
                rootNode.Nodes.Add(node);
                var childList = list.FindAll(p => p.ParentId == item.TypeId);
                CreatChildNode(childList, item, list);
            }
            
        }

        /// <summary>
        /// 创建根节点
        /// </summary>
        /// <param name="roots"></param>
        private void CreateRootNodes(List<TypeInfo> roots) {
            if (roots==null||roots.Count==0) {
                return;
            }
            foreach (var item in roots) {
                TreeNode node = new TreeNode();
                node.ContextMenuStrip = this.contextMenuStrip1;
                node.Name = item.TypeName;
                node.Text = item.TypeName;
                node.Tag = item;
                this.treeView1.Nodes.Add(node);
            }
        }

        private bool SaveNode(TreeNode treeNode) {
            if (treeNode==null) {
                MessageBox.Show("没有需要保存的类别！");
                return false;
            }
            var item = treeNode.Tag as TypeInfo;
            if (item==null) {
                MessageBox.Show("没有类别信息！");
                return false;
            }
            if (!HasTypeNameValidator(item.TypeName)) {
                return false;
            }
            string errText = "";
            int i;
            if (_isNew) {
                i=_typeInfoService.InsertEntity(out errText, item);
                if (i==0) {
                    MessageBox.Show(errText); 
                    return false;
                }
                return true;
            }
            i = _typeInfoService.UpdateEntity(out errText, item);
            if (i==0) {
                MessageBox.Show(errText);
                return false;
            }
            return true;
        }

        private void txtBoxDiscount_TextChanged(object sender, EventArgs e) {
            var discountTxt = this.txtBoxDiscount.Text;
            if (string.IsNullOrEmpty(discountTxt)) {
                return;
            }
            var priceTxt = this.txtBoxUnitPrice.Text;
            if (string.IsNullOrEmpty(priceTxt)) {
                return;
            }
            var disCount = Convert.ToDecimal(discountTxt);
            var price = Convert.ToDecimal(priceTxt);
            if (disCount<=0||price<=0||disCount>10) {
                return;
            }
            var result = disCount * price * 0.1m;
            this.lblPrice.Text = result.ToString();
        }

        #region 事件
        private void btnAdd_Click(object sender, EventArgs e) {
            if (!InputValidate()) {
                return;
            }
            if (!HasCommodityNoValidator(this.txtBoxCommodityNo.Text, false)) {
                return;
            } 
            string errText;
            var commodityInfo = new CommodityInfo() {
                CommodityId = _currentId, CommodityNo=this.txtBoxCommodityNo.Text, CommodityName = this.txtBoxCommodityName.Text,
                TypeId =_currentTypeId,Size=this.cmboxSize.Text,Color=this.cmboxColor.Text, Remark = this.txtBoxRemark.Text,
                Unit=this.txtBoxUnit.Text
            };
            commodityInfo.Discount = float.Parse(this.txtBoxDiscount.Text);
            commodityInfo.UnitPrice = Convert.ToDecimal(this.txtBoxUnitPrice.Text);

            var i = _commodityInfoService.InsertEntity(out errText, commodityInfo);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("添加成功！");
            ClearPage();
            InitCommodityData();
        }

        private void btnModify_Click(object sender, EventArgs e) {
            if (!InputValidate()) {
                return;
            }
            if (!HasCommodityNoValidator(this.txtBoxCommodityNo.Text, true)) {
                return;
            }
            string errText;
            var commodityInfo = new CommodityInfo() {
                CommodityId = _currentId, CommodityNo = this.txtBoxCommodityNo.Text, CommodityName = this.txtBoxCommodityName.Text,
                TypeId = _currentTypeId, Size = this.cmboxSize.Text, Color = this.cmboxColor.Text, Remark = this.txtBoxRemark.Text,
                Unit = this.txtBoxUnit.Text
            };
            commodityInfo.Discount = float.Parse(this.txtBoxDiscount.Text);
            commodityInfo.UnitPrice = Convert.ToDecimal(this.txtBoxUnitPrice.Text);
            var i = _commodityInfoService.UpdateEntity(out errText, commodityInfo);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("修改成功！");
            ClearPage();
            InitCommodityData();
        }

        private void CommodityManagementCtrl_Load(object sender, EventArgs e) {
            InitTypeData();
            InitCommodityData();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            ClearPage();
            QueryData(this.txtBoxCommodityQuery.Text);
        }

        private void btnAllUser_Click(object sender, EventArgs e) {
            ClearPage();
            InitCommodityData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string errText;
            if (_commodityInfoService == null) {
                _commodityInfoService = new CommodityInfoService();
            }
            var i = _commodityInfoService.DeleteEntity(out errText, _currentId);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            MessageBox.Show("删除成功！");
            ClearPage();
            InitCommodityData();

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) {
                return;
            }
            ClearPage();
            var dt = this.dataGridView1.DataSource as DataTable;
            if (dt != null && dt.Rows.Count != 0) {
                var row = dt.Rows[e.RowIndex];
                _currentId = (Guid)row["CommodityId"];
                this.txtBoxCommodityNo.Text = row["CommodityNo"] == null ? "" : row["CommodityNo"].ToString();
                this.txtBoxCommodityName.Text = row["CommodityName"] == null ? "" : row["CommodityName"].ToString();
                this.cmboxSize.Text = row["Size"] == null ? "" : row["Size"].ToString();
                this.cmboxColor.Text = row["Color"] == null ? "" : row["Color"].ToString();
                this.txtBoxUnitPrice.Text = row["UnitPrice"] == null ? "" : row["UnitPrice"].ToString();
                this.txtBoxDiscount.Text = row["Discount"] == null ? "" : row["Discount"].ToString();
                this.txtBoxRemark.Text = row["Remark"] == null ? "" : row["Remark"].ToString();
                if (string.IsNullOrEmpty(this.txtBoxUnitPrice.Text)) {
                    this.lblPrice.Text = "0";
                } else {
                    if (string.IsNullOrEmpty(txtBoxDiscount.Text)) {
                        this.lblPrice.Text = this.txtBoxUnitPrice.Text;
                    } else {
                        this.lblPrice.Text = (((decimal)row["UnitPrice"]) * ((decimal)row["Discount"])).ToString();
                    }
                }
                return;
            }
            var list = this.dataGridView1.DataSource as List<CommodityInfo>;
            if (list != null && list.Count > 0) {
                var info = list[e.RowIndex];
                _currentId = info.CommodityId;
                this.txtBoxCommodityNo.Text = info.CommodityNo;
                this.txtBoxCommodityName.Text = info.CommodityName;
                this.cmboxSize.Text = info.Size;
                this.cmboxColor.Text = info.Color;
                this.txtBoxUnitPrice.Text = info.UnitPrice.ToString();
                this.txtBoxDiscount.Text = info.Discount.ToString();
                this.txtBoxRemark.Text = info.Remark;
                if (info.Discount==0) {
                    this.lblPrice.Text = "0";
                    return;
                }
                this.lblPrice.Text = (info.UnitPrice * (decimal)info.Discount).ToString();
                return;
            }

        }

        private void tSMenuItemAddParent_Click(object sender, EventArgs e) {
            TreeNode node = new TreeNode();
            node.ContextMenuStrip = this.contextMenuStrip1;  
            this.treeView1.Nodes.Add(node);
            _isNew = true;
            node.BeginEdit();
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
            var node = e.Node;
            if (node==null) {
                return;
            }
            if (string.IsNullOrEmpty(e.Label)) {
                e.CancelEdit = true;
                return;
            } 
            var item = node.Tag as TypeInfo;
            if (item==null) { 
                item = new TypeInfo() {TypeId=Guid.NewGuid()};
                if (node.Parent != null) {
                    var parentItem = node.Parent.Tag as TypeInfo;
                    if (parentItem == null) {
                        MessageBox.Show("没有找到所属类别！");
                        return;
                    }
                    item.ParentId = parentItem.TypeId;
                }
                node.Tag = item;
            }
            item.TypeName = e.Label;
            if (!SaveNode(node)) {
                if (_isNew) {
                    this.treeView1.Nodes.Remove(node);
                    return;
                }
                e.CancelEdit = true;
                return;
            }
            node.Name = e.Label;
            node.Text = e.Label;
        }

        private void tSMenuItemDelete_Click(object sender, EventArgs e) {
            var node = this.treeView1.SelectedNode;
            if (node == null) {
                return;
            }
            var item = node.Tag as TypeInfo;
            if (item == null) {
                MessageBox.Show("没有对应的类别信息！");
                return;
            }
            string errText = "";
            int i;
            i = _typeInfoService.DeleteEntity(out errText, item.TypeId);
            if (i == 0) {
                MessageBox.Show(errText);
                return;
            }
            this.treeView1.Nodes.Remove(node);
        }

        private void tSMenuItemAdd_Click(object sender, EventArgs e) {
            var node = this.treeView1.SelectedNode;
            if (node==null) {
                return;
            }
            TreeNode newNode = new TreeNode();
            node.Nodes.Add(newNode);
            node.Expand();
            _isNew = true;
            newNode.BeginEdit();
        }

        private void tSMenuItemModify_Click(object sender, EventArgs e) {
            var node = this.treeView1.SelectedNode;
            if (node==null) {
                return;
            }
            _isNew = false;
            node.BeginEdit();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e) {
            _currentTypeId = Guid.Empty;
            var node = this.treeView1.SelectedNode;
            if (node==null) {
                return;
            }
            var item = node.Tag as TypeInfo;
            if (item==null) {
                return;
            }
            if (node.Nodes.Count>0) {
                return;
            }
            _currentTypeId = item.TypeId;
            InitCommodityData();
        }
        #endregion 
         
    }
}
