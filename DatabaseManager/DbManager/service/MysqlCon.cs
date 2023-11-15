using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;

namespace DbManager.service
{
    internal class MysqlCon
    {


        public string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        public MysqlCon()
        {

        }
        public MysqlCon(string str)
        {

        }
        //获取表结构并识别数据库的主键。
        public void Entitybase(string tableName)
        {
            DbProviderFactory factory = MySql.Data.MySqlClient.MySqlClientFactory.Instance;

            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DataTable columnsSchema = connection.GetSchema("Columns", new string[] { null, null, tableName });
                foreach (DataRow columnRow in columnsSchema.Rows)
                {
                    string columnName = columnRow["COLUMN_NAME"].ToString();
                    string columnKey = columnRow["COLUMN_KEY"].ToString();
                    if (columnKey == "PRI")
                    {
                        Console.WriteLine($"Primary key found: {columnName}");
                    }
                }
            }
        }
    }
}