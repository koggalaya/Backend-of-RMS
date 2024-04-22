using AutoMapper;
using Backend.Core.Context;
using Backend.Core.Dtos.Job;
using Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Dtos.Company;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public JobController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Crud

        //create 

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> CreateJob([FromBody]JobCreateDto dto)
        {
            var newJob = _mapper.Map<Job>(dto);
            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();
            return Ok("Job created Successfully");


        }

        //read 

        [HttpGet]
        [Route("Get")]

        public async Task<ActionResult <IEnumerable<JobGetDto>>> GetJobs()
        {
            var jobs = await _context.Jobs.Include(job=>job.company).OrderByDescending(q => q.CreatedAt).ToListAsync(); // join command in sql //
            var convertedJobs = _mapper.Map<IEnumerable<JobGetDto>>(jobs);
            return Ok(convertedJobs);

        }




    }
}
