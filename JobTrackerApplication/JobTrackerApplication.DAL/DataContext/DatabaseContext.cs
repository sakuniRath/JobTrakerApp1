using JobTrackerApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerApplication.DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            // Seed data
            builder.Entity<Job>().HasData(
                new Job { Id = 1, CompanyName = "Virtusa", Position = "Associate Engineer" },
                new Job { Id = 2, CompanyName = "HCL", Position = "Engineer" },
                new Job { Id = 3, CompanyName = "Virtusa", Position = "Engineer" }
            );

            builder.Entity<ApplicationUsers>().HasData(
                new ApplicationUsers { Id = 1, UserName = "Sakuni", UserRole = "CompanyUser" },
                new ApplicationUsers { Id = 2, UserName = "Iruka", UserRole = "Applicant" },
                new ApplicationUsers { Id = 3, UserName = "Hansini", UserRole = "Applicant" }
            );

            builder.Entity<JobApplication>().HasData(
                new JobApplication
                {
                    Id = 1,
                    JobId = 1,
                    ApplicationUserId = 1,
                    Status = "Interview",
                    DateApplied = new DateTime(2025, 10, 10)
                },
                new JobApplication
                {
                    Id = 2,
                    JobId = 2,
                    ApplicationUserId = 2,
                    Status = "Interview",
                    DateApplied = new DateTime(2025, 10, 10)
                },
                new JobApplication
                {
                    Id = 3,
                    JobId = 3,
                    ApplicationUserId = 3,
                    Status = "Interview",
                    DateApplied = new DateTime(2025, 10, 10)
                }
            );
            base.OnModelCreating(builder);
        }
    }
}