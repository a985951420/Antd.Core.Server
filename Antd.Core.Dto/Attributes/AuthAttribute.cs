using Antd.Core.Dto.Extensions;
using Antd.Core.Dto.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Antd.Core.Dto.Attributes
{
    /// <summary>
    /// 授权
    /// </summary>
    public class AuthFilter : IAsyncAuthorizationFilter
    {
        /// <summary>
        /// auth
        /// </summary>
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var anyAuth = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorization);

            if (anyAuth == false)
            {
                context.Result = await UnauthorizedResult_401();
                return;
            }
            var token = authorization.ToString();

            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = await UnauthorizedResult_401();
                return;
            }

            var jwt = new JWTExtensions();

            var session = jwt.ValidateToken(token);

            if (session == null)
            {
                context.Result = await UnauthorizedResult_401();
                return;
            }

            CurrentSessionHelper.Register(session);
        }
        /// <summary>
        /// 授权无效
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> UnauthorizedResult_401()
        {
            var result = await ResultTools.Error("", "无效授权信息！");
            result.StatusCode = StatusCodes.Status401Unauthorized;
            return new JsonResult(result)
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
    }
}