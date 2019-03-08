using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MySql.Core;
using Hangfire.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace hangfire {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            
          /* var jobStorage = new MySqlStorage(Configuration.GetConnectionString ("DefaultConnection"));
           var mgr = new RecurringJobManager(jobStorage);
           mgr.AddOrUpdate(() => Debug.WriteLine($"Recurring: {DateTime.Now}"), Cron.Minutely);*/
            services.AddDbContext<BancoContext> (options => options.UseLazyLoadingProxies ().UseMySql (Configuration.GetConnectionString ("DefaultConnection")));
            services.AddHangfire (config =>
                config.UseStorage (new MySqlStorage (Configuration.GetConnectionString ("DefaultConnection")))
            );
           //RecurringJob.AddOrUpdate(() => Console.Write("Easy!"), Cron.Daily);
          // BackgroundJob.Enqueue(() => Console.WriteLine("Simple!"));
         // JobStorage.Current.GetConnection().GetRecurringJobs();
         //var storage = JobStorage.Current;
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
     
             //RecurringJob.AddOrUpdate("ew",Debug.WriteLine($"Recurring: {DateTime.Now}"), Cron.Minutely);
            app.UseHangfireDashboard ();
            app.UseHangfireServer ();
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}