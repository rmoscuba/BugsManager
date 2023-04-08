using BugsManager.Contexts;
using BugsManager.Interfaces;
using BugsManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugsManager.Repositories
{
    public class BugRepository : RepositoryBase<Bug>, IBugRepository
    {
        public BugRepository(DatabaseContext _DatabaseContext) : base(_DatabaseContext)
        {
        }
        public IEnumerable<Bug> GetAllBugs(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .OrderBy(b => b.CreationDate)
                    .ToList();
        }
        public IEnumerable<BugResultDTO> GetAllBugsByParams(BugQueryParams bugQueryParams, bool trackChanges)
        {
            return FindByCondition(
                    b => (b.ProjectId == bugQueryParams.ProjectId || bugQueryParams.ProjectId == null)
                    && (b.UserId == bugQueryParams.UserId || bugQueryParams.UserId == null)
                    && (bugQueryParams.StartDate <= b.CreationDate || bugQueryParams.StartDate == null)
                    && (b.CreationDate <= bugQueryParams.EndDate || bugQueryParams.EndDate == null), 
                    trackChanges)
                .Include(b => b.User)
                .Include(b => b.Project)
                .Select(b => BugResultDTO.Map(b))
                .ToList();
        }

        public void CreateBug(Bug project) => Create(project);
    }
}
