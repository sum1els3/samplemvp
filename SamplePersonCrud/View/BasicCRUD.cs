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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplePersonCrud.View
{
    public partial class BasicCRUD : Form, IPerson, IUser
    {
        public BasicCRUD()
        {
            InitializeComponent();
            mainPresenter = new BasicCRUDPresenter(this, this, new PersonList(), new UserList());
        }

        private BasicCRUDPresenter mainPresenter { get; set; }

        public int PersonID
        {
            get => string.IsNullOrEmpty(textBox2.Text) ? 0 : int.Parse(textBox2.Text);
            set => textBox2.Text = value.ToString();
        }
        public string LastName
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public string FirstName
        {
            get => textBox3.Text;
            set => textBox3.Text = value;
        }
        public string MiddleName
        {
            get => textBox4.Text;
            set => textBox4.Text = value;
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            mainPresenter.CreatePerson();
            RefreshDataGrids();
            MessageBox.Show("Inserted");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void RefreshDataGrids()
        {
            RefreshDataGridPerson();
            RefreshDataGridUser();
        }

        private void RefreshDataGridPerson()
        {
            List<Person> people = mainPresenter.GetPeople();
            dataGridView1.Rows.Clear();
            foreach (Person person in people)
            {
                dataGridView1.Rows.Add(person.PersonID, person.FullName);
            }
        }

        private void RefreshDataGridUser()
        {
            List<User> users = mainPresenter.GetUsers();
            dataGridView2.Rows.Clear();
            foreach (User user in users)
            {
                dataGridView2.Rows.Add(user.UserID, user.Username, user.Password);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            RefreshDataGrids();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Person person = mainPresenter.GetPersonByID(int.Parse(dataGridView1.CurrentRow.Cells["id"].EditedFormattedValue.ToString()));
            PersonID = person.PersonID;
            LastName = person.LastName;
            FirstName = person.FirstName;
            MiddleName = person.MiddleName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainPresenter.UpdatePerson();
            RefreshDataGrids();
            MessageBox.Show("Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainPresenter.DeletePerson();
            RefreshDataGrids();
            MessageBox.Show("Deleted");
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            User user = mainPresenter.GetUserByID(int.Parse(dataGridView2.CurrentRow.Cells["usersID"].EditedFormattedValue.ToString()));
            UserID = user.UserID;
            Username = user.Username;
            Password = user.Password;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainPresenter.CreateUser();
            RefreshDataGrids();
            MessageBox.Show("Inserted");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainPresenter.UpdateUser();
            RefreshDataGrids();
            MessageBox.Show("Updated");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mainPresenter.DeleteUser();
            RefreshDataGrids();
            MessageBox.Show("Deleted");
        }
    }
}
