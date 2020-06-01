using DAL.Contract;
using DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    public class DbCommandHandler : ICommandHandler
    {
        private readonly IConnectionFactory _connectionFactory;

        public DbCommandHandler()
        {
            _connectionFactory = new ConnectionFactory();//connectionFactory;
        }

        public IList<T> ExecuteStoredProcedureList<T>(string storedProcedure, IEnumerable<IDbDataParameter> allParams = null)
        {
            return ExecuteCommand<T>(storedProcedure, CommandType.StoredProcedure, allParams);
        }

        private IList<T> ExecuteCommand<T>(string commandText, CommandType commandType, IEnumerable<IDbDataParameter> allParams = null)
        {
            using (var conn = _connectionFactory.GetDefaultConnection())
            {
                try
                {
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = commandText;
                        command.CommandType = commandType;
                        conn.Open();
                        allParams?.ToList().ForEach(p => command.Parameters.Add(p));
                        return ToList<T>(command).ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private IList<T> ToList<T>(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                return ToList<T>(record);
            }
        }

        private IList<T> ToList<T>(IDataReader record)
        {
            List<T> items = new List<T>();
            while (record.Read())
            {
                items.Add(Map<T>(record));
            }

            return items;
        }

        public TEntity Map<TEntity>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<TEntity>();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                    property.SetValue(objT, record[property.Name]);
            }
            return objT;
        }
    }
}
