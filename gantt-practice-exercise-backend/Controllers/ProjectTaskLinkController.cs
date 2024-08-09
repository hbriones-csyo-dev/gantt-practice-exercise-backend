using gantt_practice_exercise_backend.Models;
using gantt_practice_exercise_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace gantt_practice_exercise_backend.Controllers
{
    [Route("api/[controller]")]
    public class ProjectTaskLinkController : Controller
    {
        private readonly IProjectTaskLinkService _projectTaskLinkService;
        private readonly ILogger<ProjectTaskLinkController> _logger;
        public ProjectTaskLinkController(IProjectTaskLinkService projectTaskLinkService, ILogger<ProjectTaskLinkController> logger)
        {
            _projectTaskLinkService = projectTaskLinkService;
            _logger = logger;   
        }

        [HttpGet("GetAllProjectTaskLink")]
        public async Task<IActionResult> GetAllProjectTaskLinks()
        {
            try
            {
                var projectTaskLinks = await _projectTaskLinkService.GetAllProjectTaskLink();
                return Ok(projectTaskLinks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "There is something wrong. Please Contact the admin");
            }
        }

        [HttpGet("GetProjectTaskLink")]
        public async Task<IActionResult> GetTaskLink(string id)
        {
            try
            {
                var projectTaskLink = await _projectTaskLinkService.GetTaskLink(id);
                return Ok(projectTaskLink);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "There is something wrong. Please Contact the admin");
            }
        }

        [HttpPost("AddProjectTaskLink")]
        public async Task<IActionResult> AddProjectTaskLink([FromBody] List<ProjectTaskLink> projectTaskLinks)
        {
            try
            {
                await _projectTaskLinkService.AddProjectTaskLink(projectTaskLinks);
                return Ok();
            } catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "There is something wrong. Please Contact the admin");
            }
        }

        [HttpPatch("UpdateProjectTaskLink")]
        public async Task<IActionResult> UpdateProjectTaskLink([FromBody] List<ProjectTaskLink> projectTaskLinks) 
        {
            try
            {
                await _projectTaskLinkService.UpdateProjectTaskLink(projectTaskLinks);
                return Ok();
            } catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "There is something wrong. Please Contact the admin");
            }
        }


        [HttpDelete("DeleteProjectTaskLink")]
        public async Task<IActionResult> DeleteProjectTaskLink([FromBody] List<ProjectTaskLink> projectTaskLinks)
        {
            try
            {
                await _projectTaskLinkService.DeleteProjectTaskLink(projectTaskLinks);
                return Ok();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "There is something wrong. Please Contact the admin");
            }
        }


    }
}
