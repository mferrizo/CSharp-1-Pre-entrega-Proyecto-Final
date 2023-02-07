using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoCoder.Models;

namespace CursoCoder.Helper
{
    internal class SqlHandler
    {
        static string connectionString = "Data Source=DESKTOP-QR97TGF;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection connection = new SqlConnection(connectionString);
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private Boolean ValidLogin = false;
        public void GetCommand(DataSet ds, SqlCommand command)
        {
            connection.Open();
            command.Connection = connection;
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "DAT");
            connection.Close();
            Console.WriteLine(ValidLogin);
        }

        public Boolean LoginUser(string userName, string userPassword)
        {
            SqlCommand command = new SqlCommand("select * from Usuario where NombreUsuario=@userName and Contraseña=@userPassword", connection);
            DataSet ds = new DataSet();
            connection.Open();

            var parameterUser = new SqlParameter();
            parameterUser.ParameterName = "userName";
            parameterUser.SqlDbType = SqlDbType.VarChar;
            parameterUser.Value = userName;

            var parameterPass = new SqlParameter();
            parameterPass.ParameterName = "userPassword";
            parameterPass.SqlDbType = SqlDbType.VarChar;
            parameterPass.Value = userPassword;

            command.Parameters.Add(parameterUser);
            command.Parameters.Add(parameterPass);

            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "USER");
            connection.Close();

            if (ds.Tables.Contains("USER") && ds.Tables["USER"].Rows.Count > 0) ValidLogin = true;

            return ValidLogin;
        }
    }
}
