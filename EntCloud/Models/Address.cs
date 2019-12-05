using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntCloud.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int StreetId { get; set; }
        public int BuildingNumber { get; set; }
    }
}
