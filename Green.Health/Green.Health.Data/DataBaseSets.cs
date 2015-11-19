using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Data
{
    public class DataBaseManager
    {
        private string provider = "";
        private DataBaseSet dataBaseSet = null;

        public DataBaseManager(string dbname, DataBaseRW flag)
        {
            //读xml 取相关database 配置
        }

        public DataBaseSet GetDataBaseSet()
        {
            return dataBaseSet;
        }
    }

    public class DataBaseSet 
    {
        public string Provider { get; set; }

        public string Name { get; set; }

        public List<DBItem> DBItems { get; set; }
    }

    public class DBItem
    {
        public string Name { get; set; }

        public string DataBaseType { get; set; }

        public string ConnectString { get; set; }
    }
    
}
