using SamplePersonCrud.Model.Database.DatabaseServices;
using SamplePersonCrud.Model.Database.DatabaseTables;
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
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = TUser.Insert;
            storedProcedure.Parameters.AddRange(GetParameters.FindAll(item => !item.ParameterName.Equals(TUser.UserID)));
            storedProcedure.ExecuteNonQuery();
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
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = TUser.Update;
            storedProcedure.Parameters.AddRange(GetParameters);
            storedProcedure.ExecuteNonQuery();
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
                }
            };
        }
    }
}
