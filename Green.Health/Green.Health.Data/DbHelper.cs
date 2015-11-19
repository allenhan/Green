using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Green.Health.Data
{
    public class DBResponsity
    {
        private static DbProvider dbprovider = null;

        public static int ExcecuteCmd(string sql)
        {
            IDbConnection connection = dbprovider.OpenConnect();
            try
            {
                return connection.Execute(sql);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbprovider.CloseConnect(connection);
            }
        }

        public static List<T> Query<T>(string sql)
        {
            IDbConnection connection = dbprovider.OpenConnect();
            try
            {
                return connection.Query<T>(sql).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbprovider.CloseConnect(connection);
            }
        }
    }
}
