using System.Data;
using MySql.Data.MySqlClient;

namespace DWF.Repository
{
    public class Repository
    {
        public IDbConnection Connect()
        {
            return new MySqlConnection(
                "Server=127.0.0.1;Port=3306;" +
                ";Database=portaaldwf;" +
                "Uid=root;Pwd=Test12345;"
            );
        }
    }
}