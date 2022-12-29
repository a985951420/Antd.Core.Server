using Microsoft.Extensions.DependencyInjection;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// url ת��Сд
    /// </summary>
    public static class UrlExtensions
    {
        /// <summary>
        /// Url ȫ��Сд
        /// </summary>
        public static void UrlLowerCase(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
        }
    }
}