using gantt_practice_exercise_backend.Models;
using gantt_practice_exercise_backend.repository;

namespace gantt_practice_exercise_backend.Services
{
    public class ProjectTaskLinkService : IProjectTaskLinkService
    {
        private readonly IProjectTaskLinkRepository _repository;
        private readonly ILogger<IProjectTaskLinkService> _logger;

        public ProjectTaskLinkService(IProjectTaskLinkRepository repository, ILogger<ProjectTaskLinkService> logger) 
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task AddProjectTaskLink(IEnumerable<ProjectTaskLink> projectTaskLinks)
        {
            try
            {
                foreach (var taskLink in projectTaskLinks)
                {
                    await _repository.AddProjectTaskLink(taskLink);
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
          
        }

        public async Task DeleteProjectTaskLink(IEnumerable<ProjectTaskLink> projectTaskLinks)
        {
            try 
            {
                foreach (var taskLink in projectTaskLinks)
                {
                    await _repository.DeleteProjectTaskLink(taskLink);
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
       
        }

        public async Task<IEnumerable<ProjectTaskLink>> GetAllProjectTaskLink()
        {
            try 
            {
                var projectTaskLinks = await _repository.GetAllProjectTaskLink();

                if (!projectTaskLinks.Any()) 
                {
                    return null;
                }
                return projectTaskLinks;
            }catch (Exception ex) 
            { 
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProjectTaskLink> GetTaskLink(string id)
        {
            try
            {
                var projectTaskLink = await _repository.GetTaskLink(id);
                return projectTaskLink;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateProjectTaskLink(IEnumerable<ProjectTaskLink> projectTaskLinks)
        {
            try 
            {
                foreach (var taskLink in projectTaskLinks) 
                {
                    await _repository.UpdateProjectTaskLink(taskLink);
                }
            }catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
