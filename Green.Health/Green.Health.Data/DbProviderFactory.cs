using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Data
{
    public class DbProviderFactory
    {
        DataBaseManager dbSets = null;

        public DbProvider CreateProvider(string dbname, int RWFlag = -1)
        {
            dbSets = new DataBaseManager(dbname, DataBaseRW.Read);
            DataBaseSet dbset = dbSets.GetDataBaseSet();
            string provider = dbset.Provider;
            string connectString = dbset.DBItems.Find(c => c.DataBaseType == "").ConnectString;
            if (provider.ToLower() == "MYSQLPROVIDER")
            {
                return new MySqlProvider(connectString);
            }
            else
            {
                return new SqlServerProvider(connectString);
            }
        }
    }
}
