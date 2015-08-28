﻿using LoowooTech.LEDController.Model;
using LoowooTech.LEDController.Server.Managers;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private static Admin CurrentUser;

        public Admin GetCurrentUser()
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
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码填写正常");
                    }
                }));

            }).Start();
        }

        private Admin Login(string username, string password)
        {

            var admins = DataManager.GetList<Admin>();
            return admins.FirstOrDefault(e => e.Username.ToLower() == username.ToLower() && e.Password == password);
        }
    }
}
