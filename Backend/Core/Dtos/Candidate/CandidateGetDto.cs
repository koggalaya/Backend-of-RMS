﻿namespace Backend.Core.Dtos.Candidate
{
    public class CandidateGetDto
    {
        public long ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeURl { get; set; }


        //Relations 
        public long JobId { get; set; }

        public string JobTitle { get; set; }
    }
}
