using EntCloud.DBContext;
using EntCloud.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntCloud.Transactions
{
    public interface ITransactionDealerRepository
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        void DisposeTransaction();
    }

    public sealed class TransactionDealerRepository : FacilityRepository, ITransactionDealerRepository
    {
        public TransactionDealerRepository(FacilityContext dbContext)
           : base(dbContext)
        { }

        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public void DisposeTransaction()
        {
            _dbContext.Database.CurrentTransaction.Dispose();
        }
    }
}
