using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.ADO;

namespace ASP.Model.Comon.Repositories
{
    public abstract class BasicRepository
    {
        private string _connectionString;
        protected Connection _connection;

        public BasicRepository(string connectionStringName, string invariantName = "System.Data.SqlClient")
        {
            _connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            _connection = new Connection(_connectionString, invariantName);
        }
    }
}
