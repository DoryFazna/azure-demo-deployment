using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VotingData.Models;

namespace VotingData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connection = Configuration.GetValue<string>("ConnectionStrings:SqlDbConnection");
            services.AddDbContext<VotingDBContext>(options => options.UseSqlServer(connection));

            services.AddHealthChecks().AddSqlServer(Configuration["ConnectionStrings:SqlDbConnection"]);

            services.AddHealthChecksUI();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // app.UseHealthChecks("/health", new HealthCheckOptions
            // {
            //     Predicate = _ => true,
            //     ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            // });

            // app.UseHealthChecksUI(setup =>
            // {
            //     setup.UIPath = "/healthchecks-ui"; // ui path
            //     setup.ApiPath = "/health-ui-api"; // this is the internal ui api
            // });

            app.UseHealthChecks("/health");

            app.UseHealthChecksUI();

            // app.UseHealthChecksUI(setup =>
            // {
            //     setup.UIPath = "/healthchecks"; // ui path
            //     //setup.ApiPath = "/vote/votedata"; // this is the internal ui api
            // });
            // We will just create the table on startup if it doesn't exist since this is a demo
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<VotingDBContext>();
                VotingDBContext.CreateTablesIfNotExists(dbContext);
            }
        }
    }
}
