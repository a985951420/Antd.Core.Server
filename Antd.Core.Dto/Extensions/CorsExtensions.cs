using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// 跨域处理
    /// </summary>
    public static class CorsExtensions
    {
        /// <summary>
        /// 跨域标记
        /// </summary>
        public static string CorsName = "Allow";
        /// <summary>
        /// 跨域设置
        /// </summary>
        public static void Cors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsName,
                                  policy =>
                                  {
                                      policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                                  });
            });
        }
        /// <summary>
        /// 引用跨域
        /// </summary>
        /// <returns></returns>
        public static IApplicationBuilder UseCorsAllow(this IApplicationBuilder app)
        {
            app.UseCors(CorsName);
            return app;
        }
    }
}