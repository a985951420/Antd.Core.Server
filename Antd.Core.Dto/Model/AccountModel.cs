using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antd.Core.Dto.Model
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class AccountModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
    }
}