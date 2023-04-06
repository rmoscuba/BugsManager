using BugsManager.Contexts;
using BugsManager.Interfaces;
using BugsManager.Models;
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
        public IEnumerable<Bug> GetAllBugsByParams(BugQueryParams bugQueryParams, bool trackChanges)
        {
            return FindByCondition(
                    // TODO: Fix this query
                    b => b.ProjectId == bugQueryParams.ProjectId
                    && b.UserId == bugQueryParams.UserId
                    && bugQueryParams.StartDate <= b.CreationDate
                    && b.CreationDate <= bugQueryParams.EndDate, 
                    trackChanges);
        }

        public void CreateBug(Bug project) => Create(project);
    }
}
