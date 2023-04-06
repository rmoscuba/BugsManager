using BugsManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BugsManager.Contexts
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options): base(options) {}

        public DbSet<User> Users { get; set; }
    }
}
