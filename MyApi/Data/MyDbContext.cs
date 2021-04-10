using Microsoft.EntityFrameworkCore;
using MyApi.Entities;

namespace MyApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<UserInformation> UserInformationSet { get; set; }

    }
}
