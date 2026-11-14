using Microsoft.EntityFrameworkCore;

namespace Woodworking_shop.Entities;

public class DataContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<ConsumptionRate> ConsumptionRates { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<MaterialReservation> MaterialReservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // ВАЖНО: Замените "ваш_пароль" на реальный пароль от Postgres!
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WoodworkingDb;Username=postgres;Password=polkmn908WA");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ConsumptionRate>()
            .HasKey(cr => cr.Id);
    }
}