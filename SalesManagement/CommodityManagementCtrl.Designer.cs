namespace SalesManagement.UI {
    partial class CommodityManagementCtrl {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuItemAddParent = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBoxCommodityNo = new System.Windows.Forms.TextBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.txtBoxRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxCommodityName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmboxColor = new System.Windows.Forms.ComboBox();
            this.cmboxSize = new System.Windows.Forms.ComboBox();
            this.txtBoxDiscount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxUnitPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxCommodityQuery = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxUnit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuItemAdd,
            this.tSMenuItemDelete,
            this.tSMenuItemModify,
            this.tSMenuItemAddParent});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 100);
            // 
            // tSMenuItemAdd
            // 
            this.tSMenuItemAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSMenuItemAdd.DoubleClickEnabled = true;
            this.tSMenuItemAdd.Name = "tSMenuItemAdd";
            this.tSMenuItemAdd.Size = new System.Drawing.Size(153, 24);
            this.tSMenuItemAdd.Text = "添加子类别";
            this.tSMenuItemAdd.Click += new System.EventHandler(this.tSMenuItemAdd_Click);
            // 
            // tSMenuItemDelete
            // 
            this.tSMenuItemDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSMenuItemDelete.DoubleClickEnabled = true;
            this.tSMenuItemDelete.Name = "tSMenuItemDelete";
            this.tSMenuItemDelete.Size = new System.Drawing.Size(153, 24);
            this.tSMenuItemDelete.Text = "删除类别";
            this.tSMenuItemDelete.Click += new System.EventHandler(this.tSMenuItemDelete_Click);
            // 
            // tSMenuItemModify
            // 
            this.tSMenuItemModify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSMenuItemModify.DoubleClickEnabled = true;
            this.tSMenuItemModify.Name = "tSMenuItemModify";
            this.tSMenuItemModify.Size = new System.Drawing.Size(153, 24);
            this.tSMenuItemModify.Text = "重命名";
            this.tSMenuItemModify.Click += new System.EventHandler(this.tSMenuItemModify_Click);
            // 
            // tSMenuItemAddParent
            // 
            this.tSMenuItemAddParent.Name = "tSMenuItemAddParent";
            this.tSMenuItemAddParent.Size = new System.Drawing.Size(153, 24);
            this.tSMenuItemAddParent.Text = "添加根分类";
            this.tSMenuItemAddParent.Click += new System.EventHandler(this.tSMenuItemAddParent_Click);
            // 
            // txtBoxCommodityNo
            // 
            this.txtBoxCommodityNo.Location = new System.Drawing.Point(374, 361);
            this.txtBoxCommodityNo.Name = "txtBoxCommodityNo";
            this.txtBoxCommodityNo.Size = new System.Drawing.Size(200, 27);
            this.txtBoxCommodityNo.TabIndex = 112;
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModify.Location = new System.Drawing.Point(691, 616);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(92, 26);
            this.btnModify.TabIndex = 110;
            this.btnModify.Text = "修改商品";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // txtBoxRemark
            // 
            this.txtBoxRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxRemark.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxRemark.Location = new System.Drawing.Point(374, 533);
            this.txtBoxRemark.Multiline = true;
            this.txtBoxRemark.Name = "txtBoxRemark";
            this.txtBoxRemark.Size = new System.Drawing.Size(525, 71);
            this.txtBoxRemark.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(289, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 103;
            this.label2.Text = "商品编号：";
            // 
            // txtBoxCommodityName
            // 
            this.txtBoxCommodityName.Location = new System.Drawing.Point(695, 361);
            this.txtBoxCommodityName.Name = "txtBoxCommodityName";
            this.txtBoxCommodityName.Size = new System.Drawing.Size(200, 27);
            this.txtBoxCommodityName.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(593, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 114;
            this.label1.Text = "商品名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(304, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 116;
            this.label3.Text = "尺码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(623, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 118;
            this.label4.Text = "颜色：";
            // 
            // cmboxColor
            // 
            this.cmboxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxColor.FormattingEnabled = true;
            this.cmboxColor.Location = new System.Drawing.Point(695, 404);
            this.cmboxColor.Name = "cmboxColor";
            this.cmboxColor.Size = new System.Drawing.Size(200, 28);
            this.cmboxColor.TabIndex = 120;
            // 
            // cmboxSize
            // 
            this.cmboxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxSize.FormattingEnabled = true;
            this.cmboxSize.Location = new System.Drawing.Point(374, 404);
            this.cmboxSize.Name = "cmboxSize";
            this.cmboxSize.Size = new System.Drawing.Size(200, 28);
            this.cmboxSize.TabIndex = 121;
            // 
            // txtBoxDiscount
            // 
            this.txtBoxDiscount.Location = new System.Drawing.Point(677, 449);
            this.txtBoxDiscount.Name = "txtBoxDiscount";
            this.txtBoxDiscount.Size = new System.Drawing.Size(58, 27);
            this.txtBoxDiscount.TabIndex = 123;
            this.txtBoxDiscount.TextChanged += new System.EventHandler(this.txtBoxDiscount_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(593, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 122;
            this.label7.Text = "会员折扣：";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(803, 616);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 26);
            this.btnDelete.TabIndex = 111;
            this.btnDelete.Text = "删除商品";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(304, 534);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 124;
            this.label5.Text = "备注：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(304, 452);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 125;
            this.label6.Text = "单价：";
            // 
            // txtBoxUnitPrice
            // 
            this.txtBoxUnitPrice.Location = new System.Drawing.Point(374, 449);
            this.txtBoxUnitPrice.Name = "txtBoxUnitPrice";
            this.txtBoxUnitPrice.Size = new System.Drawing.Size(200, 27);
            this.txtBoxUnitPrice.TabIndex = 126;
            this.txtBoxUnitPrice.TextChanged += new System.EventHandler(this.txtBoxDiscount_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(753, 452);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 127;
            this.label8.Text = "折后价：";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrice.Location = new System.Drawing.Point(816, 452);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(18, 20);
            this.lblPrice.TabIndex = 128;
            this.lblPrice.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(871, 452);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 20);
            this.label10.TabIndex = 129;
            this.label10.Text = "元";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(23, 78);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(240, 564);
            this.treeView1.TabIndex = 130;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(584, 616);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 26);
            this.btnAdd.TabIndex = 132;
            this.btnAdd.Text = "添加商品";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column10,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column11,
            this.Column9});
            this.dataGridView1.Location = new System.Drawing.Point(279, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(611, 225);
            this.dataGridView1.TabIndex = 133;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CommodityId";
            this.Column1.HeaderText = "CommodityId";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CommodityNo";
            this.Column2.HeaderText = "商品编号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CommodityName";
            this.Column3.HeaderText = "商品名称";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TypeName";
            this.Column4.HeaderText = "商品类型";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "TypeId";
            this.Column10.HeaderText = "TypeId";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Size";
            this.Column5.HeaderText = "尺码";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Color";
            this.Column6.HeaderText = "颜色";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "UnitPrice";
            this.Column7.HeaderText = "单价";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Discount";
            this.Column8.HeaderText = "折扣";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Unit";
            this.Column11.HeaderText = "单位";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Remark";
            this.Column9.HeaderText = "备注";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 5;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(579, 86);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(92, 26);
            this.btnQuery.TabIndex = 135;
            this.btnQuery.Text = "查询商品";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnAll
            // 
            this.btnAll.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAll.Location = new System.Drawing.Point(676, 86);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(92, 26);
            this.btnAll.TabIndex = 134;
            this.btnAll.Text = "查看所有";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAllUser_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(289, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 20);
            this.label9.TabIndex = 136;
            this.label9.Text = "商品编号：";
            // 
            // txtBoxCommodityQuery
            // 
            this.txtBoxCommodityQuery.Location = new System.Drawing.Point(374, 86);
            this.txtBoxCommodityQuery.Name = "txtBoxCommodityQuery";
            this.txtBoxCommodityQuery.Size = new System.Drawing.Size(200, 27);
            this.txtBoxCommodityQuery.TabIndex = 137;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(304, 493);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 139;
            this.label11.Text = "单位：";
            // 
            // txtBoxUnit
            // 
            this.txtBoxUnit.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxUnit.Location = new System.Drawing.Point(374, 492);
            this.txtBoxUnit.Name = "txtBoxUnit";
            this.txtBoxUnit.Size = new System.Drawing.Size(264, 27);
            this.txtBoxUnit.TabIndex = 138;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(654, 495);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 20);
            this.label12.TabIndex = 140;
            this.label12.Text = "(输入单位请用“,”隔开)";
            // 
            // CommodityManagementCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(119F, 119F);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBoxUnit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBoxCommodityQuery);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxUnitPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmboxSize);
            this.Controls.Add(this.txtBoxDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBoxCommodityNo);
            this.Controls.Add(this.txtBoxRemark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxCommodityName);
            this.Controls.Add(this.cmboxColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label4);
            this.Name = "CommodityManagementCtrl";
            this.TitleText = "商品管理";
            this.Load += new System.EventHandler(this.CommodityManagementCtrl_Load);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnModify, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmboxColor, 0);
            this.Controls.SetChildIndex(this.txtBoxCommodityName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBoxRemark, 0);
            this.Controls.SetChildIndex(this.txtBoxCommodityNo, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtBoxDiscount, 0);
            this.Controls.SetChildIndex(this.cmboxSize, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtBoxUnitPrice, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblPrice, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.treeView1, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnAll, 0);
            this.Controls.SetChildIndex(this.btnQuery, 0);
            this.Controls.SetChildIndex(this.txtBoxCommodityQuery, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtBoxUnit, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxCommodityNo;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox txtBoxRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxCommodityName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmboxColor;
        private System.Windows.Forms.ComboBox cmboxSize;
        private System.Windows.Forms.TextBox txtBoxDiscount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxUnitPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxCommodityQuery;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItemAddParent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoxUnit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}
