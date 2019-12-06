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


}
