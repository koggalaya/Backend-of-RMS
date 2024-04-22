using Backend.Core.Entities;
using Backend.Core.Enums;
using Backend.Core.Dtos.Job;

namespace Backend.Core.Dtos.Job
{
    public class JobGetDto
    {
        public long ID { get; set; }

        
        public string Tital { get; set; }
        public JobLevel Level { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }  // creted this from other class should map in auto mapper 1-1   //
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
