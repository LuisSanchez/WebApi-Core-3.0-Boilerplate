using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Address.Business;
using Address.Persistence.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Address.API
{
    public class Startup
    {
        readonly string AllowedOrigins = "_allowedOrigins";
        readonly string[] origins = { "https://luissanchez.github.io" };

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Instead of having the webapi to connect to the database.
            // The connection string is passed to the class library using DI.
            //services.AddDbContext<AddressDBContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));

            ConnectionStrings connectionStrings = new ConnectionStrings();

            string dbPassword = Environment.GetEnvironmentVariable("CONN_STRING_ADDRESS_WEBAPI");

            if (dbPassword == null)
            {
                // Used with appsettings.json or secrets
                //services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

                // secret manager with singleton.
                connectionStrings.DefaultConnection = Configuration["ConnectionStrings:DefaultConnection"];
            }
            else
            {
                connectionStrings.DefaultConnection = dbPassword;
            }

            // For this sandbox, github origin and all methods will be allowed.
            services.AddCors(options =>
            {
                options.AddPolicy(AllowedOrigins,
                    builder =>
                    {
                        builder.WithOrigins(origins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            services.AddControllers();

            // to access the context 
            services.AddHttpContextAccessor();

            // Conn string as singleton.
            services.AddSingleton<ConnectionStrings>(connectionStrings);

            // Register the class that reads the DB into the DI framework
            services.AddTransient<IAddressBusiness, AddressBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(AllowedOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
