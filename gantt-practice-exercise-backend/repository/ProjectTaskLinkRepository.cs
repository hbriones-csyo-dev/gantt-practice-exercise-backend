using gantt_practice_exercise_backend.context;
using gantt_practice_exercise_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace gantt_practice_exercise_backend.repository
{

    public class ProjectTaskLinkRepository : IProjectTaskLinkRepository
    {
        private readonly ClickHouseContext _context;


        public ProjectTaskLinkRepository(ClickHouseContext context)
        {
            _context = context;
        }

        public async Task AddProjectTaskLink(ProjectTaskLink projectTaskLink)
        {
            _context.ProjectTaskLinks.Add(projectTaskLink);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectTaskLink(ProjectTaskLink projectTaskLink)
        {
            _context.ProjectTaskLinks.Remove(projectTaskLink);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectTaskLink>> GetAllProjectTaskLink()
        {
            var projectTaskLinks = await _context.ProjectTaskLinks.ToListAsync();
            return projectTaskLinks;

        }

        public async Task<ProjectTaskLink> GetTaskLink(string id)
        {
            var projectTaskLink = await _context.ProjectTaskLinks.Where(x => x.Id == id).SingleOrDefaultAsync();
            return projectTaskLink;
        }

        public async Task UpdateProjectTaskLink(ProjectTaskLink projectTaskLink)
        {
            _context.ProjectTaskLinks.Update(projectTaskLink);
            await _context.SaveChangesAsync();
        }
    }
}
