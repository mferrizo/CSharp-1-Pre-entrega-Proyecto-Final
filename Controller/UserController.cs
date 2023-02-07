using CursoCoder.Helper;
using CursoCoder.Models;
using Proyecto1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCoder.Controller
{
    internal class UserController
    {
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            DataSet dsUsers = new DataSet();
            SqlCommand selectCommand = new SqlCommand("select * from Usuario");

            Program.sqlHandler.GetCommand(dsUsers, selectCommand);

            if (dsUsers.Tables.Contains("DAT") && dsUsers.Tables["DAT"].Rows.Count > 0)
            {
                DataTable dtDAT = dsUsers.Tables["DAT"];
                foreach (DataRow dr in dtDAT.Rows)
                {
                    User user = new User();

                    user.Id = Convert.ToInt32(dr["id"]);
                    user.Name = Convert.ToString(dr["nombre"]).Trim();
                    user.Surname = Convert.ToString(dr["apellido"]).Trim();
                    user.UserName = Convert.ToString(dr["nombreusuario"]).Trim();
                    user.Password = Convert.ToString(dr["contraseña"]).Trim();
                    user.Email = Convert.ToString(dr["mail"]).Trim();

                    users.Add(user);

                }
            }

            return users;
        }

        public static User GetUser(Int32 userId)
        {
            User user = new User();
            DataSet dsUser = new DataSet();
            SqlCommand selectCommand = new SqlCommand("select * from Usuario where Id=@userId");

            var parameter = new SqlParameter();
            parameter.ParameterName = "userId";
            parameter.SqlDbType = SqlDbType.BigInt;
            parameter.Value = userId;

            selectCommand.Parameters.Add(parameter);
            Program.sqlHandler.GetCommand(dsUser, selectCommand);

            if (dsUser.Tables.Contains("DAT") && dsUser.Tables["DAT"].Rows.Count > 0)
            {
                DataRow dr = dsUser.Tables["DAT"].Rows[0];
                user.Id = Convert.ToInt32(dr["id"]);
                user.Name = Convert.ToString(dr["nombre"]).Trim();
                user.Surname = Convert.ToString(dr["apellido"]).Trim();
                user.UserName = Convert.ToString(dr["nombreusuario"]).Trim();
                user.Password = Convert.ToString(dr["contraseña"]).Trim();
                user.Email = Convert.ToString(dr["mail"]).Trim();

            }
            return user;
        }
    }
}
