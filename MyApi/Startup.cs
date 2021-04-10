using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApi.Data;
using MyApi.Services;
using MyApi.Services.Impl;

namespace MyApi
{
    public class Startup
    {
        private const string CORS_POLICY_NAME = "MyPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region CORS
            services.AddCors(c =>
            {
                c.AddPolicy(CORS_POLICY_NAME, policy =>
                {
                    policy
                    .WithOrigins("http://127.0.0.1:3000", "http://localhost:3000", "http://3.25.118.30:3000")  //allow client ip
                    .WithExposedHeaders("x-pagination", "location")                  //allow header
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            #endregion

            services.AddDbContext<MyDbContext>(option =>
            {
                option.UseSqlite("Data Source=routine.db");
            });

            services.AddMemoryCache();

            services.AddScoped<IUserInformationService, UserInformationService>();

            services.AddScoped<IVerificationCodeHelper, VerificationCodeHelper>();

            services.AddScoped<IEmailHelper, EmailHelper>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region CORS
            app.UseCors(CORS_POLICY_NAME);//添加 Cors 跨域中间件
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
