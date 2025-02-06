// <copyright file="SpecificationEvaluator.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Hydra.Kernel.Data.Extension
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<T> GetSpecifiedQuery<T>(this IQueryable<T> inputQuery, Specification<T> specification)
            where T : class
        {
            IQueryable<T> query = inputQuery.GetSpecifiedQuery((SpecificationBase<T>)specification);

            // Apply paging if enabled
            if (specification.Skip != null)
            {
                if (specification.Skip < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(specification.Skip), $"The value of {nameof(specification.Skip)} in {nameof(specification)} can not be negative.");
                }

                query = query.Skip((int)specification.Skip);
            }

            if (specification.Take != null)
            {
                if (specification.Take < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(specification.Take), $"The value of {nameof(specification.Take)} in {nameof(specification)} can not be negative.");
                }

                query = query.Take((int)specification.Take);
            }

            return query;
        }

        public static IQueryable<T> GetSpecifiedQuery<T>(this IQueryable<T> inputQuery, PaginationSpecification<T> specification)
            where T : class
        {
            if (inputQuery == null)
            {
                throw new ArgumentNullException(nameof(inputQuery));
            }

            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            if (specification.PageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageIndex), "The value of pageIndex must be greater than 0.");
            }

            if (specification.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageSize), "The value of pagePageSize must be greater than 0.");
            }

            IQueryable<T> query = inputQuery.GetSpecifiedQuery((SpecificationBase<T>)specification);

            // Apply paging if enabled
            int skip = (specification.PageIndex - 1) * specification.PageSize;

            query = query.Skip(skip).Take(specification.PageSize);

            return query;
        }

        public static IQueryable<T> GetSpecifiedQuery<T>(this IQueryable<T> inputQuery, SpecificationBase<T> specification)
            where T : class
        {
            if (inputQuery == null)
            {
                throw new ArgumentNullException(nameof(inputQuery));
            }

            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            IQueryable<T> query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Conditions != null && specification.Conditions.Any())
            {
                foreach (Expression<Func<T, bool>> specificationCondition in specification.Conditions)
                {
                    query = query.Where(specificationCondition);
                }
            }

            // modify the IQueryable using the specification's criteria expression
            if (specification.ConditionsByDynamic.Any())
            {
                foreach (var conditon in specification.ConditionsByDynamic)
                {
                    query = query.Where(conditon);
                }
            }

            // Includes all expression-based includes
            if (specification.Includes != null)
            {
                query = specification.Includes(query);
            }

            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                query = specification.OrderBy(query);
            }
            else if (specification.OrderByDynamic.Any())
            {
                foreach (var item in specification.OrderByDynamic)
                {
                    query = query.OrderBy(item.ColumnName + " " + item.SortDirection);
                }
            }

            return query;
        }

        public static IQueryable<T> GetSpecifiedQuery<T>(this IQueryable<T> inputQuery, SpecificationBaseDynamic<T> specification)
            where T : class
        {
            if (inputQuery == null)
            {
                throw new ArgumentNullException(nameof(inputQuery));
            }

            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            IQueryable<T> query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Conditions != null && specification.Conditions.Any())
            {
                foreach (string specificationCondition in specification.Conditions)
                {
                    query = query.Where(specificationCondition);
                }
            }


            // Apply ordering if expressions are set
            if (specification.OrderBys != null && specification.OrderBys.Any())
            {
                foreach (string order in specification.OrderBys)
                {
                    query = query.OrderBy(order);
                }
            }


            return query;
        }
    }
}
