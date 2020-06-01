using DAL.Contract;
using DAL.UnitOfWork;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly DbProviderFactory _provider;

        readonly ConcurrentDictionary<string, IDbConnection> _dbConnections = new ConcurrentDictionary<string, IDbConnection>();
        public ConnectionFactory()
        {
            _provider = DbProviderFactories.GetFactory("System.Data.SqlClient");

        }

        public IDbConnection GetUoWConnection(UowContext uowContext)
        {
            return _dbConnections.GetOrAdd(uowContext.contextId, (key) => CreateConnection());
        }

        public IDbConnection GetDefaultConnection()
        {
            return CreateConnection();
        }

        private IDbConnection CreateConnection()
        {
            var dbConnection = _provider.CreateConnection();

            if (dbConnection == null)
                throw new Exception(
                    "Failed to create a connection using the connection string named System.Data.SqlClient in app/web.config.");
            dbConnection.ConnectionString = "Data Source=SORAVSINGH;Initial Catalog=CRUD-DB;Integrated Security=True";
            return dbConnection;
        }

        public void RemoveUoWConnection(UowContext uowContext)
        {
            try
            {
                bool isRemoved = _dbConnections.TryRemove(uowContext.contextId, out IDbConnection connection);
                if (isRemoved)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
               // _logger.Error("Error in removing DB connection from ConnectionFactory", ex);
            }
        }
    }
}
