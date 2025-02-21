using CargoPay.Data.MigrationModel;
using Microsoft.EntityFrameworkCore;


namespace CargoPay.Data
{
    public class CargoPayContext : DbContext
    {
        public DbSet<CardMigration> Cards { get; set; }
        public DbSet<PaymentMigration> Payments { get; set; }
        public CargoPayContext(DbContextOptions<CargoPayContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardMigration>()
                .HasMany(c => c.payments)
                .WithOne(p => p.card)
                .HasForeignKey(p => p.CardNumber);

        }

    }
}
