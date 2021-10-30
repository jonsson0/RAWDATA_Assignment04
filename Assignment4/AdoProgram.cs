using System;
using System.IO;
using System.Text;
using Assignment4.Domain;
using Npgsql;

namespace Assignment4
{

  public class AdoProgram
    {
        //ass4
        static void Main(string[] args)
        {
            //  var connStr = "host=rawdata.ruc.dk;db=raw14;uid=raw14;pwd=I.eSywI3";
            //  var connStr2 = "host=localhost;db=northwind;uid=postgres;pwd=XXXXXX";

            // Insted of one of the above we have our own
            // saved in a txt file that we then read from

            string connStringFromFile;
           
            using (StreamReader readtext = new StreamReader("C:/Login/Login.txt"))
            {
                connStringFromFile = readtext.ReadLine();
            }         

            var conn = new NpgsqlConnection(connStringFromFile);
            conn.Open();

            var cmd = conn.CreateCommand();
            //  cmd.CommandText = "select * from northwind.categories";
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

            // Can test stuff here live insted of tests:
            DataService dataService = new DataService();

            
         // eg:
         //   dataService.GetCategory(1);
        
        }
    }
}