using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class CurrencyHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="currencyService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(ICurrencyService currencyService, GridDataBound dataGrid)
        {
            try
            {
                var result = await currencyService.GetList(dataGrid);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="currencyService"></param>
        /// <param name="currencyId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetCurrencyById(ICurrencyService currencyService, int currencyId)
        {
            var result = await currencyService.GetById(currencyId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="currencyService"></param>
        /// <param name="currencyModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddCurrency(ClaimsPrincipal userClaim, ICurrencyService currencyService, [FromBody] CurrencyModel currencyModel)
        {
            var result = await currencyService.Add(currencyModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="currencyService"></param>
        /// <param name="currencyModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateCurrency(ClaimsPrincipal userClaim, ICurrencyService currencyService, [FromBody] CurrencyModel currencyModel)
        {
            var result = await currencyService.Update(currencyModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="currencyService"></param>
        /// <param name="currencyId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteCurrency(ICurrencyService currencyService, int currencyId)
        {
            try
            {
                var result = await currencyService.Delete(currencyId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}