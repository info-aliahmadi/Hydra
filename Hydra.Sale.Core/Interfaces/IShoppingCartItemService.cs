using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IShoppingCartItemService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ShoppingCartItemModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ShoppingCartItemModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shoppingCartItemModel"></param>
        /// <returns></returns>
        Task<Result<ShoppingCartItemModel>> Add(ShoppingCartItemModel shoppingCartItemModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shoppingCartItemModel"></param>
        /// <returns></returns>
        Task<Result<ShoppingCartItemModel>> Update(ShoppingCartItemModel shoppingCartItemModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}