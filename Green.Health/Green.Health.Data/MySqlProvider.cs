using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green.Health.Data
{
    public class MySqlProvider : DbProvider
    {
        private DataBaseSet dbset = null;

        public MySqlProvider(DataBaseSet dataBaseSet)
        {
            this.dbset = dataBaseSet;
        }

        public override IDbConnection OpenConnect(DataBaseRW RWFlag)
        {
            string type=RWFlag==DataBaseRW.Read?"R":"W";
            string connectstring = dbset.DBItems.Find(c => c.DataBaseType == type).ConnectString;
            IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectstring);
            connection.Open();
            return connection;
        }

        public override void CloseConnect(IDbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }
}
