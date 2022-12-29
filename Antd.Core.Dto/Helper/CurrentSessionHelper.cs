using Antd.Core.Dto.Model;

namespace Antd.Core.Dto.Helper
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    public class CurrentSessionHelper
    {
        /// <summary>
        /// 系统当前用户
        /// </summary>
        private CurrentSessionHelper() { }
        public AccountModel? User { get; private set; } = null;

        public static CurrentSessionHelper Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        static object _lock_value = new object();
        /// <summary>
        /// user info
        /// </summary>
        static AccountModel? _value;
        public static void Register(AccountModel value)
        {
            lock (_lock_value)
            {
                if (_value != null)
                    _value = value;
            }
        }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly CurrentSessionHelper instance = new CurrentSessionHelper() { User = _value };
        }
    }
}