using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleCoreApp.Models;

namespace SampleCoreApp
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("IdentityConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "66950626795-8qjju3k675onptgj4s8i580fo007n3oq.apps.googleusercontent.com";
                options.ClientSecret = "cjV7XvRGjTcOQLoaPGTirWzp";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            Microsoft.Extensions.Logging.ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("~/Error/{0}");
            }

            #region Static files
            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("foo.html");

            //app.UseDefaultFiles(options);
            //app.UseStaticFiles();

            //FileServerOptions options1 = new FileServerOptions();
            //options1.DefaultFilesOptions.DefaultFileNames.Clear();
            //options1.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            // app.UseFileServer();
            #endregion



            app.UseStaticFiles(); 
            app.UseRouting();
            app.UseMvc();
            app.UseAuthentication();
            // app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
                       

            #region Commnet code
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync(_config["MyKey"]);
            //    });
            //});
            #endregion

            #region 2 Middlewares
            //app.Use(async (context,next) =>
            //{
            //    // await context.Response.WriteAsync("Hello form 1st Middleware");
            //    logger.LogInformation("1st Incoming");
            //    await next();
            //    logger.LogInformation("1st OutGoing");
            //});

            //app.Use(async (context, next) =>
            //{
            //    // await context.Response.WriteAsync("Hello form 1st Middleware");
            //    logger.LogInformation("2nd Incoming");
            //    await next();
            //    logger.LogInformation("2nd OutGoing");
            //});

            #endregion

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hosting Environment :" + env.EnvironmentName);
            //});

        }
    }
}
