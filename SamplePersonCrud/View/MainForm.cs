using SamplePersonCrud.Model.Objects;
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
    public partial class MainForm : Form
    {
        private List<Person> people;

        public MainForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            people = new List<Person>();
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person person = new Person()
            {
                LastName = textBox1.Text,
                FirstName = textBox3.Text,
                MiddleName = textBox4.Text
            };
            try
            {
                person.Create();
                MessageBox.Show("Inserted");
                Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person person = people.Find(item => item.ID == int.Parse(textBox2.Text));
            person.LastName = textBox1.Text;
            person.FirstName = textBox3.Text;
            person.MiddleName = textBox4.Text;
            person.Update();
            MessageBox.Show("Updated");
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Person person = people.Find(item => item.ID == int.Parse(textBox2.Text));
            person.Delete();
            MessageBox.Show("Deleted");
            Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            Person person = people.Find(item => item.ID == int.Parse(row.Cells["ID"].EditedFormattedValue.ToString()));
            textBox2.Text = person.ID.ToString();
            textBox1.Text = person.LastName;
            textBox3.Text = person.FirstName;
            textBox4.Text = person.MiddleName;
        }

        private void Refresh()
        {
            MainFormController.ShowPersonListIntoDataGridView(dataGridView1, ref people);
        }
    }
}
