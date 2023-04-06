namespace BugsManager.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }

        IProjectRepository Project { get; }

        IBugRepository Bug { get; }

        void Save();
    }
}
