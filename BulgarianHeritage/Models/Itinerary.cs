using System.ComponentModel.DataAnnotations;

namespace BulgarianHeritage.Models;

public class Itinerary
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public bool IsPublic { get; set; } = false;

    // Navigation properties
    public virtual ApplicationUser User { get; set; } = null!;
    public virtual ICollection<ItineraryItem> Items { get; set; } = new List<ItineraryItem>();
}

public class ItineraryItem
{
    public int Id { get; set; }

    [Required]
    public int ItineraryId { get; set; }

    [Required]
    public int PointOfInterestId { get; set; }

    public int Order { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }

    public TimeSpan? EstimatedDuration { get; set; }

    // Navigation properties
    public virtual Itinerary Itinerary { get; set; } = null!;
    public virtual PointOfInterest PointOfInterest { get; set; } = null!;
} 