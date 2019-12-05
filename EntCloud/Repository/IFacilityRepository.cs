using EntCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntCloud.Repository
{
    public interface IFacilityRepository
    {
        IEnumerable<Facility> GetFacilities();
        Facility GetFacilityById(int FacilityId);
        Facility GetFacilityByOwnerId(int OwnerId);
        void InsertFacility(Facility Facility);
        void DeleteFacility(int FacilityId);
        void UpdateFacility(Facility Facility);
        void Save();
    }
}
