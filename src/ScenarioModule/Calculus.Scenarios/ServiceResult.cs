namespace Calculus.Scenarios;

public class ServiceResult
{
  public string? Message { get; set; }

  public ServiceResult(string? message = null)
  {
    Message = message;
  }
}

public class ServiceResult<T> : ServiceResult
{
  public T? Data { get; set; }

  public ServiceResult(string? message = null, T? data = default) : base(message)
  {
    Data = data;
  }
}
