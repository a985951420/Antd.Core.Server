using Antd.Core.Api.Base;
using Antd.Core.Dto;
using Antd.Core.Dto.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antd.Core.Api.Controllers
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class SystemController : AuthController
    {
        /// <summary>
        /// 系统菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultDto<List<Menus>>> Menulist()
        {
            var menus = new List<Menus>
            {
                new Menus{
                    ViewCode = "View_Sys"
                },
                new Menus{
                    ViewCode = "View_Sys_User"
                },
                new Menus{
                    ViewCode = "View_Sys_Authinfo"
                },
                new Menus{
                    ViewCode = "View_Sys_Roleinfo"
                }
            };
            return await ResultTools.Ok(menus);
        }
    }
}