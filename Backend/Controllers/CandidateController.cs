﻿using AutoMapper;
using Backend.Core.Context;
using Backend.Core.Dtos.Candidate;
using Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public CandidateController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto dto, IFormFile pdfFile)
        {
            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/pdf";

            if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
             {
                return BadRequest("File is not valid");

            }

            var resumeUrl= Guid.NewGuid().ToString() + ".pdf" ;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"documents","pdfs",resumeUrl);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }
            var newCandidate = _mapper.Map<Candidate>(dto);
            newCandidate.ResumeURl = resumeUrl;
            await _context.Candidates.AddAsync(newCandidate);
            await _context.SaveChangesAsync();

            return Ok(newCandidate);

            
        }

        //Read

        [HttpGet]
        [Route("Get")]

        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
        {
            var candidates = await _context.Candidates.Include(c => c.Job).OrderByDescending(q => q.CreatedAt).ToListAsync(); 
            var convertedCandidate = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);
            return Ok(convertedCandidate);
        }

        [HttpGet]
        [Route("download/{url}")]

        public IActionResult DownloadPdfFile(string url)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File Not Found ");
            }
            var PdfBytes = System.IO.File.ReadAllBytes(filePath);
            var file = File(PdfBytes, "application/pdf", url);
            return file;    //programs/use core>>
        }

    }
}
