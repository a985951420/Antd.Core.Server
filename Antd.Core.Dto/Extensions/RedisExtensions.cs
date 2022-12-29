using Antd.Core.Dto.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// redis 扩展
    /// </summary>
    public static class RedisExtensions
    {
        /// <summary>
        /// 跨域设置
        /// </summary>
        public static void AddRedis(this IServiceCollection services)
        {
            var redisConnectionString = AppSettingExtensions.ReadAppSettings("Redis:redisConnectionString");
            var defaultKey = AppSettingExtensions.ReadAppSettings("Redis:defaultKey");
            RedisHelper.Register(redisConnectionString, defaultKey);
        }
    }
}