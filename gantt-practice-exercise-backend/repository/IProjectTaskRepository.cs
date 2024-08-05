using gantt_practice_exercise_backend.Models;

namespace gantt_practice_exercise_backend.repository
{
    public interface IProjectTaskRepository
    {
        Task<ProjectTask> GetTask(string id);
        Task AddProjectTask(ProjectTask projectTask);
        Task<IEnumerable<ProjectTask>> GetAllProjectTask();
        Task UpdateProjectTask(ProjectTask projectTask);
        Task DeleteProjectTask(ProjectTask projectTask);
 

    }
}
