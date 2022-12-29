using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antd.Core.Dto.Model
{
    /// <summary>
    /// 登录实体
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public LoginDto(string userName, string passWord)
        {
            this.UserName = userName;
            this.PassWord = passWord;
        }
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
    }
}