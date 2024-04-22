using AutoMapper;
using Backend.Core.Dtos.Candidate;
using Backend.Core.Dtos.Company;
using Backend.Core.Dtos.Job;
using Backend.Core.Entities;

namespace Backend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile: Profile
    {
        public AutoMapperConfigProfile()
        {
            //company
            CreateMap<CompanyCreateDto, Company>(); // shoud say programe.cs to use this mapping 
            CreateMap<Company, CompanyGetDto>();

            //job
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
            .ForMember(dest => dest.CompanyName,opt => opt.MapFrom(src=>src.company.Name));

            //candidate
            CreateMap<CandidateCreateDto, Candidate>();
            CreateMap<Candidate, CandidateGetDto>()
            .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Tital));
        }
    }
}
