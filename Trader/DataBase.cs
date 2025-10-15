using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader
{
    internal class DataBase
    {
        Connect conn = new Connect();

        public object AddNewUser(object user)
        {

            try
            {
                conn.connection.Open();

                string sql = "INSERT INTO `users`(`UserName`, `FullName`, `Password`, `Salt`, `Email`) VALUES (@username,@fullname,@password,@salt,@email)";

                MySqlCommand cmd = new MySqlCommand(sql, conn.connection);

                var newuser = user.GetType().GetProperties();

                cmd.Parameters.AddWithValue("@username", newuser[0].GetValue(user));
                cmd.Parameters.AddWithValue("@fullname", newuser[1].GetValue(user));
                cmd.Parameters.AddWithValue("@password", newuser[2].GetValue(user));
                cmd.Parameters.AddWithValue("@salt", newuser[3].GetValue(user));
                cmd.Parameters.AddWithValue("@email", newuser[4].GetValue(user));

                conn.connection.Close();


                return new { message = "Sikeres hozzáadás." };
            }
            catch (Exception)
            {

                throw;
            }
        }


        public object logButton_Click(object user)
        {
            conn.connection.Open ();

            string sql = "SELECT * FROM users WHERE UserName = @username AND Password = @password";
            MySqlCommand cmd = new MySqlCommand (sql, conn.connection);

            var logUser = user.GetType().GetProperties();

            MySqlDataReader reader = cmd.ExecuteReader();
            object isRegistered = reader.Read() ? new { message = "Regisztrált" } : new { message = "Nem Regisztrált" };

            cmd.Parameters.AddWithValue("@username" , logUser[0].GetValue(user));
            cmd.Parameters.AddWithValue("@password", logUser[1].GetValue(user));


            conn.connection.Close ();
            return isRegistered;
        }
    }
}
