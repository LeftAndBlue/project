using DbManager.service;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace DbManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            MysqlCon mysqlCon = new MysqlCon();
            mysqlCon.Entitybase("Person");
           

            //try
            //{             
            //    string sql = "SELECT id, name, age FROM person";
            //    MySqlCommand command = new MySqlCommand(sql, mysqlCon.GetConnection());
            //    using (MySqlDataReader reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            int id = reader.GetInt32("id");
            //            string name = reader.GetString("name");
            //            int age = reader.GetInt32("age");
            //            Console.WriteLine($"ID: {id}, Name: {name}, Age: {age}");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("数据库操作失败: " + ex.Message);
            //}

        }
    }
}