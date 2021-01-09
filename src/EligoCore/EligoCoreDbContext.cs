using EligoCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EligoCore
{
    public class EligoCoreDbContext<TContext> : DbContext, IUnitOfWork
        where TContext : EligoCoreDbContext<TContext>
    {
        IDbContextTransaction transaction;
        DbContext IUnitOfWork.Context => this;
        protected string ConnectionString { get; }

        protected EligoCoreDbContext()
        { }

        protected EligoCoreDbContext(DbContextOptions options)
            : base(options)
        { }

        protected EligoCoreDbContext(string connectionString)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        protected EligoCoreDbContext(IDataSource source)
            : this(source.GetConnectionString())
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        IEnumerable<TEntity> IUnitOfWork.GetAll<TEntity>(Func<TEntity, bool> predicate)
        {
            return Set<TEntity>()
                .NullSafeWhere(predicate)
                .ToList();
        }

        async Task<IEnumerable<TEntity>> IUnitOfWork.GetAllAsync<TEntity>(Func<TEntity, bool> predicate, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
                Set<TEntity>().NullSafeWhere(predicate).ToList());
        }

        IEnumerable<TEntity> IUnitOfWork.GetAll<TEntity>(ISpecification<TEntity> specification)
        {
            var query = GetSpecIQueryable(specification);

            return query
                .NullSafeWhere(specification.Criteria)
                .ToList();
        }

        async Task<IEnumerable<TEntity>> IUnitOfWork.GetAllAsync<TEntity>(ISpecification<TEntity> specification, CancellationToken cancellationToken)
        {
            var query = GetSpecIQueryable(specification);

            return await query
                .NullSafeWhere(specification.Criteria)
                .ToListAsync(cancellationToken);
        }

        TEntity IUnitOfWork.Get<TEntity>(Func<TEntity, bool> predicate)
        {
            return Set<TEntity>()
                .NullSafeWhere(predicate)
                .SingleOrDefault();
        }

        async Task<TEntity> IUnitOfWork.GetAsync<TEntity>(Func<TEntity, bool> predicate, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
                Set<TEntity>().NullSafeWhere(predicate).SingleOrDefault());
        }

        TEntity IUnitOfWork.Get<TEntity>(ISpecification<TEntity> specification)
        {
            var query = GetSpecIQueryable(specification);

            return query
                .NullSafeWhere(specification.Criteria)
                .SingleOrDefault();
        }

        async Task<TEntity> IUnitOfWork.GetAsync<TEntity>(ISpecification<TEntity> specification, CancellationToken cancellationToken)
        {
            var query = GetSpecIQueryable(specification);

            return await query
                .NullSafeWhere(specification.Criteria)
                .SingleOrDefaultAsync(cancellationToken);
        }

        TEntity IUnitOfWork.Find<TEntity>(params object[] keyValues)
        {
            return Find<TEntity>(keyValues);
        }

        async Task<TEntity> IUnitOfWork.FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken)
        {
            return await FindAsync<TEntity>(keyValues, cancellationToken);
        }

        TEntity IUnitOfWork.Add<TEntity>(TEntity entity)
        {
            return Add(entity).Entity;
        }

        void IUnitOfWork.Add<TEntity>(IEnumerable<TEntity> entities)
        {
            AddRange(entities);
        }

        async Task IUnitOfWork.AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
        {
            await AddAsync(entity, cancellationToken);
        }

        async Task IUnitOfWork.AddAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            await AddRangeAsync(entities, cancellationToken);
        }

        TEntity IUnitOfWork.Update<TEntity>(TEntity entity)
        {
            return Update(entity).Entity;
        }

        void IUnitOfWork.Update<TEntity>(IEnumerable<TEntity> entities)
        {
            UpdateRange(entities);
        }

        void IUnitOfWork.Remove<TEntity>(TEntity entity)
        {
            Remove(entity);
        }

        void IUnitOfWork.Remove<TEntity>(IEnumerable<TEntity> entities)
        {
            RemoveRange(entities);
        }

        int IUnitOfWork.SaveChanges()
        {
            return SaveChanges();
        }

        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await SaveChangesAsync(cancellationToken);
        }

        void IUnitOfWork.BeginTransaction()
        {
            transaction = Database.BeginTransaction();
        }

        void IUnitOfWork.Commit()
        {
            if (transaction != null)
                transaction.Commit();
        }

        void IUnitOfWork.Rollback()
        {
            if (transaction != null)
                transaction.Rollback();
        }

        public override void Dispose()
        {
            if (transaction != null)
                transaction.Dispose();

            base.Dispose();
        }

        private IQueryable<TEntity> GetSpecIQueryable<TEntity>(ISpecification<TEntity> spec)
            where TEntity : class, IAggregation
        {
            var includes = spec.Includes
                .Aggregate(Set<TEntity>().AsQueryable(),
                (current, include) => current.Include(include));

            var stringIncludes = spec.IncludeStrings
                .Aggregate(includes,
                (current, include) => current.Include(include));

            return stringIncludes;
        }
    }

    static class NullSafeExtensions
    {
        internal static IEnumerable<TEntity> NullSafeWhere<TEntity>(this IEnumerable<TEntity> source, Func<TEntity, bool> predicate = null)
        {
            var result = predicate == null ? source : source.Where(predicate);
            return result;
        }

        internal static IQueryable<TEntity> NullSafeWhere<TEntity>(this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate = null)
        {
            var result = predicate == null ? source : source.Where(predicate).AsQueryable();
            return result;
        }
    }
}
