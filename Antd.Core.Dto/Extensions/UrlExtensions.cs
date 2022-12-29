using Microsoft.Extensions.DependencyInjection;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// url 转换小写
    /// </summary>
    public static class UrlExtensions
    {
        /// <summary>
        /// Url 全部小写
        /// </summary>
        public static void UrlLowerCase(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
        }
    }
}