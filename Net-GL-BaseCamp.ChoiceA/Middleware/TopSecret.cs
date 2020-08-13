using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.ChoiceA.Middleware
{
    public class TopSecret
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        private string _path = "secret.secret";
        
        public TopSecret(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated && context.Request.Path.Value.Contains("secret.secret"))
            {
                PhysicalFileProvider provider = new PhysicalFileProvider(_env.WebRootPath);
                var fileInfo = provider.GetFileInfo(_path);
                await context.Response.SendFileAsync(fileInfo);
            } else
            {
                await _next(context);
            }
        }
    }
}
