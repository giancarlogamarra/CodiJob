using Application.DTOs;
using Application.IServices;
using Application.Services;
using CodiJobServices.Model;
using Domain.IRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infraestructure.Persistencia;
using Infraestructure.Repositories;
using Infraestructure.Transversal.Authentication;
using Infraestructure.Transversal.FluentValidations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Infraestructure.Transversal.Swagger;

using System.Text;

namespace CodiJobServices
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
            services.AddDbContext<CodiJobDbContext>(options =>
              options.UseSqlServer(
                  Configuration["Data:CodiJob:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                Configuration["Data:CodiJobIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            //Repositories
            services.AddTransient<IProyectoRepository, EFProyectoRepository>();
            services.AddTransient<ISkillRepository, EFSkillRepository>();
            services.AddTransient<IGrupoRepository, EFGrupoRepository>();
            services.AddTransient<IUsuarioPerfilRepository, EFUsuarioPerfilRepository>();

            //Services
            services.AddTransient<IProyectoService, ProyectoService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IGrupoService, GrupoService>();
            services.AddTransient<IUsuarioPerfilService, UsuarioPerfilService>();
            services.AddTransient<IUserService, UserService>();

            //Validators
            services.AddTransient<IValidator<ProyectoDTO>, ProyectoDTOValidator>();

            // configure jwt authentication
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
                   };
           });
            services.Configure<IISOptions>(options => {
                options.AutomaticAuthentication = false;
            });

            services.AddSwaggerDocumentation();

            services.AddMvc().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();
            app.UseSwaggerDocumentation();

            app.UseAuthentication();
            app.UseMvc();
            // IdentitySeedData.EnsurePopulated(app);
        }
    }
}
