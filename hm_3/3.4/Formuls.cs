using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Formuls
{
    private readonly RequestDelegate next;

    public Formuls(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var id = context.Request.Query["id"];
        if (id == "1")
        {
            var x = 101.01;
            double ans = (1 + x * Math.Pow(2, x)) / (1 + x * Math.Pow(3, x));
            await context.Response.WriteAsync($"(1 + {x} * 2^{x}) / (1 + {x} * 3^{x}) = {ans}");
        }
        else if (id == "2")
        {
            var x = 200;
            double ans = (1 + x * Math.Pow(1.5, x)) / (1 + x * Math.Pow(3.2, x));
            await context.Response.WriteAsync($"(1 + {x} * 1.5^{x}) / (1 + {x} * 3.2^{x}) = {ans}");
        }
        else
        {
            await next.Invoke(context);
        }
    }
}