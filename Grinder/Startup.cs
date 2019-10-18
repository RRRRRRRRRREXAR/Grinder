using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grinder.BLL.Interfaces;
using Grinder.BLL.Services;
using Grinder.DAL.DB;
using Grinder.DAL.Interfaces;
using Grinder.Hubs;
using Grinder.Infrostructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Grinder
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.WithOrigins("http://localhost:4200", "https://accounts.google.com")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GrinderContext>(options => options.UseSqlServer(connection).EnableSensitiveDataLogging());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAutharizationService, AuthorizationService>();
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IFindService, FindService>();
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IUserService, UserService>();
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
            services.AddTransient<IMessageService, MessageService>();
            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WebProfile());
            });
            IMapper mapper = mapConfig.CreateMapper();
            services.AddSignalR();
            services.AddSingleton(mapper);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/hub")))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                };
                });
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Images")),
                RequestPath = "/Images"
            });


            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/hub");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
