using SamplePersonCrud.Model.Objects.Person;
using SamplePersonCrud.Model.Objects.User;
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
    public partial class ShowUser : Form, IUser
    {
        public ShowUser(IUser user)
        {
            InitializeComponent();

            _showUserPresenter = new ShowUserPresenter(this);
            UserID = user.UserID;
            Username = user.Username;
            Password = user.Password;
            Person = user.Person;
        }

        ShowUserPresenter _showUserPresenter;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username
        {
            get => textBox6.Text;
            set => textBox6.Text = value;
        }
        public string Password
        {
            get => textBox7.Text;
            set => textBox7.Text = value;
        }
        public IPerson Person
        {
            get => new Person()
            {
                PersonID = PersonID,
                LastName = textBox1.Text,
                FirstName = textBox3.Text,
                MiddleName = textBox4.Text
            };
            set
            {
                PersonID = value.PersonID;
                textBox1.Text = value.LastName;
                textBox3.Text = value.FirstName;
                textBox4.Text = value.MiddleName;
            }
        }

        private void ShowUser_Load(object sender, EventArgs e) { }

        private void button5_Click(object sender, EventArgs e)
        {
            _showUserPresenter.Update();
            MessageBox.Show("Updated");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread thread = new Thread(OpenLogin);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void OpenLogin()
        {
            Application.Run(new Login());
        }
    }
}
