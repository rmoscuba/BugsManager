using BugsManager.Contexts;
using BugsManager.Interfaces;
using BugsManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace BugsManager.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext _DatabaseContext) : base(_DatabaseContext)
        {
        }
        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .OrderBy(c => c.Name)
                    .ToList();
        }
        public User GetUserByUserNameAndPassWord(string UserName, string PassWord, bool trackChanges)
        {

            return FindByCondition(u => u.UserName == UserName && u.PassWord == PassWord, trackChanges)
                    .FirstOrDefault();
        }

        public void CreateUser(User user) => Create(user);
    }
}
