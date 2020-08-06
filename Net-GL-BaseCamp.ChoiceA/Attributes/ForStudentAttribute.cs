using Microsoft.AspNetCore.Mvc.Filters;
using Net_GL_BaseCamp.ChoiceA.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.ChoiceA.Attributes
{
    public class ForStudentAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) => new ForStudentFilter();
    }
}
