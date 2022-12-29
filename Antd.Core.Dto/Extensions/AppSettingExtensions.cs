using Microsoft.Extensions.Configuration;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// ����
    /// </summary>
    public static class AppSettingExtensions
    {
        /// <summary>
        /// ����
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
        /// ��ȡָ���ڵ���ַ���
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
        /// ��ȡʵ����Ϣ
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