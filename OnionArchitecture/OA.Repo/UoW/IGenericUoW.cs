using System;
using System.Data.Entity;
using OA.Repo.Repository;

namespace OA.Repo.UoW
{
    public interface IGenericUoW
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        DbContextTransaction BeginTransaction();
        Int64 SaveChanges();
    }
}
