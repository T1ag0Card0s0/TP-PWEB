using HabitAqui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HabitAqui.Data
{
    public enum Roles
    {
        Cliente,
        Funcionario,
        Gestor,
        Admin
    }
    public static class RolesInitialization
    {
        public static async Task generateInitialData(UserManager<ApplicationUser> userManager,
                                                    RoleManager<IdentityRole> roleManager,
                                                    ApplicationDbContext context)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Gestor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Funcionario.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Cliente.ToString()));

            var defaultUser = new ApplicationUser
            {
                UserName = "admin@admin",
                Email = "admin@admin",
                FirstName = "Admin",
                LastName = "Local",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                Ativo = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Admin123!");
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());

                var admin = new Administrador
                {
                    ApplicationUser = defaultUser,
                    Name = defaultUser.FirstName
                };
                context.Update(admin);
                await context.SaveChangesAsync();
            }
        }

    }
}