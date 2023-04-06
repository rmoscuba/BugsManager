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

        public void Save() => _databaseContext.SaveChanges();
    }
}
