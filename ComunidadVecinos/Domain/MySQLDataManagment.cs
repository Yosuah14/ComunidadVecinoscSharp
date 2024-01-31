﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace ComunidadVecinos.Domain
{

    public class MySQLDataManagement
    {
        public static void ExecuteNonQuery(String SQL, String cnstr)
        {
            MySqlConnection con = new MySqlConnection(cnstr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(SQL, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public static DataTable LoadData(String SQL, String cnstr)
        {

            MySqlConnection con = new MySqlConnection(cnstr);
            con.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(SQL, con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                da.Dispose();
                con.Close();
            }
            return dt;
        }
    }
}
