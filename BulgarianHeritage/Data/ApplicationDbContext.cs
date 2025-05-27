using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BulgarianHeritage.Models;

namespace BulgarianHeritage.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    public DbSet<POIImage> POIImages { get; set; }
    public DbSet<Itinerary> Itineraries { get; set; }
    public DbSet<ItineraryItem> ItineraryItems { get; set; }
    public DbSet<UserContribution> UserContributions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Point of Interest configuration
        builder.Entity<PointOfInterest>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Latitude).HasPrecision(10, 8);
            entity.Property(e => e.Longitude).HasPrecision(11, 8);
            entity.HasIndex(e => e.Category);
            entity.HasIndex(e => new { e.Latitude, e.Longitude });
        });

        // POI Image configuration
        builder.Entity<POIImage>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.PointOfInterest)
                  .WithMany(p => p.Images)
                  .HasForeignKey(e => e.PointOfInterestId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Itinerary configuration
        builder.Entity<Itinerary>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.User)
                  .WithMany(u => u.Itineraries)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Itinerary Item configuration
        builder.Entity<ItineraryItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Itinerary)
                  .WithMany(i => i.Items)
                  .HasForeignKey(e => e.ItineraryId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.PointOfInterest)
                  .WithMany(p => p.ItineraryItems)
                  .HasForeignKey(e => e.PointOfInterestId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // User Contribution configuration
        builder.Entity<UserContribution>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.User)
                  .WithMany(u => u.UserContributions)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.PointOfInterest)
                  .WithMany(p => p.UserContributions)
                  .HasForeignKey(e => e.PointOfInterestId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.ApprovedByUser)
                  .WithMany()
                  .HasForeignKey(e => e.ApprovedByUserId)
                  .OnDelete(DeleteBehavior.NoAction);
        });
    }
} 