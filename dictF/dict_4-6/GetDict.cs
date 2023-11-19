using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace dict_4_6
{

    internal class GetDict
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        private static string lastVisitedWordId; // 保存上次浏览的单词
       public string word = " ";
        public string phonetic = " ";
        public string translate = " ";
        public string distortion = " ";
        public string samples = "  ";
        public string id = " ";
       public  GetDict()
        {

            // 从持久化存储中读取上次浏览的单词
            lastVisitedWordId = ReadLastVisitedWordFromStorage();
           
            // 连接数据库
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // 编写查询语句
                string query = "SELECT * FROM wine_cet4_word";
                if (lastVisitedWordId != null)
                {
                    query += " WHERE id >= @LastVisitedWord  limit 1"; // 从上次浏览的单词开始查询
                }

                // 执行查询
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (lastVisitedWordId != null)
                    {
                        command.Parameters.AddWithValue("@LastVisitedWord", lastVisitedWordId);
                    }

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            word = reader["cet4_Word"].ToString();
                            phonetic = reader["cet4_phonetic"].ToString();
                            translate = reader["cet4_translate"].ToString();
                            distortion = reader["cet4_distortion"].ToString();
                            samples = reader["cet4_samples"].ToString();
                            id = reader["id"].ToString();

                            // 将当前浏览的单词保存到持久化存储中
                            SaveLastVisitedWordToStorage(id);
                        }
                    }
                }
            }
        }
        // 从持久化存储中读取上次浏览的单词
        private static string ReadLastVisitedWordFromStorage()
        {
            string filePath = @".\SaveLastDict.txt"; // 替换为你保存文件的路径
            string id;
            // 读取文件中的内容
            using (StreamReader reader = new StreamReader(filePath))
            {
               id= reader.ReadToEnd();
                Console.WriteLine("从文件中读取的内容：");
                Console.WriteLine(id);
            }
            return id;
        }

        // 将当前浏览的单词保存到持久化存储中
        public  void SaveLastVisitedWordToStorage(string id)
        {

            string filePath = @".\SaveLastDict.txt"; // 替换为你希望保存文件的路径

            // 将字符串写入文件
            using (StreamWriter writer = new StreamWriter(filePath))
            {

                writer.Write(id);
               writer.Flush();
            }

            Console.WriteLine("内容已成功写入文件。");
        }
    }
}