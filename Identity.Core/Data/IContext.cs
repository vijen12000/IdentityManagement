using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core.Data
{
    public interface IContext : IDisposable
    {
        bool IsTransactionStarted { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
