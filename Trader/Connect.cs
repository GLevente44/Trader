﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader
{
    internal class Connect
    {
        public MySqlConnection connection;


        private string _host;
        private string _db;
        private string _user;
        private string _password;

        private string connectionString;

        public Connect()
        {
            _host = "localhost";
            _db = "trader";
            _user = "root";
            _password = "";

            connectionString = $"SERVER={_host};DATABASE={_db};UID={_user};PASSWORD={_password};SSlMode=None";
            
            connection = new MySqlConnection(connectionString)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
        }
    }
}
