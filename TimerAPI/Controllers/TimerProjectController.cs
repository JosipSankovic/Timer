using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimerAPI.Models;
using TimerAPI.Repository;
namespace TimerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimerProjectController : ControllerBase
    {
        private readonly TimerProjectsRepository timerProjectsRepository;

        public TimerProjectController(TimerProjectsRepository timer)
        {
            timerProjectsRepository = timer;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            try
            {
                var projects = timerProjectsRepository.GetTimerProjects();
                return Ok(projects);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public IActionResult AddProject([FromForm] TimerProjects project)
        {
            if (project == null)
                return BadRequest();

            try
            {
                timerProjectsRepository.AddTimer(project);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdateProject([FromForm]TimerProjects project)
        {
            if (project == null)
                return BadRequest();
            try{
                timerProjectsRepository.UpdateTimer(project);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{projectId:int}")]
        public IActionResult DeleteProject(int projectId)
        {
            try
            {
                timerProjectsRepository.DeleteTimer(projectId);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
