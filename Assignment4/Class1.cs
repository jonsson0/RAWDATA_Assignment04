using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    class Class1
    {
    }

//    public class AdoProgram
//    {
//        static void Main(string[] args)
//        {
//            var connStr = "host=localhost;db=northwind;uid=bulskov;pwd=henrik";

//            var conn = new NpgsqlConnection(connStr);
//            conn.Open();

//            var cmd = conn.CreateCommand();
//            cmd.CommandText = "select * from categories";
//            cmd.Connection = conn;

//            var reader = cmd.ExecuteReader();

//            while (reader.Read())
//            {
//                var category = new Category
//                {
//                    Id = reader.GetInt32(0),
//                    Name = reader.GetString(1),
//                    Decription = reader.GetString(2)
//                };
//                Console.WriteLine(category);
//            }

//        }
//    }
//}
}
