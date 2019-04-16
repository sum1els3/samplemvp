using SamplePersonCrud.Model.Objects.Person;
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
    public partial class Main : Form, IPerson
    {
        public Main()
        {
            InitializeComponent();
            mainPresenter = new MainPresenter(this, new PersonList());
        }

        private MainPresenter mainPresenter { get; set; }

        public string ID
        {
            get => textBox2.Text;
            set => textBox2.Text = value;
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

        private void button1_Click(object sender, EventArgs e)
        {
            mainPresenter.Insert();
            RefreshDataGrid();
            MessageBox.Show("Inserted");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void RefreshDataGrid()
        {
            List<Person> people = mainPresenter.GetPeople();
            dataGridView1.Rows.Clear();
            foreach (Person person in people)
            {
                dataGridView1.Rows.Add(person.ID, person.FullName);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Person person = mainPresenter.GetPersonByID(int.Parse(dataGridView1.CurrentRow.Cells["id"].EditedFormattedValue.ToString()));
            ID = person.ID.ToString();
            LastName = person.LastName;
            FirstName = person.FirstName;
            MiddleName = person.MiddleName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainPresenter.Update();
            RefreshDataGrid();
            MessageBox.Show("Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainPresenter.Delete();
            RefreshDataGrid();
            MessageBox.Show("Deleted");
        }
    }
}
