﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PetShop.Models;

[assembly: OwinStartupAttribute(typeof(PetShop.Startup))]
namespace PetShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdminAndUserRoles();
        }

        private void CreateAdminAndUserRoles()
        {
            var ctx = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(ctx));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(ctx));
            // adaugam rolurile pe care le poate avea un utilizator
            // din cadrul aplicatiei
            if (!roleManager.RoleExists("Admin"))
            {
                // adaugam rolul de administrator
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                // se adauga utilizatorul administrator
                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                var adminCreated = userManager.Create(user, "Admin2020!");
                if (adminCreated.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            
            if (!roleManager.RoleExists("Editor"))
            {
            // adaug rolul specific aplicatiei
            var role = new IdentityRole();
            role.Name = "Editor";
            roleManager.Create(role);
            // se adauga utilizatorul
            var user = new ApplicationUser();
            user.UserName = "editor@editor.com";
            user.Email = "editor@editor.com";

            var editorCreated = userManager.Create(user, "Editor2020!");

            if (editorCreated.Succeeded)
            {
                userManager.AddToRole(user.Id, "Editor");
            }
            }
        }
    }
}

