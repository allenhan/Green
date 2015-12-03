using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green.Health.Data
{
    /// <summary>
    /// add by hj
    /// 所有数据库提供者
    /// </summary>
    public abstract class DbProvider
    {
        public abstract IDbConnection OpenConnect(DataBaseRW RWFlag);

        public abstract void CloseConnect(IDbConnection connection);
    }
}
