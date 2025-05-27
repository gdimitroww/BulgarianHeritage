using System.ComponentModel.DataAnnotations;

namespace BulgarianHeritage.Models;

public class PointOfInterest
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string NameBulgarian { get; set; } = string.Empty;

    [Required]
    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(2000)]
    public string DescriptionBulgarian { get; set; } = string.Empty;

    [Required]
    public double Latitude { get; set; }

    [Required]
    public double Longitude { get; set; }

    [Required]
    public POICategory Category { get; set; }

    [MaxLength(500)]
    public string? MainImageUrl { get; set; }

    [MaxLength(500)]
    public string? PanoramicImageUrl { get; set; }

    [MaxLength(500)]
    public string? VideoUrl { get; set; }

    public bool IsUNESCOSite { get; set; }

    public bool HasVirtualTour { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual ICollection<POIImage> Images { get; set; } = new List<POIImage>();
    public virtual ICollection<UserContribution> UserContributions { get; set; } = new List<UserContribution>();
    public virtual ICollection<ItineraryItem> ItineraryItems { get; set; } = new List<ItineraryItem>();
}

public enum POICategory
{
    Church = 1,
    Monument = 2,
    HistoricalTown = 3,
    Architecture = 4,
    Nature = 5,
    Museum = 6,
    Fortress = 7,
    Monastery = 8,
    Archaeological = 9,
    Cultural = 10
} 