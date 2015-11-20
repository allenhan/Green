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
        private static DbProvider dbprovider = DbProviderFactory.GetInstance().CreateProvider("");

        public static int ExcecuteCmd(string sql, string rwflag = "R")
        {
            IDbConnection connection = null;
            if (rwflag == "R")
            {
                connection = dbprovider.OpenConnect(DataBaseRW.Read);
            }
            else
            {
                connection = dbprovider.OpenConnect(DataBaseRW.Write);
            }
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

        public static List<T> Query<T>(string sql, string rwflag = "R")
        {
            IDbConnection connection = null;
            if (rwflag == "R")
            {
                connection = dbprovider.OpenConnect(DataBaseRW.Read);
            }
            else
            {
                connection = dbprovider.OpenConnect(DataBaseRW.Write);
            }
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
