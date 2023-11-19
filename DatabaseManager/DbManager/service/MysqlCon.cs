using DbManager.Models;
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
        public MysqlCon() { }
        public MysqlCon(string str) { }

        public string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public string PrimaryKey = "";
        public List<string> tableColumns = new List<string>();
        //获取表结构并识别数据库的主键。
        public void Entitybase(string tableName)
        {
            DbProviderFactory factory = MySql.Data.MySqlClient.MySqlClientFactory.Instance;
            DbConnection connection = factory.CreateConnection();
           
                //进行数据库连接
                connection.ConnectionString = connectionString;
                connection.Open();
                //获取表列的信息
                DataTable columnsSchema = connection.GetSchema("Columns", new string[] { null, null, tableName });
                foreach (DataRow columnRow in columnsSchema.Rows)
                {
                    string columnName = columnRow["COLUMN_NAME"].ToString();
                    string columnKey = columnRow["COLUMN_KEY"].ToString();
                    if (columnKey == "PRI")
                    {
                        PrimaryKey = columnName;
                        //Console.WriteLine($"Primary key found: {columnName}");
                    }
                   
                    
                        tableColumns.Add(columnName);
                    
                }
                EntityBase entityBase = new EntityBase(tableColumns, PrimaryKey,connection,tableName);              
            }
        }
    }
