namespace RecycleCoin.UI.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        bool Commit();
    }
}