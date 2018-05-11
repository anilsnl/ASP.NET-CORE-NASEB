using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NASEB.DAL.Concrete.EF;
using NASEB.Entities.Concrete;
using NASEB.Helper.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.MVCWebUI.Infrastructure
{
    public static class DbSead
    {
        public static void GetDefaultData(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<EFNASEBDBContext>();

            context.Database.Migrate();

            if (context.Roles.Count()==0)
            {
                context.Roles.Add(new NASEBRole() { RoleName = "admin" });
                context.Roles.Add(new NASEBRole() { RoleName = "employee" });
                context.Roles.Add(new NASEBRole() { RoleName = "customer" });
            }
            if (!context.Branches.Any())
            {
                context.Branches.Add(new Branch()
                {
                    BranchName = "NASEBMAIN",
                    Phone="4445252",
                    Address="NASEB MAH, SIVAS CAD, NO 52, ALTINORDU ORDU"
                    
                });
            }
            if (!context.Users.Any(a=>a.EMail.Equals("rentacar@naseb.com")))
            {
                var user = new NASEBUser()
                {
                    EMail = "rentacar@naseb.com",
                    Address="NASEB MAH, SIVAS CAD, NO:58 ALTINORDU ORDU",
                    BranchID=1,
                    PhoneNumber="4445252",
                    Name="KARDEŞ",
                    Surname="DEDİKLERİMİZ",
                    isActive=true,
                    BirthDate=DateTime.Now.AddYears(34),
                    RegisterDate =DateTime.Now,
                    PasswordHash =Hasher.HashPassword("Naseb5252.")
                };

                context.Add(new UserRole() { User = user, RoleID = 1});
            }

            context.SaveChanges();
        }
    }
}
