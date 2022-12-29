using System.Text.Json;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// 小写
    /// </summary>
    public class JSONLowercaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToLowerInvariant();
    }
}