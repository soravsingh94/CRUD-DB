using DAL.UnitOfWork;
using System.Data;

namespace DAL.Contract
{
    public interface IConnectionFactory
    {
        IDbConnection GetUoWConnection(UowContext uowContext);
        void RemoveUoWConnection(UowContext uowContext);
        IDbConnection GetDefaultConnection();
    }
}
