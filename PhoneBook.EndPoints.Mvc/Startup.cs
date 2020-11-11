using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Domain.Contracts.Pepole;
using PhoneBook.Domain.Contracts.PersonTags;
using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.EndPoints.Mvc.Models.AAA;
using PhoneBook.Infrustructures.DataAccess.Common;
using PhoneBook.Infrustructures.DataAccess.People;
using PhoneBook.Infrustructures.DataAccess.PersonTags;
using PhoneBook.Infrustructures.DataAccess.Phones;
using PhoneBook.Infrustructures.DataAccess.Tags;

namespace PhoneBook.EndPoints.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configration)
        {
            Configuration = configration;
        }
        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PhoneBookContext>(c => c.UseSqlServer(Configuration.GetConnectionString("phoneBook")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IPersonTagRepository, PersonTagRepository>();
            services.AddDbContext<UserDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("aaa")));
            services.AddScoped<IPasswordValidator<AppUser>, MyPasswordValidator>();
            services.AddIdentity<AppUser,AppRole>(c=>
            {
                c.Password.RequireDigit = false;
                c.Password.RequireUppercase = false;
                c.Password.RequireLowercase = false;
                c.Password.RequiredLength = 6;
                c.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
