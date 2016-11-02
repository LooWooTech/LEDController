using LoowooTech.LEDController.Model;
using LoowooTech.LEDController.Data;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private static Admin CurrentUser;
        private delegate void Action();

        public static Admin GetCurrentUser()
        {
            return CurrentUser;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        private DataManager DataManager = DataManager.Instance;

        private void btnLogin_Click(object sender, EventArgs ea)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                txtPassword.Focus();
                return;
            }
            new Thread(() =>
            {
                btnLogin.Invoke(new Action(() =>
                {
                    var currentUser = Login(username, password);
                    if (currentUser != null)
                    {
                        CurrentUser = currentUser;
                        this.Hide();
                        var mainForm = new MainForm();
                        mainForm.Show();
                        txtUsername.Text = null;
                        txtPassword.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("找不到该账号，请检查用户名或密码");
                    }
                }));

            }).Start();
        }

        private Admin Login(string username, string password)
        {

            var admins = DataManager.GetList<Admin>();
            if (admins.Count == 0)
            {
                return new Admin { Username = "temp", Password = "temp", Role = Role.系统管理员 };
            }

            foreach (var e in admins)
            {
                if (e.Username.ToLower() == username.ToLower() && e.Password == password)
                {
                    return e;
                }
            }
            return null;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                e.Cancel = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(Environment.ExitCode);
            Dispose();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                return;
            }
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
