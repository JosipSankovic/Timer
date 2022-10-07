using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimerAPI.Models;
namespace TimerAPI.Repository
{
    public class TimerProjectsRepository
    {
        private readonly TimerDbContext _timerDbContext;

        public TimerProjectsRepository(TimerDbContext timerDb)
        {
            _timerDbContext = timerDb;
        }

        public List<TimerProjects> GetTimerProjects()
        {

            return _timerDbContext.timerProject.ToList();
        }
        public TimerProjects GetProject(int projectId)
        {
            return _timerDbContext.timerProject.FirstOrDefault(x => x.ProjectId.Equals(projectId));
        }

        public void AddTimer(TimerProjects timer)
        {
            if (timer != null)
            {
                _timerDbContext.Add(timer);
                _timerDbContext.SaveChanges();
            }
        }

        public void UpdateTimer(TimerProjects timer)
        {
            var timerForUpdate = GetProject(timer.ProjectId);
            string passedTime = null;
            if (timer.ProjectStop != null && timerForUpdate.ProjectStart != null)
            {
                passedTime = $"{(timer.ProjectStop - timerForUpdate.ProjectStart)?.Hours.ToString()} h:{(timer.ProjectStop - timerForUpdate.ProjectStart)?.Minutes.ToString()} m";

            }
            
           
                
            else
            {
                
            }
            if (timerForUpdate != null){
                timerForUpdate.ProjectName = timer.ProjectName;
                timerForUpdate.ProjectStop = timer.ProjectStop;
                timerForUpdate.Duration = passedTime;  

            }
            _timerDbContext.SaveChanges();
        }

    }
}
