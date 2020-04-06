using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OverDeRheinKraanKeuringen.Models;
using OverDeRheinKraanKeuringen.ViewModels;

namespace OverDeRheinKraanKeuringen.Controllers
{
    [Authorize(Roles = "UserAdministrators, UserManagers")]
    public class AdministrationController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AdministrationController> _logger;

        public AdministrationController(RoleManager<IdentityRole> roleManager, 
                                        UserManager<ApplicationUser> userManager,
                                        ILogger<AdministrationController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role =  await _roleManager.FindByIdAsync(id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return NotFound();
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach(var user in _userManager.Users)
            {
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return NotFound();
            }
            else
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors) 
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            
           
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
           

            var role = await _roleManager.FindByIdAsync(roleId);

            ViewBag.roleName = role.Name;

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found";
                return NotFound();
            }

            var model = new List<UserRoleViewModel>();

            foreach(var user in _userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if(await _userManager.IsInRoleAsync(user,role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                } else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            if(ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(roleId);

                if(role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                    return NotFound();
                }

                for(int i = 0; i < model.Count; i++)
                {
                    var user = await _userManager.FindByIdAsync(model[i].UserId);

                    IdentityResult IR = null;

                    if(model[i].IsSelected && !(await _userManager.IsInRoleAsync(user,role.Name)))
                    {
                        IR = await _userManager.AddToRoleAsync(user, role.Name);
                    } else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        IR = await _userManager.RemoveFromRoleAsync(user, role.Name);
                    } else
                    {
                        continue;
                    }
                    if(IR.Succeeded)
                    {
                        if (i < (model.Count - 1)) continue;
                        else return RedirectToAction("EditRole", new { Id = roleId });
                    }
                }

                return RedirectToAction("EditRole", new { Id = roleId });
            }


            return View(model);

        }

        [HttpPost]
        public async Task< IActionResult> CreateRole(CreateRoleViewModel roles)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = roles.RoleName
                };

                if (!await _roleManager.RoleExistsAsync(identityRole.Name))
                {
                    IdentityResult IR = await _roleManager.CreateAsync(identityRole);
                    if (IR.Succeeded)
                    {
                        return RedirectToAction("ListRoles", "Administration");
                    }
                    foreach (IdentityError error in IR.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                } else
                {
                    ModelState.AddModelError("", "Role already exists!");
                }
            }
        
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> manageUserClaims(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return NotFound();
            }

            var existingUserClaims = await _userManager.GetClaimsAsync(user);

            var model = new UserClaimsViewModel
            {
                UserId = userId
            };

            foreach (Claim claim in ClaimsStore.AllClaims )
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };

                if(existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }

                model.Claims.Add(userClaim);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            
            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.UserId} cannot be found";
                return NotFound();
            }

            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove userexisting claims");
                return View(model);
            }

            result = await _userManager.AddClaimsAsync(user, 
                model.Claims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = model.UserId });

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccesDenied()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}