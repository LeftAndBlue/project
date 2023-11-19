using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.X.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Models
{
    internal class EntityBase
    {
        public EntityBase(List<string> tableColumns, string primaryKey, System.Data.Common.DbConnection connection, string tableName)
        {
            TableColumns = tableColumns;
            PrimaryKey = primaryKey;
            Connection = connection;
            TableName = tableName;
        }

        public EntityBase(string priItem)
        {
            GetEntity(priItem);
        }

        public List<string> TableColumns { get; }
        public string PrimaryKey { get; }
        public DbConnection Connection { get; }
        public string TableName { get; }
        public DataTable TableData { get; }
        /*
         * // 假设 "column_name" 是你要获取数据类型的字段名
Type columnType = reader.GetFieldType(reader.GetOrdinal("column_name")); // 获取字段数据类型

// 现在你可以使用 columnType 来获取字段的实际数据类型
Console.WriteLine("数据类型：" + columnType.Name);

         */
        public Boolean GetEntity( PriValue)
        {
            int i = 0;
            DataRow row1 = TableData.NewRow();
            string query = $"select * from  {TableName} where {PrimaryKey}={PriValue}";
            try
            {
                MySqlCommand command = new MySqlCommand(query, (MySqlConnection)Connection);
                MySqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    var columnName = reader[TableColumns[i]]; // 根据字段索引获取字段值
                                                              // 或者使用 reader["column_name"] 的方式获取字段值
                    i++;
                    Type columnType = reader.GetFieldType(reader.GetOrdinal("column_name")); // 获取字段数据类型
                    if (columnType.Name == "int")
                    {
                        TableData.Columns.Add(TableColumns[i], typeof(int));
                    }
                    else if (columnType.Name == "float")
                    {
                        TableData.Columns.Add(TableColumns[i], typeof(float));
                    }
                    else if (columnType.Name == "double")
                    {
                        TableData.Columns.Add(TableColumns[i], typeof(double));
                    }
                    else if ((columnType.Name == "Datetime"))
                    {
                        TableData.Columns.Add(TableColumns[i], typeof(DateTime));
                    }
                    else if ((columnType.Name == "string"))
                    {
                        TableData.Columns.Add(TableColumns[i], typeof(string));
                    }
                    row1[TableColumns[i]] = columnName;
                }
                TableData.Rows.Add(row1);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { Connection.Close(); }


            return true;
        }
    }
}
