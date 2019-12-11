using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class ErrorHandlingMiddleware
{
    private RequestDelegate next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        await next.Invoke(context);
        if (context.Response.StatusCode == 402)
        {
            await context.Response.WriteAsync(" < 10!");
        }
        else if (context.Response.StatusCode == 403)
        {
            await context.Response.WriteAsync("Error!");
        }
    }
}