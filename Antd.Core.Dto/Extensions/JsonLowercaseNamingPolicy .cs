using System.Text.Json;

namespace Antd.Core.Dto.Extensions
{
    /// <summary>
    /// 小写
    /// </summary>
    public class JsonLowercaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToLowerInvariant();
    }
}