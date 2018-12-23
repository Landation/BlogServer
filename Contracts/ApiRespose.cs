using Common;
using Common.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class ApiResponse<T>
    {
        public ResultCode code { get; set; }
        public string message { get; set; }
        public T data { get; set; }

        public static ApiResponse<T> SUCCESS(T data) => new ApiResponse<T> { code = ResultCode.SUCCESS, message = "success", data = data };

        public static ApiResponse<T> ERROR(T data, ResultCode code, string message) => new ApiResponse<T> { code = code, message = message, data = data };

        public static ApiResponse<T> BUSINESSERROR(BusinessException exception, T data) => new ApiResponse<T> { code = exception.ErrorCode, message = exception.ErrorMessage, data = data };
    }
}
