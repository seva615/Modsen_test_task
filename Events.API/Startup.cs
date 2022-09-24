using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Events.Data;
using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Events.Data.Repositories;
using Events.Services.Cryptography;
using Events.Services.ServiceInterfaces;
using Events.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Modsen_test_task.Jwt;

namespace Modsen_test_task
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            
            services.AddDbContext<DataContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddSingleton(mapper);
            
            var authOptionsConfiguration = Configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfiguration);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        LifetimeValidator = (notBefore,expires, securityToken, validationParameters) =>
                            expires >= DateTime.Now,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = Configuration["Auth:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Auth:Key"]))
                    };
                });
            
            services.AddAuthorization();
            services.AddControllers();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            services.AddScoped<ISpeechRepository, SpeechRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IOrganizerService, OrganizerService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<ISpeakerService, SpeakerService>();
            services.AddScoped<ISpeechService, SpeechService>();
            services.AddScoped<IAccountCryptographyService, AccountCryptographyService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Events.API", Version = "v1"});
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert jwt token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
               c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                   {
                       new OpenApiSecurityScheme {
                           Reference = new OpenApiReference {
                               Type = ReferenceType.SecurityScheme,
                               Id = "Bearer"
                           }
                       },
                       new string[] {}
                   }
               }); 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Events.API v1"));
            }
            
            
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;

                using (var context = serviceProvider.GetService<DataContext>())
                {
                    context?.Database.Migrate();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication(); 
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}