using Antd.Core.Dto.Helper;
using Antd.Core.Dto.Model;

namespace Antd.Core.Api.Base
{
    /// <summary>
    /// 授权控制器
    /// </summary>
    public class AuthController : BaseController
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        /// <value></value>
        public AccountModel? CurrentUser
        {
            get
            {
                return CurrentSessionHelper.Instance.User ?? null;
            }
        }
    }
}