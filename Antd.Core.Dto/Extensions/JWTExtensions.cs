using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Antd.Core.Dto.ExceptionExtension;
using Antd.Core.Dto.Model;
using Microsoft.IdentityModel.Tokens;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// JWT扩展
    /// </summary>
    public class JWTExtensions
    {
        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        public string GenerateToken(AccountModel user, out DateTime time)
        {
            if (user == null)
                throw new BusinessException("参数不合法！");

            time = DateTime.UtcNow.AddDays(1);

            var secret = AppSettingExtensions.ReadAppSettings("JWTSecret");
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Name", user.UserName) }),
                Expires = time,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}