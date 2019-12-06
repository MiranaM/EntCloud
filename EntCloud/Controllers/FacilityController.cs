using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using EntCloud.Models;
using EntCloud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityRepository _facilityRepository;

        public FacilityController(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        // GET: api/Facility
        [HttpGet]
        public IActionResult Get()
        {
            var facilities = _facilityRepository.GetFacilities();
            return new OkObjectResult(facilities);
        }

        // GET: api/Facility/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var facilities = _facilityRepository.GetFacilityById(id);
            return new OkObjectResult(facilities);
        }

        // POST: api/Facility
        [HttpPost]
        public IActionResult Post([FromBody] Facility facility)
        {
            using (var scope = new TransactionScope())
            {                
                _facilityRepository.InsertFacility(facility);
                
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = facility.Id }, facility);
            }
        }

        // PUT: api/Facility/5
        //[HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Facility facility)
        {
            if(facility != null)
            {
                using (var scope = new TransactionScope())
                {
                    _facilityRepository.UpdateFacility(facility);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _facilityRepository.DeleteFacility(id);
            return new OkResult();
        }
    }
}
