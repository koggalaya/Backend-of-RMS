using Backend.Core.Enums;
using System.Security.Principal;

namespace Backend.Core.Entities
{
    public class Company:BaseEntity //inherits from base entitiy 
    {
        public string Name { get; set; }

        public CompanySize Size { get; set; }

        //Relations

        public ICollection<Job> Jobs { get; set; }
    }
}
