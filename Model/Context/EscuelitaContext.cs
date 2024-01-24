using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Model.Entities;

namespace Model.Context
{
    public class EscuelitaContext : DbContext
    {
        private readonly string? _connectionString;


        public EscuelitaContext()
        {

        }

        public EscuelitaContext(DbContextOptions<EscuelitaContext> options) : base(options)
        {
            var extension = options.FindExtension<SqlServerOptionsExtension>();
            _connectionString = extension.ConnectionString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Transfers)
                .WithOne(t => t.OriginAccount)
                .HasForeignKey(t => t.OriginAccountId);

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
