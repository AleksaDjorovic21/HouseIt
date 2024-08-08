using Microsoft.EntityFrameworkCore;
using HouseIt.Core.Domain;

namespace HouseIt.Infrastructure.Persistence;

public class HouseItDbContext(DbContextOptions<HouseItDbContext> options) : DbContext(options)
{
    //DbSet<> represents collections of entities that are mapped to database tables.
    //specifying entity configurations like primary keys, relationships
    public DbSet<DesignRequest> DesignRequests { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Kitchen> Kitchens { get; set; }
    public DbSet<Toilet> Toilets { get; set; }
    public DbSet<Balcony> Balconies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DesignRequest>().HasKey(dr => dr.Id);
        modelBuilder.Entity<Floor>().HasKey(f => f.Id);
        modelBuilder.Entity<Room>().HasKey(r => r.Id);
        modelBuilder.Entity<Kitchen>().HasKey(k => k.Id);
        modelBuilder.Entity<Toilet>().HasKey(t => t.Id);
        modelBuilder.Entity<Balcony>().HasKey(b => b.Id);

        // Configure auto-generation of IDs
        modelBuilder.Entity<Floor>().Property(f => f.Id).ValueGeneratedOnAdd();       
        modelBuilder.Entity<Room>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Kitchen>().Property(k => k.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Toilet>().Property(t => t.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Balcony>().Property(b => b.Id).ValueGeneratedOnAdd();

        // Configure DesignRequest relationships
        modelBuilder.Entity<DesignRequest>()
            .HasMany(dr => dr.Floors)
            .WithOne()
            .IsRequired();

        // Configure Floor relationships
        modelBuilder.Entity<Floor>()
            .HasMany(dr => dr.Rooms)
            .WithOne()
            .IsRequired();

        modelBuilder.Entity<Floor>()
            .HasMany(dr => dr.Kitchens)
            .WithOne()
            .IsRequired();

        modelBuilder.Entity<Floor>()
            .HasMany(dr => dr.Toilets)
            .WithOne()
            .IsRequired();

        // Configure Room relationships
        modelBuilder.Entity<Room>()
            .OwnsMany(r => r.Doors, b =>
            {
                b.ToJson();
                b.Property(e => e.Type).HasConversion<string>();
                b.Property(e => e.Color).HasConversion<string>();
            });

        modelBuilder.Entity<Room>()
            .OwnsMany(r => r.Windows, b => 
            {
                b.ToJson();
                b.Property(e => e.Size).HasConversion<string>();
            });

        modelBuilder.Entity<Room>()
            .HasOne(dr => dr.Balcony)
            .WithOne()
            .HasForeignKey<Balcony>(k => k.Id)
            .IsRequired();

        modelBuilder.Entity<Room>()
            .Property(r => r.Sqrm)
            .IsRequired();

        modelBuilder.Entity<Room>()
            .Property(r => r.Color)
            .IsRequired();
        
        // Configure Kitchen relationships
        modelBuilder.Entity<Kitchen>()
            .OwnsMany(k => k.Doors, d =>
            {
                d.ToJson();
                d.Property(e => e.Type).HasConversion<string>();  
                d.Property(e => e.Color).HasConversion<string>();
            });

        modelBuilder.Entity<Kitchen>()
            .OwnsMany(k => k.Windows, w =>
            {
                w.ToJson();
                w.Property(e => e.Size).HasConversion<string>();
            });

        modelBuilder.Entity<Kitchen>()
            .Property(k => k.HasDiningArea)
            .IsRequired();

        // Configure Toilet relationships
        modelBuilder.Entity<Toilet>()
            .OwnsMany(t => t.Doors, d =>
            {
                d.ToJson();
                d.Property(e => e.Type).HasConversion<string>();  
                d.Property(e => e.Color).HasConversion<string>();
            });

        modelBuilder.Entity<Toilet>()
            .OwnsMany(t => t.Windows, w =>
            {
                w.ToJson();
                w.Property(e => e.Size).HasConversion<string>();
            });

        modelBuilder.Entity<Toilet>()
            .Property(t => t.ToiletType)
            .IsRequired();
    }
}

