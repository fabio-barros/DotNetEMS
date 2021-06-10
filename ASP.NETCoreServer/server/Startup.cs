using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using server.Models;
using server.Services;

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
            

            services.AddControllers().ConfigureApiBehaviorOptions(options => {
                options.SuppressModelStateInvalidFilter = true;
            });

           

            //XML
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "server", Version = "v1" });

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                c.IncludeXmlComments(Path.Combine(basePath, fileName));
            });

            //ENABLE CORS
            services.AddCors(options =>
            {
                options.AddPolicy("ReactAdmin", options => options.AllowAnyOrigin()
                    .AllowAnyMethod().AllowAnyHeader().WithExposedHeaders(HeaderNames.ContentRange));

                //options.AddPolicy("ReactAdmin", builder => builder.AllowAnyOrigin()
                //    .AllowAnyMethod().WithExposedHeaders("Content-Range"," funcionarios 0-5/10"));
            });

            //JSON SERIALIZER
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //DB CONTEXT
            services.AddDbContext<EmsContext>(
                 options => options.UseNpgsql(
                     Configuration.GetConnectionString(
                         "DbConnectionString")
                     )
                 );

            services.AddScoped<IEmployeeService, EmployeeService>();

            //JWT 
            var secret =
                Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfig:Secret").Value);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secret),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
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
            app.UseCors();

            app.UseAuthorization(); 

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

       
        }
    }
}
