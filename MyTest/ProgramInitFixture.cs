using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApi.Data;
using MyApi.Services;
using MyApi.Services.Impl;
using System;
using Xunit;

namespace MyTest
{

    public class ProgramInitFixture : IDisposable
    {
        public IServiceCollection Services { get; }
        public IServiceProvider Provider { get; }

        public ProgramInitFixture()
        {
            Console.WriteLine("Build all services!");

            Services = new ServiceCollection();

            Services.AddDbContext<MyDbContext>(
                option => { option.UseSqlite("Data Source=routine.db"); }
            );

            Services.AddMemoryCache();

            Services.AddScoped<IUserInformationService, UserInformationService>();
            Services.AddScoped<IVerificationCodeHelper, VerificationCodeHelper>();
            Services.AddScoped<IEmailHelper, EmailHelper>();

            Provider = Services.BuildServiceProvider();
            Console.WriteLine("All services have been built!");
            this.Init();
        }

        private void Init()
        {
            Console.WriteLine("Init the database!");
            var dbContext = Provider.GetService<MyDbContext>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.Migrate();
            dbContext.SaveChanges();
            Console.WriteLine("The database has initilized!");
        }

        public void Dispose()
        {
            Console.WriteLine("Clean all services and the database!");
            var dbContext = Provider.GetService<MyDbContext>();
            dbContext.Database.EnsureDeleted();

            Services.Clear();
            Console.WriteLine("All services and the database have been cleaned!");
        }
    }

    [CollectionDefinition("ProgramInitCollection")]
    public class ProgramInitCollection : ICollectionFixture<ProgramInitFixture>
    {

    }
}
