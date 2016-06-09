using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Role.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Role.Helpers
{
    public class IdentityHelper
    {
        internal static void SeedEntities(DbContext context)
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
                var reolResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_GEN));  
            }

            string userName = "gflynn@volusia.org";
            string password = "Passw0rd!";

            ApplicationUser user = userManager.FindByName("gflynn@volusia.org");
            if(user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };

                IdentityResult userResult = userManager.Create(user, password);

                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, RoleNames.ROLE_ADMIN);
                }
            }
        }
    }
}