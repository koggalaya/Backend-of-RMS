using Backend.Core.Enums;

namespace Backend.Core.Dtos.Job
{
    public class JobCreateDto
    {
        internal object CompanyName;

        public string Tital { get; set; }
        public JobLevel Level { get; set; }

        public long CompanyId { get; set; }
    }
}
