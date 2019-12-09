using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntCloud.DBContext;
using EntCloud.Models;
using Microsoft.EntityFrameworkCore;

namespace EntCloud.Repository
{
    public class FacilityRepository : IFacilityRepository
    {
        protected readonly FacilityContext _dbContext;

        public FacilityRepository (FacilityContext fc)
        {
            _dbContext = fc;
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
            _dbContext.SaveChanges();
        }

        public void Save()
        {            
            _dbContext.SaveChanges(true);
        }

        public void UpdateFacility(Facility Facility)
        {
            _dbContext.Entry(Facility).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges(true);
        }
    }
}
