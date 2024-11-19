using Microsoft.AspNetCore.Mvc;
using Security.Utils;

namespace Security.Controllers;

public class NotFoundCustomMiddleware
{
    private readonly RequestDelegate _next;

    public NotFoundCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
        {
            //context.Response.ContentType = "application/json";
            var res = HttpUtils.CreateHttpResponse<ActionResult>(context.Request.Path, 404);
            await context.Response.WriteAsJsonAsync(res);
        }
    }
}