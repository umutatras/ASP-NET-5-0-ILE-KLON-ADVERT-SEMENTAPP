using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using Udemy.AdvertisementApp.Business.Helpers;
using Udemy.AdvertisementApp.UI.Mappings.AutoMapper;
using Udemy.AdvertisementApp.UI.Models;
using Udemy.AdvertisementApp.UI.ValidationRules;

namespace Udemy.AdvertisementApp.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration);
            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidation>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "UdemyCookie";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
        opt.ExpireTimeSpan = TimeSpan.FromDays(30);
        opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
        opt.LogoutPath=new Microsoft.AspNetCore.Http.PathString("/Account/LogOut");
        opt.AccessDeniedPath=new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied");
    });
            services.AddControllersWithViews();
            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new UserCreateModelProfile());
            var configuration = new MapperConfiguration(opt =>
              {
                  opt.AddProfiles(profiles);
              });
            var mapper=configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
