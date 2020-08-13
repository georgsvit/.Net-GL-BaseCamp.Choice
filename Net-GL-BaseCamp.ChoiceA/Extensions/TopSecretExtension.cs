using Microsoft.AspNetCore.Builder;
using Net_GL_BaseCamp.ChoiceA.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.ChoiceA.Extensions
{
    public static class TopSecretExtension
    {
        public static IApplicationBuilder UseTopSecret(this IApplicationBuilder app) => app.UseMiddleware<TopSecret>();
    }
}
