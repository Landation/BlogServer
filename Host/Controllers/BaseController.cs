using Common;
using Common.CustomExceptions;
using Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Host.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController:Controller
    {
        protected string UsId { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var key = "x-btcapi-usid";
            StringValues values = new StringValues("");
            if (context.HttpContext.Request.Headers.TryGetValue(key, out values))
            {
                var usid = values.FirstOrDefault();
                Guid result;
                if (!string.IsNullOrEmpty(usid) && Guid.TryParse(usid, out result))
                {
                    this.UsId = usid;
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

            if (!context.ExceptionHandled && context.Exception != null)
            {
                context.Result = Error(context.Exception);
                context.ExceptionHandled = true;
            }
        }

        [NonAction]
        protected JsonResult Result(ApiResponse<string> apiResponse, HttpStatusCode statusCode)
        {
            var result = new JsonResult(apiResponse);
            result.StatusCode = (int)statusCode;
            return result;
        }
        [NonAction]
        public override OkObjectResult Ok(object value)
        {
            var result = ApiResponse<object>.SUCCESS(value);
            return base.Ok(result);
        }
        [NonAction]
        protected JsonResult Error(Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            object response = null;
            //解析错误
            if (exception != null && exception is BusinessException)
            {
                statusCode = HttpStatusCode.BadRequest;
                var businessException = exception as BusinessException;
                response = ApiResponse<string>.BUSINESSERROR(businessException, "");
            }
            //未知异常
            else
            {
                response = ApiResponse<string>.ERROR(exception.Message, ResultCode.UNKNOW, "未知异常");
            }
            var result = new JsonResult(response);

            result.StatusCode = (int)statusCode;
            return result;
        }
        [NonAction]
        protected BadRequestObjectResult BadRequest(object error, string message)
        {
            var result = ApiResponse<object>.ERROR(error, ResultCode.BADREQUEST, message);
            return base.BadRequest(result);
        }
    }
}
