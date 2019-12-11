using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _3._3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/1", firstFormula);
            app.Map("/2", secondFormula);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(" Choose /1 or /2 ");
            });
        }

        private static void firstFormula(IApplicationBuilder app)
        {
            double x = 1230;
            double res = Math.Sin(x + 1) - Math.Sin(x);
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"sin({x + 1}) - (sin{x}) = {res}");
            });
        }

        private static void secondFormula(IApplicationBuilder app)
        {
            double x = 12312;
            double res = x * x - 2 * Math.Pow(x, 2/3) + 1 / x;
            app.Run(async (contex) =>
            {
                await contex.Response.WriteAsync($"{x}^2 - 2 * {x} ^ (2/3) + 1 / {x} = {res}");
            });
        }
    }
}
