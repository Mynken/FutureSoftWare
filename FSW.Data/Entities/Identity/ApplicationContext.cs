﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW.Data.Entities.Identity
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("FSWContext") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
