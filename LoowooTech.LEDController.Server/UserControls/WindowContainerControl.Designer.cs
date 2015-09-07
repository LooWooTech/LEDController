namespace LoowooTech.LEDController.Server.UserControls
{
    partial class WindowContainerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateWindow = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEDID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginTop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontFamily = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FontSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextAlignment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TextAnimation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator1,
            this.btnSave,
            this.toolStripSeparator2,
            this.btnDelete,
            this.toolStripSeparator3,
            this.btnCreateWindow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(580, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::LoowooTech.LEDController.Server.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 28);
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::LoowooTech.LEDController.Server.Properties.Resources.save;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 28);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::LoowooTech.LEDController.Server.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 28);
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // btnCreateWindow
            // 
            this.btnCreateWindow.Image = global::LoowooTech.LEDController.Server.Properties.Resources.create_screen;
            this.btnCreateWindow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCreateWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateWindow.Name = "btnCreateWindow";
            this.btnCreateWindow.Size = new System.Drawing.Size(84, 28);
            this.btnCreateWindow.Text = "创建窗口";
            this.btnCreateWindow.ToolTipText = "如果窗口已经创建，则会全部重新创建";
            this.btnCreateWindow.Click += new System.EventHandler(this.btnCreateWindow_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 289);
            this.panel2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.LEDID,
            this.Width,
            this.Height,
            this.MarginLeft,
            this.MarginTop,
            this.FontFamily,
            this.FontSize,
            this.TextAlignment,
            this.TextAnimation});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(580, 289);
            this.dataGridView1.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.HeaderText = "窗口编号";
            this.ID.Name = "ID";
            this.ID.Width = 90;
            // 
            // LEDID
            // 
            this.LEDID.HeaderText = "屏幕编号";
            this.LEDID.Name = "LEDID";
            this.LEDID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LEDID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LEDID.Width = 90;
            // 
            // Width
            // 
            this.Width.HeaderText = "宽度";
            this.Width.Name = "Width";
            this.Width.Width = 70;
            // 
            // Height
            // 
            this.Height.HeaderText = "高度";
            this.Height.Name = "Height";
            this.Height.Width = 70;
            // 
            // MarginLeft
            // 
            this.MarginLeft.HeaderText = "左边距";
            this.MarginLeft.Name = "MarginLeft";
            this.MarginLeft.Width = 80;
            // 
            // MarginTop
            // 
            this.MarginTop.HeaderText = "上边距";
            this.MarginTop.Name = "MarginTop";
            this.MarginTop.Width = 80;
            // 
            // FontFamily
            // 
            this.FontFamily.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.FontFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FontFamily.HeaderText = "字体";
            this.FontFamily.Items.AddRange(new object[] {
            "宋体",
            "楷体"});
            this.FontFamily.Name = "FontFamily";
            this.FontFamily.Width = 80;
            // 
            // FontSize
            // 
            this.FontSize.HeaderText = "字体大小";
            this.FontSize.Name = "FontSize";
            this.FontSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FontSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FontSize.Width = 90;
            // 
            // TextAlignment
            // 
            this.TextAlignment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextAlignment.HeaderText = "文字对齐";
            this.TextAlignment.Name = "TextAlignment";
            this.TextAlignment.Width = 90;
            // 
            // TextAnimation
            // 
            dataGridViewCellStyle1.NullValue = "1";
            this.TextAnimation.DefaultCellStyle = dataGridViewCellStyle1;
            this.TextAnimation.HeaderText = "动画效果";
            this.TextAnimation.Name = "TextAnimation";
            this.TextAnimation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TextAnimation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TextAnimation.Width = 90;
            // 
            // WindowContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WindowContainerControl";
            this.Size = new System.Drawing.Size(580, 320);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCreateWindow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEDID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginTop;
        private System.Windows.Forms.DataGridViewComboBoxColumn FontFamily;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontSize;
        private System.Windows.Forms.DataGridViewComboBoxColumn TextAlignment;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextAnimation;
    }
}
