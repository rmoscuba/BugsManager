using BugsManager.Interfaces;
using System;

namespace TestBugsManager
{
    class RepositoryManagerFake : IRepositoryManager
    {
        public IUserRepository User => throw new NotImplementedException();

        public IProjectRepository Project => throw new NotImplementedException();

        public IBugRepository Bug => new BugRepositoryFake();

        public void Save() {}
    }
}
