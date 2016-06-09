using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Roles.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Roles.Helpers
{
    public class IdentityHelper
    {
        internal static void SeedIdEntities(DbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(RoleNames.ROLE_ADMIN))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMIN));
            }

            if (!roleManager.RoleExists(RoleNames.ROLE_GEN))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_GEN));
            }
        }
    }
}