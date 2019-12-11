using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class RoutingMiddleware
{
    private RequestDelegate next;
    public RoutingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var id = context.Request.Query["id"];
        try{
            System.Int32.Parse(id);
        }
        catch
        {
            context.Response.StatusCode = 403;
            return;
        }
        
        if (System.Int32.Parse(id) >= 10)
        {
            await context.Response.WriteAsync("" + System.Int32.Parse(id));
        }
        else
        {
            context.Response.StatusCode = 403;
        }
    }
}
