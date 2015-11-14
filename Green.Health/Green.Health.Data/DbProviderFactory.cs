using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Data
{
    public class DbProviderFactory
    {
        public static DbProvider CreateInstance(string dbname)
        {
            return new MySqlProvider("Server=localhost;Database=world;Uid=root;Pwd=toor;");
        }
    }
}
