using BugsManager.Models;
using System.Collections.Generic;

namespace BugsManager.Interfaces
{
    public interface IBugRepository
    {
        IEnumerable<Bug> GetAllBugs(bool trackChanges);

        IEnumerable<BugResultDTO> GetAllBugsByParams(BugQueryParams bugQueryParams, bool trackChanges);

        void CreateBug(Bug bug);
    }
}
