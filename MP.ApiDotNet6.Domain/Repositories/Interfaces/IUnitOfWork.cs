namespace MP.ApiDotNet6.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();

        Task Commit();

        Task Rollback();
    }
}