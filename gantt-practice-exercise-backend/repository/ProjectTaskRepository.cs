using gantt_practice_exercise_backend.context;
using gantt_practice_exercise_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gantt_practice_exercise_backend.repository
{

    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly ClickHouseContext _context;
        
       
        public ProjectTaskRepository(ClickHouseContext context) 
        {
            _context = context;
        }

        public async Task AddProjectTask(ProjectTask projectTask)
        {
            _context.ProjectTasks.Add(projectTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectTask(ProjectTask projectTask)
        {

             _context.ProjectTasks.Remove(projectTask);
            await _context.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<ProjectTask>> GetAllProjectTask()
        {
            var projectTasks = await _context.ProjectTasks.ToListAsync();
            return projectTasks;
        }

        public async Task<ProjectTask> GetTask(string id)
        {
            var projectTask = await _context.ProjectTasks.Where(x => x.Id == id).SingleOrDefaultAsync();
            return projectTask;

        }

        public async Task UpdateProjectTask(ProjectTask projectTask)
        {
            //_context.ProjectTasks.Entry(projectTask).State = EntityState.Modified;
            //var data = _context.ProjectTasks.Entry(projectTask);
            //if (data != null) 
            //{
            //    data.State = EntityState.Detached;
            //}
            _context.ProjectTasks.Update(projectTask);
            await _context.SaveChangesAsync();
          _context.ProjectTasks.Entry(projectTask).State = EntityState.Detached;

        }

    }
}
