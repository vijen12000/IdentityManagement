﻿using Dapper;
using Identity.Core.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Identity.Data
{
    public abstract class DbContext : DapperContext
    {
        protected override IDbConnection CreateConnection()
        {
            var config = ConfigurationManager.ConnectionStrings["Default"];
            var factory = DbProviderFactories.GetFactory(config.ProviderName);

            var conn = factory.CreateConnection();
            conn.ConnectionString = config.ConnectionString;

            return conn;
        }
    }
}
