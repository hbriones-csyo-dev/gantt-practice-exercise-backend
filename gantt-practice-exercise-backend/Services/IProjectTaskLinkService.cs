using gantt_practice_exercise_backend.Models;

namespace gantt_practice_exercise_backend.Services
{
    public interface IProjectTaskLinkService
    {
        Task<ProjectTaskLink> GetTaskLink(string id);
        Task AddProjectTaskLink(IEnumerable<ProjectTaskLink> projectTaskLinks);
        Task<IEnumerable<ProjectTaskLink>> GetAllProjectTaskLink();
        Task UpdateProjectTaskLink(IEnumerable<ProjectTaskLink> projectTaskLinks);
        Task DeleteProjectTaskLink(IEnumerable<ProjectTaskLink> projectTaskLinks);

    }
}
