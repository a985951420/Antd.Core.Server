using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antd.Core.Dto.Model
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menus
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <value></value>
        public string? ViewCode { get; set; }
        /// <summary>
        /// 按钮
        /// </summary>
        /// <value></value>
        public string[]? Button { get; set; }
    }
}