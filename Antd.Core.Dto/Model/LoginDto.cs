using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antd.Core.Dto.Model
{
    /// <summary>
    /// ��¼ʵ��
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// �û���
        /// </summary>
        public LoginDto(string userName, string passWord)
        {
            this.UserName = userName;
            this.PassWord = passWord;
        }
        public string UserName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string PassWord { get; set; }
    }
}