using Hydra.Infrastructure.Data.Extension;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Domain;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Sale.Api.Services
{
    public class SearchTermService : ISearchTermService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public SearchTermService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<SearchTermModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<SearchTermModel>>();

            var list = await (from searchTerm in _queryRepository.Table<SearchTerm>()
                              select new SearchTermModel()
                              {
                                  Id = searchTerm.Id,
                                  Keyword = searchTerm.Keyword,
                                  Count = searchTerm.Count,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<SearchTermModel>> GetById(int id)
        {
            var result = new Result<SearchTermModel>();
            var searchTerm = await _queryRepository.Table<SearchTerm>().FirstOrDefaultAsync(x => x.Id == id);

            var searchTermModel = new SearchTermModel()
            {
                Id = searchTerm.Id,
                Keyword = searchTerm.Keyword,
                Count = searchTerm.Count,

            };
            result.Data = searchTermModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="searchTermModel"></param>
        /// <returns></returns>
        public async Task<Result<SearchTermModel>> Add(SearchTermModel searchTermModel)
        {
            var result = new Result<SearchTermModel>();
            try
            {
                bool isExist = await _queryRepository.Table<SearchTerm>().AnyAsync(x => x.Id == searchTermModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(searchTermModel.Id), "The Id already exist"));
                    return result;
                }
                var searchTerm = new SearchTerm()
                {
                    Keyword = searchTermModel.Keyword,
                    Count = searchTermModel.Count,

                };

                await _commandRepository.InsertAsync(searchTerm);
                await _commandRepository.SaveChangesAsync();

                searchTermModel.Id = searchTerm.Id;

                result.Data = searchTermModel;

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="searchTermModel"></param>
        /// <returns></returns>
        public async Task<Result<SearchTermModel>> Update(SearchTermModel searchTermModel)
        {
            var result = new Result<SearchTermModel>();
            try
            {
                var searchTerm = await _queryRepository.Table<SearchTerm>().FirstAsync(x => x.Id == searchTermModel.Id);
                if (searchTerm is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The SearchTerm not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<SearchTerm>().AnyAsync(x => x.Id != searchTermModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(searchTermModel.Id), "The Id already exist"));
                    return result;
                }
                searchTerm.Keyword = searchTermModel.Keyword;
                searchTerm.Count = searchTermModel.Count;

                _commandRepository.UpdateAsync(searchTerm);
                await _commandRepository.SaveChangesAsync();

                result.Data = searchTermModel;

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var searchTerm = await _queryRepository.Table<SearchTerm>().FirstOrDefaultAsync(x => x.Id == id);
            if (searchTerm is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The SearchTerm not found";
                return result;
            }

            _commandRepository.DeleteAsync(searchTerm);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}