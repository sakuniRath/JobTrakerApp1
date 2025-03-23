using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.DAL.Models
{
    public class JobApplication
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int JobId { get; set; }
        public int ApplicationUserId { get; set; }
        public string Status { get; set; }
        public DateTime DateApplied { get; set; }
        public virtual ApplicationUsers ApplicationUser { get; set; }
        public virtual Job Job { get; set; }

    }
}
