using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Hydra.Cms.Api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public AuthorService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_authorService"></param>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public async Task<Result<Author>> IsExist(int authorId)
        {
            var result = new Result<Author>();

            var author = await _queryRepository.Table<Author>().FirstOrDefaultAsync(x => x.Id == authorId);

            if (author is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Author not found";
                return result;
            }
            result.Data = author;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<AuthorModel>>> GetList()
        {
            var result = new Result<List<AuthorModel>>();
            result.Data = await _queryRepository.Table<Author>().Select(x => new AuthorModel()
            {
                Id = x.Id,
                UserId = x.UserId,
                UserName = x.User.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToListAsync();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<AuthorModel>> GetById(int id)
        {
            var result = new Result<AuthorModel>();
            var record = await _queryRepository.Table<Author>().Include(x => x.User).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var author = new AuthorModel()
            {
                Id = record!.Id,
                UserId = record.UserId,
                UserName = record.User.UserName,
                FirstName = record.FirstName,
                LastName = record.LastName
            };
            result.Data = author;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        public async Task<Result<AuthorModel>> Add(AuthorModel authorModel)
        {
            var result = new Result<AuthorModel>();
            var author = new Author()
            {
                UserId = authorModel.UserId,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName
            };
            await _commandRepository.InsertAsync(author);

            await _commandRepository.SaveChangesAsync();

            authorModel.Id = author.Id;

            result.Data = authorModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        public async Task<Result<AuthorModel>> Update(AuthorModel authorModel)
        {
            var result = new Result<AuthorModel>();
            var isExistResult = await IsExist(authorModel.Id);
            if (!isExistResult.Succeeded)
            {
                result.Data = authorModel;
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Author not found";
                return result;
            }
            var author = isExistResult.Data;

            author.FirstName = authorModel.FirstName;
            author.LastName = authorModel.LastName;

            _commandRepository.UpdateAsync(author);

            await _commandRepository.SaveChangesAsync();

            result.Data = authorModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var isExistResult = await IsExist(id);
            if (!isExistResult.Succeeded)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Author not found";
                return result;
            }

            _commandRepository.DeleteAsync(isExistResult.Data);

            await _commandRepository.SaveChangesAsync();

            return result;
        }
    }
}