using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//
using WebConfigAttemp2.Models;

namespace WebConfigAttemp2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {   // Configruation from appsettings.json has already been loaded by
            // CreateDefaultBuilder on WebHost in Program.cs. Use DI to load
            // the configuration into the Configuration property.
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add the service required for using options.
            services.AddOptions();

            #region snippet_Example1
            // Example #1: Basic options
            // Register the ConfigurationBuilder instance which MyOptions binds against.
            services.Configure<MyOptions>(Configuration);
            #endregion

            #region snippet_Example2
            // Example #2: Options bound and configured by a delegate
            services.Configure<MyOptionsWithDelegateConfig>(myOptions =>
            {
                myOptions.Option1 = "value1_configured_by_delegate";
                myOptions.Option2 = 500;
            });
            #endregion

            #region snippet_Example3
            // Example #3: Sub-options
            // Bind options using a sub-section of the appsettings.json file.
            services.Configure<MySubOptions>(Configuration.GetSection("subsection"));
            #endregion

            #region snippet_Example6
            // Example #6: Named options (named_options_1)
            // Register the ConfigurationBuilder instance which MyOptions binds against.
            // Specify that the options loaded from configuration are named
            // "named_options_1".
            services.Configure<MyOptions>("named_options_1", Configuration);

            // Example #6: Named options (named_options_2)
            // Specify that the options loaded from the MyOptions class are named
            // "named_options_2".
            // Use a delegate to configure option values.
            services.Configure<MyOptions>("named_options_2", myOptions =>
            {
                myOptions.Option1 = "named_options_2_value1_from_action";
            });
            #endregion
            services.AddSingleton<IConfiguration>(Configuration);
     

        services.AddMvc();
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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
