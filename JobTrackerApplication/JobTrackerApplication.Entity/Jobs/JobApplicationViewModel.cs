using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.Entity.Jobs
{
    public class JobApplicationViewModel
    {
        public int Id { get; set; }
        public string JobStatus { get; set; }
        public DateTime DateApplied { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string ApplicationUser { get; set; }
        public int JobId { get; set; }
    }
}
