using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface ICurrencyService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<CurrencyModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<List<CurrencyModel>>> GetAllCurrencies();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<CurrencyModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <returns></returns>
        Task<Result<CurrencyModel>> Add(CurrencyModel currencyModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <returns></returns>
        Task<Result<CurrencyModel>> Update(CurrencyModel currencyModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}