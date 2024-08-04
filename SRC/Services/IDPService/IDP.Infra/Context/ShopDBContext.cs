using IDP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IDP.Infra.Context
{
    public class ShopDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ShopDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<User> MyProperty { get; set; }
    }
}
