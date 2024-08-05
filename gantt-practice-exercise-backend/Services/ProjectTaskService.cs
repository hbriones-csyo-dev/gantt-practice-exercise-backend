using gantt_practice_exercise_backend.context;
using gantt_practice_exercise_backend.Models;
using gantt_practice_exercise_backend.repository;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace gantt_practice_exercise_backend.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly ILogger<ProjectTaskService> _logger;

        public ProjectTaskService(IProjectTaskRepository projectTaskRepository, ILogger<ProjectTaskService> logger) 
        {
            _projectTaskRepository = projectTaskRepository;
            _logger = logger;
        }
        public async Task AddProjectTask(IEnumerable<ProjectTask> projectTasks)
        {
            try
            {
                foreach (var task in projectTasks)
                {
                    await _projectTaskRepository.AddProjectTask(task);
                }

            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }



        }

        public async Task DeleteProjectTask(IEnumerable<ProjectTask> projectTasks)
        {
            try
            {
                foreach (var task in projectTasks)
                {
                    await _projectTaskRepository.DeleteProjectTask(task);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        

        }

        public async Task<IEnumerable<ProjectTask>> GetAllProjectTask()
        {
            try
            {
                var result = await _projectTaskRepository.GetAllProjectTask();
                if (!result.Any())
                {
                    return null;
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
         

            
        }

        public async Task<ProjectTask> GetTask(string id)
        {
            try
            {
                var task = await _projectTaskRepository.GetTask(id);
                return task;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        
        }

        public async Task UpdateProjectTask(IEnumerable<ProjectTask> projectTask)
        {
            try
            {
                foreach (var task in projectTask)
                {
                    await _projectTaskRepository.UpdateProjectTask(task);
                }

            }
            catch (Exception ex) { 
            _logger.LogError(ex.Message);
              
                throw;
            }



        }

    }
}
