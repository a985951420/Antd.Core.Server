using Microsoft.Extensions.Configuration;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// 配置
    /// </summary>
    public static class AppSettingExtensions
    {
        /// <summary>
        /// 配置
        /// </summary>
        private static IConfiguration? _config;
        /// <summary>
        /// init
        /// </summary>
        /// <param name="configuration"></param>
        public static void Register(IConfiguration configuration)
        {
            _config = configuration;
        }

        /// <summary>
        /// 读取指定节点的字符串
        /// </summary>
        /// <param name="sessions"></param>
        /// <returns></returns>
        public static string ReadAppSettings(params string[] sessions)
        {
            try
            {
                if (sessions.Any())
                {
                    return _config[string.Join(":", sessions)];
                }
            }
            catch
            {
                return "";
            }
            return "";
        }

        /// <summary>
        /// 读取实体信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <returns></returns>
        public static List<T> ReadAppSettings<T>(params string[] session)
        {
            List<T> list = new List<T>();
            _config.Bind(string.Join(":", session), list);
            return list;
        }
    }
}