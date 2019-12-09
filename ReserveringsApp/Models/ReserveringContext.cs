using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveringsApp.Models
{
    public class ReserveringContext
    {

        public string ConnectionString { get; set; }

        public ReserveringContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        //public List<Reservering> GetReserverings()
        //{
        //    List<Reservering> list = new List<Reservering>();

        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("SELECT * FROM reservering", conn);
        //        using (MySqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                list.Add(new Reservering()
        //                {
        //                    naam = reader.GetString("Naam"),
                           
        //                });
        //            }
        //        }
        //    }

        //    return list;
        //}
    }
}
