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
            //Get Managers
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            //Create Roles if they do NOT exist
            if (!roleManager.RoleExists(RoleNames.ROLE_ADMIN))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMIN));
            }

            if (!roleManager.RoleExists(RoleNames.ROLE_GEN))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_GEN));
            }

            //Create Users
            string userName = "gflynn@volusia.org";
            string password = "Passw0rd!";

            ApplicationUser user = userManager.FindByName(userName);
            if(user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };
                IdentityResult userResult = userManager.Create(user, password);

                //If User is created successfully, add to Admin Role
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, RoleNames.ROLE_ADMIN);
                }
            }
        }
    }
}