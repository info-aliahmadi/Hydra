using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface IAuthorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<Author>> IsExist(int authorId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<AuthorModel>>> GetList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<AuthorModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        Task<Result<AuthorModel>> Add(AuthorModel authorModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        Task<Result<AuthorModel>> Update(AuthorModel authorModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);


    }
}
