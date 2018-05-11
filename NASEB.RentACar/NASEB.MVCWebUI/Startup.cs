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
using NASEB.DAL.Abstruck;
using NASEB.DAL.Abstruck.Entities;
using NASEB.DAL.Concrete.EF;
using NASEB.MVCWebUI.Infrastructure;
using NASEB.Services.Abstruck;
using NASEB.Services.Concrete;

namespace NASEB.MVCWebUI
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
            //for services
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IRentService, RentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICarDAL, EFCarDAL>();
            services.AddSingleton<IRoleService, RoleService>();

            services.AddDbContext<EFNASEBDBContext>
                (option => option.UseSqlServer(Configuration.GetConnectionString("NASEB"), b => b.MigrationsAssembly("NASEB.MVCWebUI")));
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(option =>
               {
                   option.LoginPath = "/Login";
                   option.AccessDeniedPath = "/AccessDenied";
               });
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
            app.UseMvc(root =>
            {
                root.MapRoute(name: "login", template: "Login", defaults: new { controller = "Account", action = "Index" });

                root.MapRoute(name: "default", template: "{controller}/{action}/{id?}",defaults:new { controller="Home",action="Index"});
            });
            DbSead.GetDefaultData(app);
        }
    }
}
