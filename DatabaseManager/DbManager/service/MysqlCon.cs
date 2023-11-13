using MySql.Data.MySqlClient;
using System.Configuration;

namespace DbManager.service
{
    internal class MysqlCon
    {


        private readonly MySqlConnection _connection;

        public MysqlCon()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

    }
}
