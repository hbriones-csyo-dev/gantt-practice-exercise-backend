using gantt_practice_exercise_backend.context;
using gantt_practice_exercise_backend.Models;
using gantt_practice_exercise_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace gantt_practice_exercise_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {

        private readonly IProjectTaskService _projectTaskService;
        private readonly ILogger<ProjectTaskController> _logger;
        public ProjectTaskController(IProjectTaskService projectTaskService, ILogger<ProjectTaskController> logger) 
        {
            _projectTaskService = projectTaskService;
            _logger = logger;
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
                _logger.LogError(ex.ToString());
                
                return StatusCode(500, "There is something wrong. Please Contact the admin");
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
                _logger.LogError(ex.ToString());
                return StatusCode(500, "There is something wrong. Please Contact the admin");
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
                _logger.LogError(ex.ToString());
                return StatusCode(500, "There is something wrong. Please Contact the admin");
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
                _logger.LogError(ex.ToString());
                return StatusCode(500, "There is something wrong. Please Contact the admin");
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
                _logger.LogError(ex.ToString());
                return StatusCode(500, "There is something wrong. Please Contact the admin");
            }
        }

    }
}
