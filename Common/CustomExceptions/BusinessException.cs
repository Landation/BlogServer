using System;

namespace Common.CustomExceptions
{
    public class BusinessException : Exception
    {
        public ResultCode ErrorCode { get; }
            public string ErrorMessage { get; }
            public BusinessException(ResultCode code, string message)
            {
                ErrorCode = code;
                ErrorMessage = message;
            }
            public static BusinessException USER_NOT_LOGIN = new BusinessException(ResultCode.NOTLOGIN, "user not login");

    }
}