using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NASEB.Library.DAL.Concrete.EF;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.Helper.Security;

namespace NASEB.Library.MVCWebUI.Infrastructure
{
    public static class DbSead
    {
        public static void GetDefaultDatas(IApplicationBuilder app)
        {
            NASEBLibraryDbContext context = app.ApplicationServices.GetRequiredService<NASEBLibraryDbContext>();

            context.Database.Migrate();
            if (context.Users.Count() == 0 ||
                context.Users.FirstOrDefault(a => a.EMail.Equals("library@naseb.com")) == null)
            {
                var user = new User()
                {
                    EMail = "library@naseb.com",
                    PasswordHash = Hasher.HashPassword("Naseb.52"),
                    
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    NameSurname = "KARDEŞ DEDİKLERİMİZ"
                };
                context.Add(user);
            }

            if (context.Roles.Count() == 0)
            {
                context.Roles.Add(new Role() { RoleName = "admin"});
                context.Roles.Add(new Role() { RoleName = "amployee"});
            }

            if (context.BookTypes.Count()==0)
            {
                context.BookTypes.Add(new BookType() {TypeName = "BİLİM KURGU"});
                context.BookTypes.Add(new BookType() {TypeName = "MACERA"});
                context.BookTypes.Add(new BookType() {TypeName = "KORKU"});
                context.BookTypes.Add(new BookType() {TypeName = "ŞİİR"});
                context.BookTypes.Add(new BookType() {TypeName = "BİLGİSAYAR & YAZYLIM"});
                context.BookTypes.Add(new BookType() {TypeName = "HUKUK"});
                context.BookTypes.Add(new BookType() {TypeName = "MASAL"});
                context.BookTypes.Add(new BookType() {TypeName = "BİYOGRAFİ"});
                context.BookTypes.Add(new BookType() {TypeName = "PİSİKOLOJİ"});
                context.BookTypes.Add(new BookType() {TypeName = "SAĞLIK"});
                context.BookTypes.Add(new BookType() {TypeName = "FELSEFE"});
                context.BookTypes.Add(new BookType() {TypeName = "BİLİM"});
                context.BookTypes.Add(new BookType() {TypeName = "DİL"});
            }

            context.SaveChanges();

        }
    }
}
