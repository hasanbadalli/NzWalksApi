using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CustomerApp.Middlewares
{
    public class RequestEditingMiddleware
    {
        private RequestDelegate _requestDelegate;

        public RequestEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path.ToString() == "/salam")
            {
                await context.Response.WriteAsync("Xos geldin Hesen");
                
            }
            else
            {
                await _requestDelegate.Invoke(context);
                
            }
           
        }
    }
}
