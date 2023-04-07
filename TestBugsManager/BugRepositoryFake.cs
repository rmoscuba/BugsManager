using BugsManager.Interfaces;
using BugsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestBugsManager
{
    class BugRepositoryFake : IBugRepository
    {
        private readonly List<Bug> _bugs;

        public BugRepositoryFake()
        {
            _bugs = new List<Bug>()
            {
                new Bug() { 
                        Id = new Guid("92d7d5a3-fcd7-4574-b5c3-8ca70289f948"),
                        ProjectId = new Guid("b5d21e01-ae4d-414a-aa38-11e63e307025"),
                        UserId = new Guid("3ca8c63c-b419-4587-a2b4-2cb91126dd68"),
                        Description = "Send to bacth does not create a file",
                        CreationDate = DateTime.Parse("2023-04-06")
                    },
                new Bug() {
                        Id = new Guid("48e22492-aac6-4a61-b439-6e09bc09d86b"),
                        ProjectId = new Guid("b5d21e01-ae4d-414a-aa38-11e63e307025"),
                        UserId = new Guid("3ca8c63c-b419-4587-a2b4-2cb91126dd68"),
                        Description = "The API gateway endpoint is not accesible",
                        CreationDate = DateTime.Parse("2023-04-07")
                    },
                new Bug() {
                        Id = new Guid("9e1ffca3-927a-4562-9472-7ecaca2f3350"),
                        ProjectId = new Guid("b5d21e01-ae4d-414a-aa38-11e63e307025"),
                        UserId = new Guid("10f05c1b-3916-43e9-8425-153eeb9da0b7"),
                        Description = "The query is not executed",
                        CreationDate = DateTime.Parse("2023-04-08")
                    },
                new Bug() {
                        Id = new Guid("a601cb08-143b-48a3-83db-24b72901e6b8"),
                        ProjectId = new Guid("147528c3-f1ea-4768-bdb7-fa05c2437990"),
                        UserId = new Guid("10f05c1b-3916-43e9-8425-153eeb9da0b7"),
                        Description = "The file is not saved in the ftp",
                        CreationDate = DateTime.Parse("2023-04-09")
                    },
                new Bug() {
                        Id = new Guid("92d7d5a3-fcd7-4574-b5c3-8ca70289f948"),
                        ProjectId = new Guid("147528c3-f1ea-4768-bdb7-fa05c2437990"),
                        UserId = new Guid("3ca8c63c-b419-4587-a2b4-2cb91126dd68"),
                        Description = "The send button does not work",
                        CreationDate = DateTime.Parse("2023-04-10")
                    }
            };
        }

        public void CreateBug(Bug bug)
        {
            bug.Id = Guid.NewGuid();
            _bugs.Add(bug);
        }

        IEnumerable<Bug> IBugRepository.GetAllBugs(bool trackChanges)
        {
            return _bugs;
        }

        IEnumerable<BugResultDTO> IBugRepository.GetAllBugsByParams(BugQueryParams bugQueryParams, bool trackChanges)
        {
            return _bugs.Where(b => (b.ProjectId == bugQueryParams.ProjectId || bugQueryParams.ProjectId == null)
                    && (b.UserId == bugQueryParams.UserId || bugQueryParams.UserId == null)
                    && (bugQueryParams.StartDate <= b.CreationDate || bugQueryParams.StartDate == null)
                    && (b.CreationDate <= bugQueryParams.EndDate || bugQueryParams.EndDate == null))
                .Select(b => { 
                    b.User = new User() {Name = "Pepe"}; 
                    return BugResultDTO.Map(b); 
                })
                .ToList();
        }
    }
}
