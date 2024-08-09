using gantt_practice_exercise_backend.Models;

namespace gantt_practice_exercise_backend.repository
{
    public interface IProjectTaskLinkRepository
    {
        Task<ProjectTaskLink> GetTaskLink(string id);
        Task AddProjectTaskLink(ProjectTaskLink projectTaskLink);
        Task<IEnumerable<ProjectTaskLink>> GetAllProjectTaskLink();
        Task UpdateProjectTaskLink(ProjectTaskLink projectTaskLink);
        Task DeleteProjectTaskLink(ProjectTaskLink projectTaskLink);
    }
}
