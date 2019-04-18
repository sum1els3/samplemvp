using SamplePersonCrud.Model.Database.DatabaseServices;
using SamplePersonCrud.Model.Database.DatabaseTables;
using SamplePersonCrud.Model.Objects.Person;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.User
{
    class UserContext : User, ICUD
    {
        public void Create()
        {
            CheckIfExist();
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = TUser.Insert;
            storedProcedure.Parameters.AddRange(GetParameters.FindAll(item => !item.ParameterName.Equals(TUser.UserID)));
            storedProcedure.ExecuteNonQuery();
        }

        private ICUD PersonCUD()
        {
            return new PersonContext()
            {
                PersonID = Person.PersonID,
                LastName = Person.LastName,
                FirstName = Person.FirstName,
                MiddleName = Person.MiddleName
            };
        }

        private void CheckIfExist()
        {
            if (Person.PersonID == 0)
            {
                PersonCUD().Create();
                SetPersonID();
            }
        }

        private void SetPersonID()
        {
            List<IPerson> personList = new PersonList().GetPeople();
            Person.PersonID = personList.Find(item => item.LastName.Equals(Person.LastName) && item.FirstName.Equals(Person.FirstName) && item.MiddleName.Equals(Person.MiddleName)).PersonID;
        }

        public void Delete()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = TUser.Delete;
            storedProcedure.Parameters.Add(GetParameters.Find(item => item.ParameterName.Equals(TUser.UserID)));
            storedProcedure.ExecuteNonQuery();
        }

        public void Update()
        {
            UpdatePerson();
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = TUser.Update;
            storedProcedure.Parameters.AddRange(GetParameters);
            storedProcedure.ExecuteNonQuery();
        }

        private void UpdatePerson()
        {
            CheckIfExist();
            PersonCUD().Update();
        }

        private List<Parameter> GetParameters
        {
            get => new List<Parameter>()
            {
                new Parameter()
                {
                    ParameterName = TUser.UserID,
                    ParameterType = SqlDbType.Int,
                    ParameterValue = UserID
                },
                new Parameter()
                {
                    ParameterName = TUser.Username,
                    ParameterType = SqlDbType.VarChar,
                    ParameterValue = Username
                },
                new Parameter()
                {
                    ParameterName = TUser.Password,
                    ParameterType = SqlDbType.VarChar,
                    ParameterValue = Password
                },
                new Parameter()
                {
                    ParameterName = TUser.PersonID,
                    ParameterType = SqlDbType.Int,
                    ParameterValue = Person.PersonID
                }
            };
        }
    }
}
