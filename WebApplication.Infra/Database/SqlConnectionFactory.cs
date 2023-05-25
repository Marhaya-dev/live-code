using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infra.Interfaces;

namespace WebApplication.Infra.Database
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public string _connectionString { get; set; }

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
