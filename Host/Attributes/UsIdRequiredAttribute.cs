using Common;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Host.Attributes
{
    public class UsIdRequiredAttribute :Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var key = "x-btcapi-usid";
            StringValues values = new StringValues("");
            if (!context.HttpContext.Request.Headers.TryGetValue(key, out values))
            {
                var data = ApiResponse<string>.ERROR("用户没有登陆", ResultCode.NOTLOGIN, "");
                var result = new JsonResult(data);
                result.StatusCode =(int)HttpStatusCode.Forbidden;
                context.Result = result;
            }





        }
    }
}
