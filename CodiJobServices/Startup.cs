using Application.DTOs;
using Application.IServices;
using Application.Services;
using CodiJobServices.Model;
using Domain.IRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infraestructure.Persistencia;
using Infraestructure.Repositories;
using Infraestructure.Transversal.FluentValidations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

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

            //Services
            services.AddTransient<IProyectoService, ProyectoService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IGrupoService, GrupoService>();

            //Validators
            services.AddTransient<IValidator<ProyectoDTO>, ProyectoDTOValidator>();


            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "CodiJobServices", Version = "v1" });
            });

            services.AddMvc().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseAuthentication();
            app.UseMvc();
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
