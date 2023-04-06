using BugsManager.Contexts;
using BugsManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private DatabaseContext _databaseContext;
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;
        private IBugRepository _bugRepository;
        private IConfiguration _configuration;

        public RepositoryManager(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_databaseContext);
                return _userRepository;
            }
        }

        public IProjectRepository Project
        {
            get
            {
                if (_projectRepository == null)
                    _projectRepository = new ProjectRepository(_databaseContext);
                return _projectRepository;
            }
        }

        public IBugRepository Bug
        {
            get
            {
                if (_bugRepository == null)
                    _bugRepository = new BugRepository(_databaseContext);
                return _bugRepository;
            }
        }

        public void Save() => _databaseContext.SaveChanges();
    }
}
