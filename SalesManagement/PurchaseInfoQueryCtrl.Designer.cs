namespace SalesManagement.UI {
    partial class PurchaseInfoQueryCtrl {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxPurchaseNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPickerStart = new System.Windows.Forms.DateTimePicker();
            this.dtPickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnQueryAll = new System.Windows.Forms.Button();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "采购单号：";
            // 
            // txtboxPurchaseNo
            // 
            this.txtboxPurchaseNo.Location = new System.Drawing.Point(130, 70);
            this.txtboxPurchaseNo.Name = "txtboxPurchaseNo";
            this.txtboxPurchaseNo.Size = new System.Drawing.Size(200, 27);
            this.txtboxPurchaseNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "进货时间：";
            // 
            // dtPickerStart
            // 
            this.dtPickerStart.Location = new System.Drawing.Point(130, 117);
            this.dtPickerStart.Name = "dtPickerStart";
            this.dtPickerStart.Size = new System.Drawing.Size(200, 27);
            this.dtPickerStart.TabIndex = 5;
            // 
            // dtPickerEnd
            // 
            this.dtPickerEnd.Location = new System.Drawing.Point(398, 117);
            this.dtPickerEnd.Name = "dtPickerEnd";
            this.dtPickerEnd.Size = new System.Drawing.Size(200, 27);
            this.dtPickerEnd.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "~";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(683, 110);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 40);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
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
            this.Column11,
            this.Column5,
            this.Column3,
            this.Column8,
            this.Column7,
            this.Column10,
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column9,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(38, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(838, 461);
            this.dataGridView1.TabIndex = 9;
            // 
            // btnQueryAll
            // 
            this.btnQueryAll.Location = new System.Drawing.Point(774, 110);
            this.btnQueryAll.Name = "btnQueryAll";
            this.btnQueryAll.Size = new System.Drawing.Size(83, 40);
            this.btnQueryAll.TabIndex = 10;
            this.btnQueryAll.Text = "查看全部";
            this.btnQueryAll.UseVisualStyleBackColor = true;
            this.btnQueryAll.Click += new System.EventHandler(this.btnQueryAll_Click);
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "PurchaseDocNo";
            this.Column11.HeaderText = "采购单号";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SupplierId";
            this.Column5.HeaderText = "SupplierId";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SupplierName";
            this.Column3.HeaderText = "供应商";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Price";
            this.Column8.HeaderText = "金额";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 90;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "WarehouseId";
            this.Column7.HeaderText = "WarehouseId";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "WarehouseName";
            this.Column10.HeaderText = "仓库";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PurchaseTime";
            this.Column1.HeaderText = "采购时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "OperatorId";
            this.Column6.HeaderText = "OperatorId";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UserName";
            this.Column2.HeaderText = "操作员";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.DataPropertyName = "Remark";
            this.Column9.HeaderText = "备注";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "PurchaseDocId";
            this.Column4.HeaderText = "PurchaseDocId";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // PurchaseInfoQueryCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(119F, 119F);
            this.Controls.Add(this.btnQueryAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtPickerEnd);
            this.Controls.Add(this.dtPickerStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxPurchaseNo);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseInfoQueryCtrl";
            this.TitleText = "进货信息查询";
            this.Load += new System.EventHandler(this.PurchaseInfoQueryCtrl_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtboxPurchaseNo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtPickerStart, 0);
            this.Controls.SetChildIndex(this.dtPickerEnd, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnQuery, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnQueryAll, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxPurchaseNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPickerStart;
        private System.Windows.Forms.DateTimePicker dtPickerEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnQueryAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
