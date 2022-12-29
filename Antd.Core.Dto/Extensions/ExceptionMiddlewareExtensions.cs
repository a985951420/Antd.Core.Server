using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Antd.Core.Dto.ExceptionExtension;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="app"></param>
        public static void UseException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Debug.WriteLine($"发生异常: {contextFeature.Error}");
                        var result = await ResultTools.Error("", contextFeature.Error.Message);
                        result.StatusCode = StatusCodes.Status500InternalServerError;

                        var serializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

                        var json = JsonConvert.SerializeObject(result, serializerSettings);
                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}