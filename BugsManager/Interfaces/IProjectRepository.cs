using BugsManager.Models;
using System;
using System.Collections.Generic;

namespace BugsManager.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects(bool trackChanges);

        Project GetProjectById(Guid Id, bool trackChanges);

        void CreateProject(Project project);
    }
}
