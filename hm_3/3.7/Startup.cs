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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public interface IMessageSender
        {
            string Request(string text);
            void Send(string text);
        }

        class EmailMessageSender : IMessageSender
        {
            public string Request(HttpContext context, string text)
            {
                //context.Request // ѕередавать это, в нЄм иметь дело с куки
                return text;
            }

            public void Send(string text)
            {
                text = "21";
            }
        }

        public class SmsMessageSender : IMessageSender
        {
            public string Request(string text)
            {
                return text;
            }

            public void Send(string text)
            {

            }
        }

        public class MessageService
        {
            IMessageSender Im;
            public MessageService(IMessageSender Im)
            {
                this.Im = Im;
            }

            public void Send(string text)
            {
                Im.Send(text);
            }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IMessageSender sms = new SmsMessageSender(app);
        }
    }
}
