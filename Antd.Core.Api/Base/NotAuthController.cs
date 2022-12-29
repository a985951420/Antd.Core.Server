using Microsoft.AspNetCore.Authorization;

namespace Antd.Core.Api.Base
{
    /// <summary>
    /// 无需授权控制器
    /// </summary>
    [AllowAnonymous]
    public class NotAuthController : BaseController
    {
    }
}