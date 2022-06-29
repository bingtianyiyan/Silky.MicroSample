using Silky.Stock.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Contexts;
using Silky.EntityFrameworkCore.Contexts.Attributes;

namespace Silky.Stock.EntityFrameworkCore
{
    [AppDbContext("default", DbProvider.MySql)]
    public class StockDbContext : SilkyDbContext<StockDbContext>
    {
        public StockDbContext(DbContextOptions<StockDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DbConnectionString = "server=127.0.0.1;port=3306;database=stock;uid=root;pwd=root;";
            optionsBuilder.UseMySql(DbConnectionString, ServerVersion.AutoDetect(DbConnectionString));
        }
    }

    /// <summary>
    /// 1.дһ����
    /// 2.ʵ��IDesignTimeContextFactory�ӿ�
    /// 3.����Dbcontext�������
    /// </summary>
    public class DbContextDesignTimeFactory : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<StockDbContext>
    {
        public StockDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<StockDbContext> builder = new DbContextOptionsBuilder<StockDbContext>();
            string DbConnectionString = "server=127.0.0.1;port=3306;database=stock;uid=root;pwd=root;";
            builder.UseMySql(DbConnectionString, ServerVersion.AutoDetect(DbConnectionString));
            return new StockDbContext(builder.Options);
        }
    }
}