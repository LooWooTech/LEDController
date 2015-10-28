using LoowooTech.LEDController.Server.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

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
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
             AddContainer<MessageContainerControl>();
       }

        private delegate void Action();

        private void AddContainer<T>() where T : UserControl, LoowooTech.LEDController.Server.UserControls.IContainerControl, new()
        {
            new Thread(() =>
            {
                container.Invoke(new Action(()=>
                {
                    if (container.Controls.Count == 1)
                    {
                        var currentControl = (UserControls.IContainerControl)container.Controls[0];
                        if (currentControl is T)
                        {
                            return;
                        }
                        else
                        {
                            currentControl.SaveData();
                            container.Controls.RemoveAt(0);
                        }
                    }
                    var control = new T();
                    container.Controls.Add(control);
                    control.Dock = DockStyle.Fill;
                    control.BindData();
                }));
            }).Start();
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            AddContainer<MessageContainerControl>();
        }

        private void btnClientButton_Click(object sender, EventArgs e)
        {
            AddContainer<ButtonContainerControl>();
        }

        private void btnLEDScreen_Click(object sender, EventArgs e)
        {
            AddContainer<ScreenContainerControl>();
        }

        private void btnClientWindow_Click(object sender, EventArgs e)
        {
            AddContainer<WindowContainerControl>();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AddContainer<AdminContainerControl>();
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            AddContainer<ConfigContainerControl>();
        }

        private void btnOffworkTime_Click(object sender, EventArgs e)
        {
            AddContainer<OffworkTimeContainerControl>();
        }

        //private void btnHistory_Click(object sender, EventArgs e)
        //{
        //    AddContainer<HistoryContainerControl>();
        //}

        private void Logout()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is LoginForm)
                {
                    ((LoginForm)form).Logout();
                    form.Show();
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Logout();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
