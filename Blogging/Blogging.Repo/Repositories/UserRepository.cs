using Blogging.Repo.Interfaces;
using Blogging.Repo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Repo.Repositories
{
    public class UserRepository : IUserRepository
    {
        SqlConnection _sqlConnection;
        public UserRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public User GetUser(string userName, string password)
        {
            try
            {
                using (_sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "user_by_username_password";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = _sqlConnection;

                    SqlParameter userNameParameter = new SqlParameter();
                    userNameParameter.ParameterName = "@username";
                    userNameParameter.SqlDbType = SqlDbType.NVarChar;
                    userNameParameter.Direction = ParameterDirection.Input;
                    userNameParameter.Value = userName;

                    SqlParameter passwordParameter = new SqlParameter();
                    passwordParameter.ParameterName = "@password";
                    passwordParameter.SqlDbType = SqlDbType.NVarChar;
                    passwordParameter.Direction = ParameterDirection.Input;
                    passwordParameter.Value = password;

                    sqlCommand.Parameters.Add(userNameParameter);
                    sqlCommand.Parameters.Add(passwordParameter);

                    _sqlConnection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dtUser = new DataTable();
                    dataAdapter.Fill(dtUser);


                    return dtUser.AsEnumerable().Select(user => new User()
                    {
                        UserId = Convert.ToInt32(user["UserId"]),
                        UserName = Convert.ToString(user["UserName"]),
                        Password = Convert.ToString(user["Password"])
                    }).FirstOrDefault();
                }

            }
            finally
            {
                _sqlConnection.Close();
            }
            
        }
    }
}
