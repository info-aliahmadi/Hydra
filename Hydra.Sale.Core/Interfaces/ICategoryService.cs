using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface ICategoryService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<List<CategoryModel>>> GetList();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<CategoryModel>>> GetHierarchy();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<CategoryModel>>> GetListForSelect();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<CategoryModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        Task<Result<CategoryModel>> Add(CategoryModel categoryModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        Task<Result<CategoryModel>> Update(CategoryModel categoryModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}