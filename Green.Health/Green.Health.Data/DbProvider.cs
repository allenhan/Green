using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green.Health.Data
{
    public abstract class DbProvider
    {
        public abstract IDbConnection OpenConnect();

        public abstract void CloseConnect(IDbConnection connection);
    }
}
