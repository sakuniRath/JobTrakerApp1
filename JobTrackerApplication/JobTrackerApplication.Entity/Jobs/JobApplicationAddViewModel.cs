using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.Entity.Jobs
{
    public class JobApplicationAddViewModel
    {
        public string JobStatus { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public int JobId { get; set; }

    }
}
