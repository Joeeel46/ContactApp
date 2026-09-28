using ContactApp.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Framework.Data
{
    public interface IUnitOfWork : IDisposable
    {
        
        //IEnumerable<TEntity> Exec<TEntity>(string query, params object[] parameters);
        
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;

        //void BeginTransaction();

        //int Commit();

        Task<int> CommitAsync();

        //void Rollback();

        //void Dispose(bool disposing);
    }
}
