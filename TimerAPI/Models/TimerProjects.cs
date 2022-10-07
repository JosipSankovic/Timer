using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimerAPI.Models
{
    public class TimerProjects
    {   [Key]
        public int ProjectId { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string ProjectName { get; set; }

        public DateTime ProjectStart { get; set; }

        public DateTime? ProjectStop { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Duration { get; set; }
        
    }
}
