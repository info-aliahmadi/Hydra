using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Interface;
using Hydra.Infrastructure.Security.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Auth.Api.Handler
{
    public class UserHandler
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userService"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
             IUserService _userService, GridDataBound dataGrid)
        {
            try
            {
                var result = await _userService.GetList(dataGrid);

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
        /// <param name="_userService"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetListForSelect(
             IUserService _userService, [FromBody] string input)
        {
            try
            {
                var result = await _userService.GetListForSelect(input);

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
        /// <param name="_userService"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetListForSelectByIds(
             IUserService _userService, [FromBody] int[] userIds)
        {
            try
            {
                var result = await _userService.GetListForSelectByIds(userIds);

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
        /// <param name="_userService"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetUserById(
            IUserService _userService,
            int userId
            )
        {
            var result = await _userService.GetById(userId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userService"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddUser(
            IUserService _userService,
            [FromBody] UserModel userModel
            )
        {
            var result = await _userService.Add(userModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userService"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateUser(
            IUserService _userService,
            [FromBody] UserModel userModel
            )
        {
            var result = await _userService.Update(userModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userService"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteUser(
            IUserService _userService,
            int userId
            )
        {
            try
            {
                var result = await _userService.DeleteUser(userId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}
