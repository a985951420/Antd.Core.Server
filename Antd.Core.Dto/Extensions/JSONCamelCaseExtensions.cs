using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// 返回结果小写
    /// </summary>
    public static class JSONCamelCaseExtensions
    {
        /// <summary>
        /// Url 全部小写
        /// </summary>
        public static void JsonCamelCase(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = new JsonLowercaseNamingPolicy();
                });
        }
    }
}
