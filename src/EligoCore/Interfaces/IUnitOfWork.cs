using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EligoCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<TEntity, bool> predicate = null, CancellationToken cancellationToken = default)
            where TEntity : class, IAggregation;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
            where TEntity : class, IAggregation;

        Task<TEntity> GetAsync<TEntity>(Func<TEntity, bool> predicate = null, CancellationToken cancellationToken = default)
            where TEntity : class, IAggregation;

        Task<TEntity> GetAsync<TEntity>(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
            where TEntity : class, IAggregation;

        Task<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken = default)
            where TEntity : class, IAggregation;

        Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class, IAggregation;

        Task AddAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            where TEntity : class, IAggregation;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IEnumerable<TEntity> GetAll<TEntity>(Func<TEntity, bool> predicate = null)
            where TEntity : class, IAggregation;

        IEnumerable<TEntity> GetAll<TEntity>(ISpecification<TEntity> specification)
            where TEntity : class, IAggregation;

        TEntity Get<TEntity>(Func<TEntity, bool> predicate = null)
            where TEntity : class, IAggregation;

        TEntity Get<TEntity>(ISpecification<TEntity> specification)
            where TEntity : class, IAggregation;

        TEntity Find<TEntity>(params object[] keyValues)
            where TEntity : class, IAggregation;

        TEntity Add<TEntity>(TEntity entity)
            where TEntity : class, IAggregation;

        void Add<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IAggregation;

        TEntity Update<TEntity>(TEntity entity)
            where TEntity : class, IAggregation;

        void Update<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IAggregation;

        void Remove<TEntity>(TEntity entity)
            where TEntity : class, IAggregation;

        void Remove<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IAggregation;

        int SaveChanges();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
