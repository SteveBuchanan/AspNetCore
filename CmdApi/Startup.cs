﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using CmdApi.Models;

namespace CmdApi
{
    public class Startup
    {
        public IConfiguration CmdApiConfiguration{get;}
        
        public Startup(IConfiguration cmdapiConfig) => CmdApiConfiguration = cmdapiConfig;
        //public Startup(IConfiguration config)
        //{
        //    CmdApiConfiguration = config;
        //}


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CommandContext>
                (opt => opt.UseSqlServer(CmdApiConfiguration["Data:CommandAPIConnection:ConnectionString"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
