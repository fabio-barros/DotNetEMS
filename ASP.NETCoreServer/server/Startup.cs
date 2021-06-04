using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using server.Models;

namespace server
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
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "server", Version = "v1"}); });

            //ENABLE CORS
            services.AddCors(options =>
            {
                options.AddPolicy("ReactAdmin", options => options.AllowAnyOrigin()
                    .AllowAnyMethod().AllowAnyHeader().WithExposedHeaders(HeaderNames.ContentRange));

                //options.AddPolicy("ReactAdmin", builder => builder.AllowAnyOrigin()
                //    .AllowAnyMethod().WithExposedHeaders("Content-Range"," funcionarios 0-5/10"));
            });

            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            //DB CONTEXT
            services.AddDbContext<EmsContext>(
                 options => options.UseNpgsql(
                     Configuration.GetConnectionString(
                         "DbConnectionString")
                     )
                 );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "server v1") ) ;
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //CORS
            app.UseCors("ReactAdmin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}