using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Contexts;
using Silky.EntityFrameworkCore.Contexts.Attributes;

namespace Silky.Order.EntityFrameworkCore
{
    [AppDbContext("default",DbProvider.MySql)]
    public class OrderDbContext : SilkyDbContext<OrderDbContext>
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Orders.Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DbConnectionString = "server=127.0.0.1;port=3306;database=order;uid=root;pwd=root;";
            optionsBuilder.UseMySql(DbConnectionString, ServerVersion.AutoDetect(DbConnectionString));
        }
    }

    /// <summary>
    /// 1.写一个类
    /// 2.实现IDesignTimeContextFactory接口
    /// 3.返回Dbcontext类就行了
    /// </summary>
    public class DbContextDesignTimeFactory : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OrderDbContext> builder = new DbContextOptionsBuilder<OrderDbContext>();
            string DbConnectionString = "server=127.0.0.1;port=3306;database=order;uid=root;pwd=root;";
            builder.UseMySql(DbConnectionString, ServerVersion.AutoDetect(DbConnectionString));
            return new OrderDbContext(builder.Options);
        }
    }
}