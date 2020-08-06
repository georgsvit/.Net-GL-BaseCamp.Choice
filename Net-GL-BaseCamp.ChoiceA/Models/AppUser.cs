using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.ChoiceA.Models
{
    public class AppUser : IdentityUser
    {
        public string Group { get; set; }
    }
}
