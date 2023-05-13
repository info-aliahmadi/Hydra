// <copyright file="QueryRepository.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System.Data;
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Kernel.Interfaces.Data;

namespace Hydra.Infrastructure.Data
{
    public class CommandRepository : ICommandRepository
    {
        private readonly IEFCacheServiceProvider _cacheService;
        private readonly ApplicationDbContext _dbContext;

        public CommandRepository(ApplicationDbContext dbContext, IEFCacheServiceProvider cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(
            IsolationLevel isolationLevel = IsolationLevel.Unspecified,
            CancellationToken cancellationToken = default)
        {
            IDbContextTransaction dbContextTransaction = await _dbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
            return dbContextTransaction;
        }

        public void ResetContextState()
        {
            _dbContext.ChangeTracker.Clear();
        }
        public async Task<T> InsertAsync<T>(T entity, CancellationToken cancellationToken = default)
           where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntityEntry<T> entityEntry = await _dbContext.Set<T>().AddAsync(entity, cancellationToken).ConfigureAwait(false);

            return entity;
        }

        public async Task InsertAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
           where T : class
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            await _dbContext.Set<T>().AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
        }
        public async Task BulkInsertAsync<T>(IEnumerable<T> entities)
            where T : class
        {
            await _dbContext.BulkInsertAsync(entities, _cacheService);
        }

        public void UpdateAsync<T>(T entity, CancellationToken cancellationToken = default)
            where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Set<T>().Update(entity);
            
        }

        public void UpdateAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            where T : class
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _dbContext.Set<T>().UpdateRange(entities);
        }

        public void DeleteAsync<T>(T entity, CancellationToken cancellationToken = default)
            where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public void DeleteAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            where T : class
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _dbContext.Set<T>().RemoveRange(entities);
        }

        public Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql, cancellationToken);
        }

        public Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) => _dbContext.SaveChangesAsync(cancellationToken);

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}