using Antd.Core.Api.Base;
using Antd.Core.Dto;
using Antd.Core.Dto.Extensions;
using Antd.Core.Dto.Helper;
using Antd.Core.Dto.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antd.Core.Api.Controllers
{
    /// <summary>
    /// 授权
    /// </summary>
    public class AuthorizationController : NotAuthController
    {
        /// <summary>
        /// 登录 
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        public async Task<ResultDto<string>> Login(LoginDto model)
        {
            if (model == null)
                return await ResultTools.Error(string.Empty, "参数异常！");
            var jwt = new JWTExtensions();
            var token = jwt.GenerateToken(new AccountModel
            {
                UserName = model.UserName,
                PassWord = model.PassWord
            }, out DateTime outTime);
            var time = outTime - DateTime.Now;
            RedisHelper.Instance.StringSet(model.UserName, token, time);
            return await ResultTools.Ok(token);
        }
    }
}