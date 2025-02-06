﻿using Hydra.Kernel.GeneralModels;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Hydra.Infrastructure.Logs
{
    public class UseErrorHandling
    {
        readonly RequestDelegate _next;

        public UseErrorHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var result = new Result();
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Errors.Add(new Error(ResultStatusEnum.ExceptionThrowed.Description(), ex.Message));
                result.Message = ex.Message; 
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(result));
            }
        }
    }
}
