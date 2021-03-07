using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VideoGameLibrary.Areas.Admin.Pages.Roles
{
    public class AddUserRoleModel : PageModel
    {
        public RoleManager<IdentityRole> RoleManager { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public AddUserRoleModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }

        public SelectList AllUsers { get; set; }
        public SelectList AllRoles { get; set; }


        [BindProperty]
        [Required]
        public string SelectedUserId { get; set; }

        [BindProperty]
        [Required]
        public string SelectedRoleId { get; set; }

        public IActionResult OnGet()
        {
            AllUsers = new SelectList(UserManager.Users.ToList(), "Id", "Email");
            AllUsers = new SelectList(RoleManager.Roles.ToList(), "Name", "Name");
            return Page();

        }
    }
}
