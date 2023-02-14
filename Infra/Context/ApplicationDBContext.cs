using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using i_want_buy.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace i_want_buy.Infra.Context
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                   .Property(p => p.Name)
                   .IsRequired();
            builder.Entity<Product>()
                   .Property(p => p.Description)
                   .HasMaxLength(255);
            builder.Entity<Category>()
                   .Property(c => c.Name)
                   .IsRequired();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>()
                .HaveMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options
                                        .UseSqlServer();
    }
}