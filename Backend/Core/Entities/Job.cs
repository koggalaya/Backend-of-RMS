using Backend.Core.Enums;

namespace Backend.Core.Entities
{
    public class Job : BaseEntity
    {

        public string Tital { get; set; }
        public JobLevel Level { get; set; }

        //Relations

        public long CompanyId { get; set; }

        public Company company { get; set; }

        public ICollection<Candidate> candidates { get; set; }
    }
}
