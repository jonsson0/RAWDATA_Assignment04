using System;
using System.Text;
using Npgsql;

namespace Assignment4
{

  public class AdoProgram
    {
        //ass4
        static void Main(string[] args)
        {
            var connStr = "host=rawdata.ruc.dk;db=raw14;uid=raw14;pwd=I.eSywI3";

            var conn = new NpgsqlConnection(connStr);
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "select * from categories";
            cmd.Connection = conn;

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var category = new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2)
                };
                Console.WriteLine(category);
            }

        }
    }
}

