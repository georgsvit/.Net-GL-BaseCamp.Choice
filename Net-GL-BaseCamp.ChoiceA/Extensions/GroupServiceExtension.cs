using Microsoft.Extensions.DependencyInjection;
using Net_GL_BaseCamp.ChoiceA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.ChoiceA.Extensions
{
    public static class GroupServiceExtension
    {
        public static IServiceCollection AddGroupService(this IServiceCollection service) => service.AddSingleton<IGroupService, GroupService>();
    }
}
