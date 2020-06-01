using System.Collections.Generic;
using System.Data;

namespace DAL.Contract
{
    public interface ICommandHandler
    {
        IList<T> ExecuteStoredProcedureList<T>(string storedProcedure, IEnumerable<IDbDataParameter> parameters = null);
    }
}
