using SamplePersonCrud.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplePersonCrud.Presenter
{
    static class MainFormController
    {
        //Checks if list from database is the same as in the form
        //if it's the same, then the method will end
        //if not then the list from database is copied into form and loading it into the datagrid
        public static void ShowPersonListIntoDataGridView(DataGridView dataGridView, ref List<Person> peopleFromForm)
        {
            List<Person> peopleFromDatabase = GetObjects.People();
            if (peopleFromDatabase != peopleFromForm)
            {
                peopleFromForm = peopleFromDatabase;
                LoadPeopleIntoDataGridView(dataGridView, peopleFromForm);
            }
            else { }
        }

        private static void LoadPeopleIntoDataGridView(DataGridView dataGridView, List<Person> people)
        {
            dataGridView.Rows.Clear();
            foreach (Person person in people)
            {
                dataGridView.Rows.Add
                (
                    person.ID,
                    person.FullName.ToString()
                );
            }
        }
    }
}
