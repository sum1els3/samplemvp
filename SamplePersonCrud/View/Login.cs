﻿using SamplePersonCrud.Model.Objects.User;
using SamplePersonCrud.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplePersonCrud.View
{
    public partial class Login : Form, IUser
    {
        public int UserID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Username
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public string Password
        {
            get => textBox2.Text;
            set => textBox2.Text = value;
        }

        LoginPresenter loginPresenter;

        public Login()
        {
            InitializeComponent();
            loginPresenter = new LoginPresenter(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread thread = new Thread(OpenBasicCrude);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public void OpenBasicCrude()
        {
            Application.Run(new BasicCRUD());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IUser user = loginPresenter.Login();
                MessageBox.Show(DisplayDetails(user));
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Invalid username or password.");
            }
            
        }

        private string DisplayDetails(IUser user)
        {
            return string.Format("Username: {0} \n" +
                "Password: {1}", user.Username, user.Password);
        }
    }
}
