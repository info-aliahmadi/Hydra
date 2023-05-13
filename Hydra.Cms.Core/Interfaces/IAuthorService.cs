using Hydra.Cms.Core.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface IAuthorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<AuthorModel>> GetList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AuthorModel> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        Task<AuthorModel> Add(AuthorModel authorModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        Task<AuthorModel> Update(AuthorModel authorModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(int id);


    }
}
