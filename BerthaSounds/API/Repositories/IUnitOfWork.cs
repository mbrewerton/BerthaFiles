using System;
namespace API.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
    }
}
