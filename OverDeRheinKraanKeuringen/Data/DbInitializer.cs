using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OverDeRheinKraanKeuringen.Authorization;
using OverDeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Data
{
    public class DbInitializer
    {

        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
             serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@contoso.com");
                await EnsureRole(serviceProvider, adminID, Constants.UserAdministratorsRole);

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@contoso.com");
                await EnsureRole(serviceProvider, managerID, Constants.UserManagersRole);

                var customerId = await EnsureUser(serviceProvider, testUserPw, "aaa@aaa.com");
                SeedDB(context);
            }
        }
        public static void SeedDB(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            // Look for any students.

            if (!context.Assignments.Any())
            {

                var damageTypes = new List<DamageType>
            {
                new DamageType { Type = Models.Type.H2O_Corrosion }
            };



                foreach (DamageType t in damageTypes)
                {
                    context.damageTypes.Add(t);
                }

                context.SaveChanges();





                var cableCheckLists = new List<CableChecklist>
            {
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = damageTypes  },
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = damageTypes  },
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = damageTypes  },
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = damageTypes  }
            };

                foreach (CableChecklist c in cableCheckLists)
                {
                    context.cableCheckLists.Add(c);
                }

                context.SaveChanges();




                var assignments = new List<Assignment>
            {
                new Assignment{ Date = DateTime.Now,Observations = "Heel Mooi", CableSupplier = "Apeldoorn", cableChecklists = context.cableCheckLists.ToList()}
            };
                foreach (Assignment s in assignments)
                {
                    context.Assignments.Add(s);
                }
                context.SaveChanges();

            }

        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new ApplicationUser { UserName = UserName, Email = UserName };
                var result = await userManager.CreateAsync(user, testUserPw);
                if (result.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                }

            }
            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

    }
}
