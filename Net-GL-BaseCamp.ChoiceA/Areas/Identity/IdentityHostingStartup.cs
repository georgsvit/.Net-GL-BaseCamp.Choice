using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net_GL_BaseCamp.ChoiceA.Data;
using Net_GL_BaseCamp.ChoiceA.Models;

[assembly: HostingStartup(typeof(Net_GL_BaseCamp.ChoiceA.Areas.Identity.IdentityHostingStartup))]
namespace Net_GL_BaseCamp.ChoiceA.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}