namespace BugsManager.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        void Save();
    }
}
