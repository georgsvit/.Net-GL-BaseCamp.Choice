using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.ChoiceA.Services
{
    public interface IGroupService
    {
        SelectListItem[] GetGroupNames { get; }
    }

    public class GroupService : IGroupService
    {
        public SelectListItem[] GetGroupNames { private set; get; }

        public GroupService()
        {
            GetGroupNames = new SelectListItem[] {
                new SelectListItem("SE-18-1", "SE-18-1"),
                new SelectListItem("SE-18-2", "SE-18-2"),
                new SelectListItem("SE-18-3", "SE-18-3"),
                new SelectListItem("SE-18-4", "SE-18-4"),
                new SelectListItem("SE-18-5", "SE-18-5")
            };
        }
    }

    public static class GroupServiceExtension
    {
        public static IServiceCollection AddGroupService(this IServiceCollection service) => service.AddTransient<IGroupService, GroupService>();
    }
}
