using Engineer.Models.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engineer.Repositories.Seed
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUser()
        {
            if (!_userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("../Engineer.Repositories/Seed/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                var roles = new List<Role>
                {
                    new Role{Name = "Trainer"},
                    new Role{Name = "User"}
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

                foreach (var user in users)
                {
                    _userManager.CreateAsync(user, "password").Wait();
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }

                var trainer = new User
                {
                    UserName = "Trainer"
                };

                IdentityResult result = _userManager.CreateAsync(trainer, "password").Result;

                if (result.Succeeded)
                {
                    var _trainer = _userManager.FindByNameAsync("Trainer").Result;
                    _userManager.AddToRoleAsync(_trainer, "Trainer").Wait();
                }
            }
        }
    }
}
