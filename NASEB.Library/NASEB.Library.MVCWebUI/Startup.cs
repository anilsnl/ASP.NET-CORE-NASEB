using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.DAL.Concrete.EF;
using NASEB.Library.Helper.AppSettings;
using NASEB.Library.Helper.Mail;
using NASEB.Library.MVCWebUI.Infrastructure;
using NASEB.Library.Services.Abstract;
using NASEB.Library.Services.Concrete;

namespace NASEB.Library.MVCWebUI
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //for unit of work
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            //referances for services
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IBookTypeService, BookTypeManager>();
            services.AddScoped<IPublisherService, PublisherManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IMailSender, MailSender>();
            services.AddScoped<IMemberService, MemberManager>();
            services.AddScoped<IRentService, RentManager>();
            services.AddScoped<IAppSettings, AppSettings>();
            //for authencations
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Login";
                    option.AccessDeniedPath = "/AccessDenied";
                });
            services.AddDbContext<NASEBLibraryDbContext>(op => op.UseSqlServer(
                Configuration.GetConnectionString("NASEBLibrary")
                , b => b.MigrationsAssembly("NASEB.Library.MVCWebUI")));
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseFileServer();
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseSession();
            DbSead.GetDefaultDatas(app);

            app.UseMvc(root =>
            {
                root.MapRoute(name: "login", template: "Login", defaults: new { controller = "Account", action = "Index" });

                root.MapRoute(name: "default", template: "{controller}/{action}/{id?}", defaults: new { controller = "Home", action = "Index" });
            });

        }
    }
}
