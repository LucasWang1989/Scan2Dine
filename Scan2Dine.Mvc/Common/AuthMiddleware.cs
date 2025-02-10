namespace Scan2Dine.Mvc.Common;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Do not intercept login page and static resources.
        var path = context.Request.Path.ToString().ToLower();
        if (path.Contains("admin/login") 
            || path.Contains("/admin/css") 
            || path.Contains("/admin/icons") 
            || path.Contains("/admin/images") 
            || path.Contains("/admin/js") 
            || path.Contains("/admin/vendor") 
            )
        {
            await _next(context);
            return;
        }

        // Read user's information from Session
        var user = context.Session.GetString("User");

        // Authentication failed
        if (string.IsNullOrEmpty(user))
        {
            context.Response.Redirect("Admin/Login");
            return;
        }

        // Continue process requests
        await _next(context);
    }
}
