using Microsoft.EntityFrameworkCore;
using Silky.Account.Domain.Accounts;
using Silky.EntityFrameworkCore.Contexts;
using Silky.EntityFrameworkCore.Contexts.Attributes;

namespace Silky.Account.EntityFrameworkCore
{
    [AppDbContext("default", DbProvider.MySql)]
    public class UserDbContext : SilkyDbContext<UserDbContext>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Accounts.Account> Accounts { get; set; }

        public DbSet<BalanceRecord> BalanceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DbConnectionString = "server=127.0.0.1;port=3306;database=account;uid=root;pwd=root;";
            optionsBuilder.UseMySql(DbConnectionString, ServerVersion.AutoDetect(DbConnectionString));
        }
    }

    /// <summary>
    /// 1.写一个类
    /// 2.实现IDesignTimeContextFactory接口
    /// 3.返回Dbcontext类就行了
    /// </summary>
    public class DbContextDesignTimeFactory :Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<UserDbContext> builder = new DbContextOptionsBuilder<UserDbContext>();
            string DbConnectionString = "server=127.0.0.1;port=3306;database=account;uid=root;pwd=root;";
            builder.UseMySql(DbConnectionString, ServerVersion.AutoDetect(DbConnectionString));
            return new UserDbContext(builder.Options);
        }
    }
}