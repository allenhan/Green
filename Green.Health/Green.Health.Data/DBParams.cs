﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Green.Health.Data
{
    public class DBParameter
    {
        public DbType DbType  { get; set; }

        public object DbValue { get; set; }

        public string Name { get; set; }

        public ParameterDirection Direction { get; set; }

        public int Size { get; set; }
    }

    public class DBParameterCollection : List<DBParameter>
    {
        public void AddDbParameter(DBParameter parameter)
        {
            this.Add(parameter);
        }
    }
}
