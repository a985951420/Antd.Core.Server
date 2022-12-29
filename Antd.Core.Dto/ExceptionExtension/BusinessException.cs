using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antd.Core.Dto.ExceptionExtension
{
    /// <summary>
    /// 业务异常
    /// </summary>
    public class BusinessException : Exception
    {
        /// <summary>
        /// init
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <returns></returns>
        public BusinessException(string message) : base(message)
        {
        }
    }
}