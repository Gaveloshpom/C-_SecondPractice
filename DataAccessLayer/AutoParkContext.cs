using Microsoft.EntityFrameworkCore;

public class AutoParkContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Departure> Departures { get; set; }

    public AutoParkContext(DbContextOptions<AutoParkContext> options)
    : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=autopark.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Альтернативний ключ (серія + номер паспорта)
        modelBuilder.Entity<Driver>()
            .HasIndex(d => new { d.PassportSeries, d.PassportNumber })
            .IsUnique();

        // Складений первинний ключ для departure
        modelBuilder.Entity<Departure>()
            .HasKey(d => new { d.DepartureDate, d.DriverNumber, d.CarNumber });

        // Зв'язки та каскадне видалення
        modelBuilder.Entity<Departure>()
            .HasOne(d => d.Driver)
            .WithMany(dr => dr.Departures)
            .HasForeignKey(d => d.DriverNumber)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Departure>()
            .HasOne(d => d.Car)
            .WithMany(c => c.Departures)
            .HasForeignKey(d => d.CarNumber)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
