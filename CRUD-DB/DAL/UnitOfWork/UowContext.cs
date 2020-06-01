using System;

namespace DAL.UnitOfWork
{
    public class UowContext
    {
        public readonly string contextId;
        public UowContext()
        {
            contextId = Guid.NewGuid().ToString();
        }
    }
}
