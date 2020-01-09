using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace _3._7
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public interface IMessageSender
        {
            string Request(HttpContext contex, string text);
            void Send(HttpContext context, string key, string value);
        }

        class EmailMessageSender : IMessageSender // Сессии
        {
            public string Request(HttpContext context, string key)
            {
                var s = "EMPTY";
                if (context.Session.Keys.Contains(key))
                {
                    s = context.Session.GetString(key);
                }

                return s;
            }

            public void Send(HttpContext context, string key, string value)
            {
                context.Session.SetString(key, value);
            }
        }

        public class SmsMessageSender : IMessageSender // Куки
        {
            public string Request(HttpContext context, string key)
            {
                string s;
                if (context.Request.Cookies.TryGetValue(key, out s))
                {
                    return s;
                }

                return "EMPTY";
            }

            public void Send(HttpContext context, string key, string value)
            {
                try
                {
                    context.Response.Cookies.Append(key, value);
                }
                 catch(Exception e)
                {
                    Console.WriteLine("AAAAAAAAAAAAAA" + e.ToString() + "AAAAAAAAAAAAAA");
                }
            }
        }

        public class MessageService
        {
            public void Send(IMessageSender Im, HttpContext context, string key, string value)
            {
                Im.Send(context, key, value);
            }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            IMessageSender email = new EmailMessageSender(); //session
            IMessageSender sms = new SmsMessageSender(); //cookies

            var msg = new MessageService();

            string s = "1010";
            string key = s;
            string value = s;

            app.Run(async (context) =>
            {
                var emailString = email.Request(context, key);
                var smsString = sms.Request(context, key);

                msg.Send(sms, context, key, value);
                msg.Send(email, context, key, value);

                await context.Response.WriteAsync(emailString + '\n' + smsString);

            });
        }
    }
}
