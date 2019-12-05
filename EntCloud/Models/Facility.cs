using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntCloud.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int OwnerId { get; set; }
        public string Telephone { get; set; }
    }
}
