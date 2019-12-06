using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntCloud.DBContext;
using EntCloud.Models;
using EntCloud.Transactions;

namespace EntCloud.Repository
{
    public class FacilityRepository : IFacilityRepository
    {
        protected readonly FacilityContext _dbContext;
        protected TransactionDealerRepository _transactionDealerRepository;

        public FacilityRepository (FacilityContext fc)
        {
            _dbContext = fc;
            _transactionDealerRepository = new TransactionDealerRepository(_dbContext);

        }

        public void DeleteFacility(int FacilityId)
        {
            var facility = _dbContext.Facilities.Find(FacilityId);
            _dbContext.Facilities.Remove(facility);
            Save();
        }

        public IEnumerable<Facility> GetFacilities()
        {
            return _dbContext.Facilities.ToList();
        }

        public Facility GetFacilityById(int FacilityId)
        {
            return _dbContext.Facilities.Find(FacilityId);
        }

        public Facility GetFacilityByOwnerId(int OwnerId)
        {
            return _dbContext.Facilities.Find(OwnerId);
        }

        public void InsertFacility(Facility Facility)
        {
            _dbContext.Add(Facility);
            Save();
        }

        public void Save()
        {
            _transactionDealerRepository.BeginTransaction();
            try
            {
                _dbContext.SaveChanges(true);
            }
            catch (Exception)
            {
                _transactionDealerRepository.RollbackTransaction();
                throw;
            }
            finally
            {
                _transactionDealerRepository.DisposeTransaction();
            }
        }

        public void UpdateFacility(Facility Facility)
        {
            _dbContext.Entry(Facility).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
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
