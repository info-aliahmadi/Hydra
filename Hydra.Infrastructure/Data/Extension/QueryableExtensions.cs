// <copyright file="QueryableExtensions.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>


using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Hydra.Kernel.Extensions;

namespace Hydra.Infrastructure.Data.Extension
{
    /// <summary>
    /// Contains <see cref="Queryable"/> extension methods for paginated list.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pagePageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source,
            int pageIndex,
            int pagePageSize,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex), "The value of pageIndex must be greater than 0.");
            }

            if (pagePageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pagePageSize), "The value of pagePageSize must be greater than 0.");
            }

            long count = await source.LongCountAsync(cancellationToken);

            int skipe = (pageIndex - 1) * pagePageSize;

            List<T> items = await source.Skip(skipe).Take(pagePageSize).ToListAsync(cancellationToken);

            PaginatedList<T> paginatedList = new PaginatedList<T>(items, count, pageIndex, pagePageSize);
            return paginatedList;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="source"></param>
       /// <param name="pageIndex"></param>
       /// <param name="pagePageSize"></param>
       /// <param name="cancellationToken"></param>
       /// <returns></returns>
       /// <exception cref="ArgumentNullException"></exception>
       /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IQueryable<T> ToPaginatedQuery<T>(
            this IQueryable<T> source,
            int pageIndex,
            int pagePageSize,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex), "The value of pageIndex must be greater than 0.");
            }

            if (pagePageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pagePageSize), "The value of pagePageSize must be greater than 0.");
            }

            int skip = (pageIndex) * pagePageSize;

            IQueryable<T> query = source.Skip(skip).Take(pagePageSize);

            return query;
        }
        /// <summary>
        /// Convert the <see cref="IQueryable{T}"/> into paginated list.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="IQueryable"/>.</typeparam>
        /// <param name="source">The type to be extended.</param>
        /// <param name="specification">An object of <see cref="PaginationSpecification{T}"/>.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task"/> of <see cref="PaginatedList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="specification"/> is smaller than 1.</exception>
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source,
            PaginationSpecification<T> specification,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            if (specification.PageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageIndex), $"The value of {nameof(specification.PageIndex)} must be greater than 0.");
            }

            if (specification.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageSize), $"The value of {nameof(specification.PageSize)} must be greater than 0.");
            }

            IQueryable<T> countSource = source;

            long count = await countSource.LongCountAsync(cancellationToken);

            source = source.GetSpecifiedQuery(specification);
            List<T> items = await source.ToListAsync(cancellationToken);

            PaginatedList<T> paginatedList = new PaginatedList<T>(items, count, specification.PageIndex, specification.PageSize);
            return paginatedList;
        }

        /// <summary>
        /// Convert the <see cref="IQueryable{T}"/> into paginated list.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="IQueryable"/>.</typeparam>
        /// <param name="source">The type to be extended.</param>
        /// <param name="specification">An object of <see cref="PaginationSpecification{T}"/>.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task"/> of <see cref="PaginatedList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="specification"/> is smaller than 1.</exception>
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source,
            GridDataBound filter,
            PaginationSpecification<T> specification,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            if (specification.PageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageIndex), $"The value of {nameof(specification.PageIndex)} must be greater than 0.");
            }

            if (specification.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageSize), $"The value of {nameof(specification.PageSize)} must be greater than 0.");
            }


            source = source.GetSpecifiedQuery(new SpecificationBaseDynamic<T>()
            {
                Conditions = filter.Conditions,
                OrderBys = filter.Orders
            });

            IQueryable<T> countSource = source;

            long count = await countSource.LongCountAsync(cancellationToken);

            source = source.GetSpecifiedQuery(specification);
            List<T> items = await source.ToListAsync(cancellationToken);

            PaginatedList<T> paginatedList = new PaginatedList<T>(items, count, specification.PageIndex, specification.PageSize);
            return paginatedList;
        }
        /// <summary>
        /// Convert the <see cref="IQueryable{T}"/> into paginated list.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="IQueryable"/>.</typeparam>
        /// <param name="source">The type to be extended.</param>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>Returns <see cref="Task"/> of <see cref="PaginatedList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="specification"/> is smaller than 1.</exception>
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source,
            GridDataBound filter,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (source == null)
            {
                return new PaginatedList<T>(new List<T>(), 0, filter.PageIndex, filter.PageSize);

            }

            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (filter.PageIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(filter.PageIndex), $"The value of {nameof(filter.PageIndex)} must be greater than 0.");
            }

            if (filter.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(filter.PageSize), $"The value of {nameof(filter.PageSize)} must be greater than 0.");
            }
            source = source.GetSpecifiedQuery(new SpecificationBaseDynamic<T>()
            {
                Conditions = filter.Conditions,
                OrderBys = filter.Orders
            });

            var count = await source.LongCountAsync(cancellationToken);

            var items = await source.ToPaginatedQuery(filter.PageIndex, filter.PageSize).ToListAsync(cancellationToken: cancellationToken);

            var paginatedList = new PaginatedList<T>(items, count, filter.PageIndex, filter.PageSize);
            return paginatedList;

        }
    }
}
