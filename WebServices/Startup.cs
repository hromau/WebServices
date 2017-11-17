using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebServices.Models;
using Ninject.Modules;
using Ninject;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebServices
{
    public class Startup
    {
        public static WebservicesContext item;

        public static IKernel AppKernel = new StandardKernel(new ActiveUserModule());

        public class ActiveUserModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IActiveUser>().To<ModelActiveUser>();
            }
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<WebservicesContext>(options => options.UseSqlServer(connection));
            //services.AddScoped<WebservicesContext>();
            services.AddMvc();
            var optionsBuilder = new DbContextOptionsBuilder<ModelContext>();
            optionsBuilder.UseSqlServer(connection);
            item = new WebservicesContext();

            
            //using (var item = new ModelContext(optionsBuilder.Options))
            //{
            //    UserTable user = new UserTable() { FirstName = "wqe", AcountNumber = 4, DOB = DateTime.Now, Email = "wqq", GroupName = "qeqw", LastName = "eqwe", Password = "qweq" };
            //    item.UserTable.Add(user);
            //    item.SaveChanges();
            //}
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=LoginForm}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "GeneralForm",
                    template: "{controller=Home}/{action=GeneralForm}/{id?}");
            });
        }
    }
}
