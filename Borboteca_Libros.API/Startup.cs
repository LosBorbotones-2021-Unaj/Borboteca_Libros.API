using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System.Data;
using Microsoft.Data.SqlClient;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using Borboteca_Libros.AccessData;
using Borboteca_Libros.AccessData.Command.Repository;
using Borboteca_Libros.AccessData.Command;
using Borboteca_Libros.Application.Services;
using Borboteca_Libros.AccessData.Queries.Repository;
using Borboteca_Libros.AccessData.Queries;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Borboteca_Libros.API
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
            //Configuracion Sql ConnectionString
            services.AddControllers();
            var connectionString = Configuration.GetSection("connectionString").Value;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //Configuracion Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Borboteca_Libros", Version = "v1" });
            });

            //Configuracion Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AnyAllow", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            //Configuracion Auth

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtSettings:Secret").Value);
            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Injecciones de dependencias

            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<ILibroService, LibroService>();
            services.AddTransient<ILibroQuery, LibroQuery>();
            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<IAutorQuery, AutorQuery>();
            services.AddTransient<IGeneroQuery, GeneroQuery>();
            services.AddTransient<IGeneroService, GeneroService>();
            services.AddTransient<ILibroGeneroService, LibroGeneroService>();
            services.AddTransient<ILibroGeneroQuery, LibroGeneroQuery>();

            //Configuracion SqlKata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Borboteca_Libros.API v1"));
            }

            app.UseCors("AnyAllow");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
