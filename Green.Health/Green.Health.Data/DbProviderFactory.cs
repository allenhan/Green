using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Data
{
    public class DbProviderFactory
    {
        DataBaseManager dbSets = null;

        private readonly static DbProviderFactory instance = new DbProviderFactory();

        private DbProviderFactory() {
 
        }

        public static DbProviderFactory GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbname">数据库名称</param>
        /// <returns></returns>
        public DbProvider CreateProvider(string dbname)
        {
            dbSets = new DataBaseManager(dbname);
            DataBaseSet dbset = dbSets.GetDataBaseSet();
            string provider = dbset.Provider;
            if (provider.ToUpper() == "MYSQLPROVIDER")//mysqlProvider
            {
                return new MySqlProvider(dbset);
            }
            else
            {
                return new SqlServerProvider(dbset);
            }
        }
    }
}
