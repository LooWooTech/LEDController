namespace LoowooTech.LEDController.Server
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnMessage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClientButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLEDScreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClientWindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSystemConfig = new System.Windows.Forms.ToolStripButton();
            this.btnLogout = new System.Windows.Forms.ToolStripButton();
            this.container = new System.Windows.Forms.Panel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMessage,
            this.toolStripSeparator3,
            this.btnClientButton,
            this.toolStripSeparator2,
            this.btnLEDScreen,
            this.toolStripSeparator4,
            this.btnClientWindow,
            this.toolStripSeparator1,
            this.btnUser,
            this.toolStripSeparator5,
            this.btnSystemConfig,
            this.toolStripSeparator6,
            this.btnLogout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnMessage
            // 
            this.btnMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnMessage.Image")));
            this.btnMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(69, 24);
            this.btnMessage.Text = "消息管理";
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnClientButton
            // 
            this.btnClientButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClientButton.Image = ((System.Drawing.Image)(resources.GetObject("btnClientButton.Image")));
            this.btnClientButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClientButton.Name = "btnClientButton";
            this.btnClientButton.Size = new System.Drawing.Size(69, 24);
            this.btnClientButton.Text = "按钮配置";
            this.btnClientButton.Click += new System.EventHandler(this.btnClientButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnLEDScreen
            // 
            this.btnLEDScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLEDScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnLEDScreen.Image")));
            this.btnLEDScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLEDScreen.Name = "btnLEDScreen";
            this.btnLEDScreen.Size = new System.Drawing.Size(69, 24);
            this.btnLEDScreen.Text = "屏幕配置";
            this.btnLEDScreen.Click += new System.EventHandler(this.btnLEDScreen_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btnClientWindow
            // 
            this.btnClientWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClientWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnClientWindow.Image")));
            this.btnClientWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClientWindow.Name = "btnClientWindow";
            this.btnClientWindow.Size = new System.Drawing.Size(69, 24);
            this.btnClientWindow.Text = "窗口配置";
            this.btnClientWindow.Click += new System.EventHandler(this.btnClientWindow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnUser
            // 
            this.btnUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(69, 24);
            this.btnUser.Text = "用户管理";
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // btnSystemConfig
            // 
            this.btnSystemConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSystemConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnSystemConfig.Image")));
            this.btnSystemConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Size = new System.Drawing.Size(69, 24);
            this.btnSystemConfig.Text = "系统配置";
            this.btnSystemConfig.Click += new System.EventHandler(this.btnSystemConfig_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(41, 24);
            this.btnLogout.Text = "退出";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 27);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(584, 334);
            this.container.TabIndex = 1;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.container);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "LED主控";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnMessage;
        private System.Windows.Forms.ToolStripButton btnClientButton;
        private System.Windows.Forms.ToolStripButton btnLEDScreen;
        private System.Windows.Forms.ToolStripButton btnClientWindow;
        private System.Windows.Forms.ToolStripButton btnUser;
        private System.Windows.Forms.ToolStripButton btnSystemConfig;
        private System.Windows.Forms.Panel container;
        private UserControls.MessageContainerControl messageControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}

