namespace Antd.Core.Dto;
/// <summary>
/// 返回结果
/// </summary>
public class ResultDto<TResult>
{
    /// <summary>
    /// 结果
    /// </summary>
    public bool Success { get; set; }
    /// <summary>
    /// 数据
    /// </summary>
    public TResult? Data { get; set; }
    /// <summary>
    /// 结果
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// 状态 CODE
    /// </summary>
    /// <value></value>
    public int StatusCode { get; set; } = 200;
}


/// <summary>
/// 返回结果
/// </summary>
public class ResultDto : ResultDto<bool>
{
    public ResultDto() { }
}

/// <summary>
/// 统一返回结果
/// </summary>
public static class ResultTools
{
    /// <summary>
    /// 返回成功
    /// </summary>
    /// <returns></returns>
    public static async Task<ResultDto> Ok()
    {
        return await Task.FromResult(new ResultDto { Success = true });
    }
    /// <summary>
    /// 返回成功
    /// </summary>
    /// <typeparam name="TResult">T</typeparam>
    /// <param name="values">values</param>
    /// <param name="message">消息</param>
    /// <returns></returns>
    public static async Task<ResultDto<TResult>> Ok<TResult>(TResult values, string message = "")
    {
        return await Task.FromResult(new ResultDto<TResult> { Success = true, Data = values, Message = message, StatusCode = 200 });
    }
    /// <summary>
    /// 错误返回
    /// </summary>
    /// <typeparam name="TResult">T</typeparam>
    /// <param name="value">Value</param>
    /// <param name="message">消息</param>
    /// <returns></returns>
    public static async Task<ResultDto<TResult>> Error<TResult>(TResult value, string message = "")
    {
        return await Task.FromResult(new ResultDto<TResult> { Success = false, Data = value, Message = message, StatusCode = 5000 });
    }
}