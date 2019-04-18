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
    public partial class BasicCRUD : Form, IUser
    {
        public BasicCRUD()
        {
            InitializeComponent();
            mainPresenter = new BasicCRUDPresenter(this);
        }

        private BasicCRUDPresenter mainPresenter { get; set; }

        public int UserID
        {
            get => string.IsNullOrEmpty(textBox8.Text) ? 0 : int.Parse(textBox8.Text);
            set => textBox8.Text = value.ToString();
        }
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
            get => new PersonContext()
            {
                PersonID = string.IsNullOrEmpty(textBox2.Text) ? 0 : int.Parse(textBox2.Text),
                LastName = textBox1.Text,
                FirstName = textBox3.Text,
                MiddleName = textBox4.Text
            };
            set
            {
                textBox2.Text = value.PersonID.ToString();
                textBox1.Text = value.LastName;
                textBox3.Text = value.FirstName;
                textBox4.Text = value.MiddleName;
            }
        }

        private void button1_Click(object sender, EventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        private void RefreshDataGridUser()
        {
            List<IUser> users = mainPresenter.GetUsers();
            dataGridView2.Rows.Clear();
            foreach (IUser user in users)
            {
                dataGridView2.Rows.Add(user.UserID, user.Username, user.Password, user.Person.PersonID, user.Person.FullName);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            RefreshDataGridUser();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e) { }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            IUser user = mainPresenter.GetUserByID(int.Parse(dataGridView2.CurrentRow.Cells["usersID"].EditedFormattedValue.ToString()));
            UserID = user.UserID;
            Username = user.Username;
            Password = user.Password;
            Person = user.Person;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainPresenter.CreateUser();
            RefreshDataGridUser();
            MessageBox.Show("Inserted");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainPresenter.UpdateUser();
            RefreshDataGridUser();
            MessageBox.Show("Updated");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mainPresenter.DeleteUser();
            RefreshDataGridUser();
            MessageBox.Show("Deleted");
        }

        private void button7_Click(object sender, EventArgs e)
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
