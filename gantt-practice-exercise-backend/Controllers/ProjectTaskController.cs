using gantt_practice_exercise_backend.context;
using gantt_practice_exercise_backend.Models;
using gantt_practice_exercise_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gantt_practice_exercise_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {

        private readonly IProjectTaskService _projectTaskService;
        public ProjectTaskController(IProjectTaskService projectTaskService) 
        {
            _projectTaskService = projectTaskService;
        }



        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask([FromBody] List<ProjectTask> projectTasks)
        {
            try
            {

                await _projectTaskService.AddProjectTask(projectTasks);

                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetProjectTask")]
        public async Task<IActionResult> GetProjectTasks()
        {
            try
            {
                var result = await _projectTaskService.GetAllProjectTask();

                if (result == null) 
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetTask")]
        public async Task<IActionResult> GetTask(string id)
        {
            try
            {
                var task = await _projectTaskService.GetTask(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("UpdateTask")]
        public async Task<IActionResult> UpdateProjectTask([FromBody] IEnumerable<ProjectTask> projectTasks)
        {
            try
            {
                await _projectTaskService.UpdateProjectTask(projectTasks);

                return Ok();

            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
          

        }


        [HttpDelete("DeleteProjectTask")]
        public async Task<IActionResult> DeleteProjectTasks([FromBody] IEnumerable<ProjectTask> projectTasks) 
        {
            try 
            {
                await _projectTaskService.DeleteProjectTask(projectTasks);

                return Ok("Successfully deleted");
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
