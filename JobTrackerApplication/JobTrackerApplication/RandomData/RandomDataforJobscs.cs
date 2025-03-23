
using JobTrackerApplication.Entity.Jobs;
using System.Diagnostics.Metrics;

namespace JobTrackerApplication.RandomData
{
    public static class RandomDataforJobscs
    {

        public static List<JobViewModel> SeedJobs()
        {
            List<JobViewModel> JobList = new List<JobViewModel>
            {
                new JobViewModel {Id=1, CompanyName ="Virtusa" ,Position = "Engineer"},
                new JobViewModel { Id=2,CompanyName ="HCL" ,Position = "EngineerDev"},
                new JobViewModel { Id=3,CompanyName ="CreativeSoftware" ,Position = "EngineerQA"},
                new JobViewModel { Id=4,CompanyName ="DataCom" ,Position = "AssosiateEngineer"},
                new JobViewModel { Id=5,CompanyName ="Inivos" ,Position = "InternDev"},
                new JobViewModel { Id=7,CompanyName ="Virtusa" ,Position = "AssosiateEngineer"},
                new JobViewModel { Id=9,CompanyName ="Inivos" ,Position = "AssosiateEngineer"},
                new JobViewModel { Id=10,CompanyName ="HCL" ,Position = "InternDev"},
                new JobViewModel { Id=11,CompanyName ="HCL" ,Position = "BA"},
                new JobViewModel { Id=12,CompanyName ="DataCom" ,Position = "ProjectManager"},
                new JobViewModel { Id=13,CompanyName ="Virtusa" ,Position = "LeadEngineer"},
                new JobViewModel { Id=14,CompanyName ="Virtusa" ,Position = "LeadQAEngineer"},
            };
            return JobList;
        }

        public static List<UserViewModel> SeedUser()
        {
            List<UserViewModel> UserList = new List<UserViewModel>
            {
                new UserViewModel {Id= 1,UserName ="Sakuni" ,UserRole = "Applicant"},
                new UserViewModel {Id= 2 ,UserName ="Iruka" ,UserRole = "Admin"},
                new UserViewModel {Id= 3, UserName ="Malsha" ,UserRole = "Applicant"},
               
            };
            return UserList;
        }

        public static List<JobApplicationAddViewModel> SeedJobApplication()
        {
            List<JobApplicationAddViewModel> UserList = new List<JobApplicationAddViewModel>
            {
                 new JobApplicationAddViewModel { JobStatus ="Interview" ,CompanyName="Virtusa",Position= "Engineer"},
                new JobApplicationAddViewModel {JobStatus ="Offer" ,CompanyName="HCL",Position= "EngineerDev",},
                new JobApplicationAddViewModel { JobStatus ="Rejected" ,CompanyName="CreativeSoftware",Position= "EngineerQA"},
                 new JobApplicationAddViewModel {JobStatus ="Offer" ,CompanyName ="DataCom" ,Position = "AssosiateEngineer"},
                new JobApplicationAddViewModel { JobStatus ="Interview" ,CompanyName ="Inivos" ,Position = "InternDev"},
                new JobApplicationAddViewModel { JobStatus ="Offer" ,CompanyName ="Virtusa" ,Position = "AssosiateEngineer"},
                 new JobApplicationAddViewModel { JobStatus ="Rejected" ,CompanyName ="Inivos" ,Position = "AssosiateEngineer"},
                new JobApplicationAddViewModel { JobStatus ="Offer" ,CompanyName ="HCL" ,Position = "InternDev"},
                new JobApplicationAddViewModel { JobStatus ="Interview" ,CompanyName ="HCL" ,Position = "BA"},
                new JobApplicationAddViewModel { JobStatus ="Rejected" ,CompanyName ="Virtusa" ,Position = "LeadEngineer"},

            };
            return UserList;
        }
    }
}
