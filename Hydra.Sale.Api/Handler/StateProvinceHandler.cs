using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class StateProvinceHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="stateProvinceService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IStateProvinceService stateProvinceService, GridDataBound dataGrid)
        {
            try
            {
                var result = await stateProvinceService.GetList(dataGrid);
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
        /// <param name="stateProvinceService"></param>
        /// <param name="stateProvinceId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetStateProvinceById(IStateProvinceService stateProvinceService, int stateProvinceId)
        {
            var result = await stateProvinceService.GetById(stateProvinceId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="stateProvinceService"></param>
        /// <param name="stateProvinceModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddStateProvince(ClaimsPrincipal userClaim, IStateProvinceService stateProvinceService, [FromBody] StateProvinceModel stateProvinceModel)
        {
            var result = await stateProvinceService.Add(stateProvinceModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="stateProvinceService"></param>
        /// <param name="stateProvinceModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateStateProvince(ClaimsPrincipal userClaim, IStateProvinceService stateProvinceService, [FromBody] StateProvinceModel stateProvinceModel)
        {
            var result = await stateProvinceService.Update(stateProvinceModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stateProvinceService"></param>
        /// <param name="stateProvinceId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteStateProvince(IStateProvinceService stateProvinceService, int stateProvinceId)
        {
            try
            {
                var result = await stateProvinceService.Delete(stateProvinceId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}