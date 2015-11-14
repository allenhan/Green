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

        public MySqlProvider(string conString)
            : base(conString)
        {

        }

        public override IDbConnection OpenConnect()
        {
            IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectString);
            connection.Open();
            return connection;
        }
        public override void CloseConnect(IDbConnection connection)
        {
            connection.Close();
        }
    }

}
