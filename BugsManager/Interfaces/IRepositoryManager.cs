namespace BugsManager.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }

        IProjectRepository Project { get; }

        void Save();
    }
}
