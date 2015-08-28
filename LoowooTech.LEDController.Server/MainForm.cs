using LoowooTech.LEDController.Server.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LoowooTech.LEDController.Server
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AddContainer(MessageContainerControl);
        }

        private MessageContainerControl MessageContainerControl = new MessageContainerControl();
        private ButtonContainerControl ButtonContainerControl = new ButtonContainerControl();
        private WindowContainerControl WindowContainerControl = new WindowContainerControl();
        private ScreenContainerControl ScreenContainerControl = new ScreenContainerControl();
        private AdminContainerControl AdminContainerControl = new AdminContainerControl();
        private ConfigContainerControl ConfigContainerControl = new ConfigContainerControl();

        private void AddContainer(LoowooTech.LEDController.Server.UserControls.IContainerControl control)
        {
            new Thread(() =>
            {
                container.Invoke(new Action(() =>
                {
                    if (container.Controls.Count == 1)
                    {
                        var currentControl = (UserControls.IContainerControl)container.Controls[0];
                        currentControl.SaveData();
                        container.Controls.RemoveAt(0);
                    }
                    container.Controls.Add((UserControl)control);
                    ((UserControl)control).Dock = DockStyle.Fill;
                    control.BindData();
                }));
            }).Start();
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            AddContainer(MessageContainerControl);
        }

        private void btnClientButton_Click(object sender, EventArgs e)
        {
            AddContainer(ButtonContainerControl);
        }

        private void btnLEDScreen_Click(object sender, EventArgs e)
        {
            AddContainer(ScreenContainerControl);
        }

        private void btnClientWindow_Click(object sender, EventArgs e)
        {
            AddContainer(WindowContainerControl);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AddContainer(AdminContainerControl);
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            AddContainer(ConfigContainerControl);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }
    }
}
