using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _3._2
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
            double res = 0;
            app.Use(async (context, next) =>
            {
                double x = Math.PI;
                double sinx = Math.Sin(x);
                res = (2 * sinx * sinx + sinx - 1) / (2 * sinx * sinx - 3 * sinx + 1);

                await next.Invoke();
            });

            app.Run(async (context) => {
                await context.Response.WriteAsync($"(2 * sinx * sinx + sinx - 1) / (2 * sinx * sinx - 3 * sinx + 1) = {res}");
            });
        }
    }
}
