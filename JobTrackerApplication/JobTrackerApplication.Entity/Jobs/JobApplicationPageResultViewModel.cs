using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.Entity.Jobs
{
    public class JobApplicationPageResultViewModel<T>
    {
        public List<T> Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
    }
}
