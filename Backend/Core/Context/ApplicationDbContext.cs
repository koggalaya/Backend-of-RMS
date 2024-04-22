using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company>Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        //manage relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasOne(Job => Job.company)
                .WithMany(Company => Company.Jobs)
                .HasForeignKey(Job => Job.CompanyId);
            modelBuilder.Entity<Candidate>()
                .HasOne(candidate => candidate.Job)
                .WithMany(Job => Job.candidates)
                .HasForeignKey(candidate => candidate.JobId);
            //becouse company size in int should convert to string 

            modelBuilder.Entity<Company>()
                .Property(company => company.Size)
                .HasConversion<string>();

            modelBuilder.Entity<Job>()
               .Property(job => job.Level)
               .HasConversion<string>();
            //after that Add-Migration update-enum-to-string

        }
    }
}
