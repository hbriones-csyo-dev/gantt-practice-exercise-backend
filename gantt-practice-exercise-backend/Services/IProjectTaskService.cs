
using gantt_practice_exercise_backend.Models;

namespace gantt_practice_exercise_backend.Services
{
    public interface IProjectTaskService
    {
        Task<ProjectTask> GetTask(string id);
        Task AddProjectTask(IEnumerable<ProjectTask> projectTasks);
        Task<IEnumerable<ProjectTask>> GetAllProjectTask();
        Task UpdateProjectTask(IEnumerable<ProjectTask> projectTasks);
        Task DeleteProjectTask(IEnumerable<ProjectTask> projectTasks);
     

    }
}
