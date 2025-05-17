using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics.Contracts;

namespace StarWarsApi.Models
{
    public class ApiResult<T>
    {
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }

        public static ApiResult<T> SuccessResult(T data, List<string> errors = new List<string>)
        {
            return new ApiResult<T> { Success = true, StatusCode = 200, Data = data, Errors = errors };
        }

        public static ApiResult<T> Failure(List<string> errors)
        {
            return new ApiResult<T> { Success = false, StatusCode= 500, Data = default, Errors = errors};
        }



    }
}
