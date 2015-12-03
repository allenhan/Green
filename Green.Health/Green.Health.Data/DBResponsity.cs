using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Green.Health.Data
{
    /// <summary>
    /// add by hj
    /// 数据操作仓库
    /// </summary>
    public class DBResponsity
    {
        private static DbProvider dbprovider = null;

        public DBResponsity(string dbName)
        {
            dbprovider = DbProviderFactory.GetInstance().CreateProvider(dbName);
        }

        public int ExcecuteSql(string sql, string rwflag = "R")
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="rwflag"></param>
        /// <returns>turple<return execute sql, return outputvalue></returns>
        public Tuple<int, object> ExecuteSql(string sql, DBParameterCollection parameters, string rwflag = "R")
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
                List<string> outparaname = new List<string>();
                DynamicParameters dps = new DynamicParameters();
                foreach (DBParameter para in parameters)
                {
                    dps.Add(para.Name, para.DbValue, para.DbType, direction: para.Direction, size: para.Size);
                    if (para.Direction == ParameterDirection.Output)
                    {
                        outparaname.Add(para.Name);
                    }
                }
                int value = connection.Execute(sql, dps);
                object rtnvalue = null;
                if (outparaname.Count > 0)
                    rtnvalue = dps.Get<object>(outparaname[0]);
                return new Tuple<int, object>(value, rtnvalue);
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

        public IEnumerable<T> QuerySql<T>(string sql, DBParameterCollection parameters = null, string rwflag = "R") where T : class
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
                DynamicParameters dps = new DynamicParameters();
                if (parameters != null)
                {
                    foreach (DBParameter para in parameters)
                    {
                        dps.Add(para.Name, para.DbValue, para.DbType, direction: para.Direction, size: para.Size);
                    }
                }
                return connection.Query<T>(sql, dps);
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

        public long InsertEntity<T>(T obj, string rwflag = "R") where T : class
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
                return connection.Insert(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateEntity<T>(T obj, string rwflag = "R") where T : class
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
                return connection.Update<T>(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEntity<T>(T obj, string rwflag = "R") where T : class
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
                return connection.Delete<T>(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAll<T>(string rwflag = "R") where T : class
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
                return connection.DeleteAll<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Query<T>(long id, string rwflag = "R") where T : class
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
                return connection.Get<T>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> QueryAll<T>(string rwflag = "R") where T : class
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
                return connection.GetAll<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    public class DBResponsityFactory
    {
        public static DBResponsity GetInstance(string dbName)
        {
            return new DBResponsity(dbName);
        }
    }
}
