﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mR_DataAccess.Data;
using mR_Models;
using mR_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mR_DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0) // проверят есть ли еще миграции 
                {
                    _db.Database.Migrate(); // закончит миграции 
                }
            }
            catch (Exception ex)
            {

            }

            // Создание роли админа и пользователя
            if (!_roleManager.RoleExistsAsync(WC.AdminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WC.AdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WC.CustomerRole)).GetAwaiter().GetResult();
            }

            else
            {
                return;
            }

            _userManager.CreateAsync(new ApplicationUser {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                FullName = "Admin Adminovich",
                PhoneNumber = "11111111111"
            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.Email == "admin@gmail.com");
            _userManager.AddToRoleAsync(user, WC.AdminRole).GetAwaiter().GetResult();
        }
    }
}
