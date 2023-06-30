using MyMoney.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyMoney.Data
{
    public class MyMoneyDbContext : IdentityDbContext<User, IdentityRole<int>, int>

    {
        public MyMoneyDbContext(DbContextOptions<MyMoneyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Deposit> Deposits { get; init; }

        public DbSet<Credit> Credits { get; init; }

        public DbSet<Insurrance> Insurrances { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}