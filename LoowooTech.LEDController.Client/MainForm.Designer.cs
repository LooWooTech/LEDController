namespace LoowooTech.LEDController.Client
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labMessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.cbxMessage = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnOffwork = new System.Windows.Forms.Button();
            this.cbxOffworkTime = new System.Windows.Forms.ComboBox();
            this.buttonContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCountDown = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.buttonContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.labTitle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(393, 50);
            this.panel3.TabIndex = 6;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.ForeColor = System.Drawing.Color.White;
            this.labTitle.Location = new System.Drawing.Point(13, 9);
            this.labTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(177, 31);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "LED屏信息发布";
            this.labTitle.DoubleClick += new System.EventHandler(this.labTitle_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 130);
            this.panel1.TabIndex = 7;
            // 
            // labMessage
            // 
            this.labMessage.BackColor = System.Drawing.Color.Black;
            this.labMessage.Font = new System.Drawing.Font("KaiTi", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(42, 14);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(287, 100);
            this.labMessage.TabIndex = 0;
            this.labMessage.Text = "测试文字测试文字测试文字测试文字";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnSendMessage);
            this.panel2.Controls.Add(this.cbxMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 180);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 40);
            this.panel2.TabIndex = 8;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.Green;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.ForeColor = System.Drawing.Color.White;
            this.btnSendMessage.Location = new System.Drawing.Point(290, 3);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(90, 32);
            this.btnSendMessage.TabIndex = 1;
            this.btnSendMessage.Text = "发送信息";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // cbxMessage
            // 
            this.cbxMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMessage.FormattingEnabled = true;
            this.cbxMessage.Location = new System.Drawing.Point(13, 6);
            this.cbxMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxMessage.Name = "cbxMessage";
            this.cbxMessage.Size = new System.Drawing.Size(269, 28);
            this.cbxMessage.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.btnOffwork);
            this.panel4.Controls.Add(this.cbxOffworkTime);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 220);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(13, 17, 13, 17);
            this.panel4.Size = new System.Drawing.Size(393, 40);
            this.panel4.TabIndex = 9;
            // 
            // btnOffwork
            // 
            this.btnOffwork.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOffwork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffwork.ForeColor = System.Drawing.Color.White;
            this.btnOffwork.Location = new System.Drawing.Point(290, 2);
            this.btnOffwork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOffwork.Name = "btnOffwork";
            this.btnOffwork.Size = new System.Drawing.Size(90, 32);
            this.btnOffwork.TabIndex = 2;
            this.btnOffwork.Text = "下班时间";
            this.btnOffwork.UseVisualStyleBackColor = false;
            this.btnOffwork.Click += new System.EventHandler(this.btnOffwork_Click);
            // 
            // cbxOffworkTime
            // 
            this.cbxOffworkTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOffworkTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxOffworkTime.FormattingEnabled = true;
            this.cbxOffworkTime.Location = new System.Drawing.Point(13, 5);
            this.cbxOffworkTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxOffworkTime.Name = "cbxOffworkTime";
            this.cbxOffworkTime.Size = new System.Drawing.Size(269, 28);
            this.cbxOffworkTime.TabIndex = 2;
            // 
            // buttonContainer
            // 
            this.buttonContainer.Controls.Add(this.btnCountDown);
            this.buttonContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonContainer.Location = new System.Drawing.Point(0, 260);
            this.buttonContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonContainer.Name = "buttonContainer";
            this.buttonContainer.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.buttonContainer.Size = new System.Drawing.Size(393, 137);
            this.buttonContainer.TabIndex = 12;
            // 
            // btnCountDown
            // 
            this.btnCountDown.BackColor = System.Drawing.Color.Brown;
            this.btnCountDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCountDown.ForeColor = System.Drawing.Color.White;
            this.btnCountDown.Location = new System.Drawing.Point(13, 5);
            this.btnCountDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCountDown.Name = "btnCountDown";
            this.btnCountDown.Size = new System.Drawing.Size(85, 32);
            this.btnCountDown.TabIndex = 0;
            this.btnCountDown.Text = "倒计时";
            this.btnCountDown.UseVisualStyleBackColor = false;
            this.btnCountDown.Click += new System.EventHandler(this.btnCountDown_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(0, 372);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(393, 25);
            this.panel5.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(393, 397);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.buttonContainer);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "LED屏信息发布";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.buttonContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.ComboBox cbxMessage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnOffwork;
        private System.Windows.Forms.ComboBox cbxOffworkTime;
        private System.Windows.Forms.FlowLayoutPanel buttonContainer;
        private System.Windows.Forms.Button btnCountDown;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Panel panel5;
    }
}

