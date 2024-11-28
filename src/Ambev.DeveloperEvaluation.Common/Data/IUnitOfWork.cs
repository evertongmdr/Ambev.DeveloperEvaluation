namespace Ambev.DeveloperEvaluation.Common.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}