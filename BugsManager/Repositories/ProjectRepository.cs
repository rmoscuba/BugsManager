using BugsManager.Contexts;
using BugsManager.Interfaces;
using BugsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugsManager.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(DatabaseContext _DatabaseContext) : base(_DatabaseContext)
        {
        }
        public IEnumerable<Project> GetAllProjects(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .OrderBy(c => c.Name)
                    .ToList();
        }
        public Project GetProjectById(Guid Id, bool trackChanges)
        {

            return FindByCondition(u => u.Id == Id, trackChanges)
                    .FirstOrDefault();
        }

        public void CreateProject(Project project) => Create(project);
    }
}
