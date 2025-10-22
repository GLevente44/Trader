using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography;
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
                var newuser = user.GetType().GetProperties();

                string salt = GenerateSalt();
                string hashedPassword = ComputeHmacSha256(newuser[2].GetValue(user).ToString(), salt);

                string sql = "INSERT INTO `users`(`UserName`, `FullName`, `Password`, `Salt`, `Email`) VALUES (@username,@fullname,@password,@salt,@email)";

                MySqlCommand cmd = new MySqlCommand(sql, conn.connection);


                cmd.Parameters.AddWithValue("@username", newuser[0].GetValue(user));
                cmd.Parameters.AddWithValue("@fullname", newuser[1].GetValue(user));
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@email", newuser[4].GetValue(user));

                conn.connection.Close();


                return new { message = "Sikeres hozzáadás." };
            }
            catch (Exception)
            {

                throw;
            }
        }


        public object LogUser(object user)
        {
            try
            {

                conn.connection.Open ();

                string sql = "SELECT * FROM users WHERE UserName = @username;";
                MySqlCommand cmd = new MySqlCommand (sql, conn.connection);

                var logUser = user.GetType().GetProperties();

                cmd.Parameters.AddWithValue("@username" , logUser[0].GetValue(user));
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string storedHash = reader.GetString(3);
                    string stroredSalt = reader.GetString(4);
                    string computeHash = ComputeHmacSha256(logUser[2].GetValue(user).ToString(), storedSalt);

                    conn.connection.Close();

                    return ;

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataView UserList()
        {
            try
            {
                conn.connection.Open();

                string sql = "SELECT * FROM users";
                MySqlCommand cmd = new MySqlCommand(sql, conn.connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DataTable dt = null;
                adapter.Fill(dt);


                conn.connection.Close();

                return dt.DefaultView;

            }
            catch (System.Exception ex)
            {

                return null;
            } 

        }

        public string GenerateSalt()
        {
            byte[] salt = new byte[16];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);


            }

            return Convert.ToBase64String(salt);
        }

        public string ComputeHmacSha256(string password, string salt)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt)))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
