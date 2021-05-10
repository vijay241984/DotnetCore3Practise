using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace WebApi
{
    public class Startup
    {
       

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Add set; property for User Secrets in ASP.net core 3.0
        public IConfiguration Configuration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string mySqlConnectionStr = Configuration.GetConnectionString("MySQLConnection");
            services.AddDbContextPool<CommanderContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            //services.AddDbContext<CommanderContext>(opt => opt.UseMySql 
            //(Configuration.GetConnectionString("CommanderConnection")  )
            //); 
            services.AddControllers().AddNewtonsoftJson(s => { s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); } );  

            //services.AddScoped<ICommanderRepo, MockCommanderRepo>(); 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICommanderRepo, SqlCommanderRepo>();

            //------------User Secrets in ASP.net core 3.0

            var adSecretKey = Configuration["ADSecretKey"];
            var adApplicationId = Configuration["ADApplicationId"];
            var value1Endpoint = Configuration["Value1Endpoint"];
            var value2Endpoint = Configuration["Value2Endpoint"];

            services.AddTransient<ISecrets>( _ => new Secrets(adSecretKey, adApplicationId, value1Endpoint, value2Endpoint) );

            /////--------------------/////////////////////////////////
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //User Secrets in ASP.net core 3.0
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
                
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
                
                app.UseDeveloperExceptionPage();
            }
            Configuration = builder.Build();
            //---------------------------------------------//

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
