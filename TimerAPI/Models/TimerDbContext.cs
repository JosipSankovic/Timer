using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace TimerAPI.Models
{
    public class TimerDbContext:DbContext
    {
        public TimerDbContext(DbContextOptions<TimerDbContext> options):base(options)
        {

        }

        public DbSet<TimerProjects> timerProject { get; set; }
    }
}
