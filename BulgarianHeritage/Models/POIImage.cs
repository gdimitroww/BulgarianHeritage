using System.ComponentModel.DataAnnotations;

namespace BulgarianHeritage.Models;

public class POIImage
{
    public int Id { get; set; }

    [Required]
    public int PointOfInterestId { get; set; }

    [Required]
    [MaxLength(500)]
    public string ImageUrl { get; set; } = string.Empty;

    [MaxLength(300)]
    public string? Caption { get; set; }

    [MaxLength(300)]
    public string? CaptionBulgarian { get; set; }

    public int DisplayOrder { get; set; } = 0;

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    public virtual PointOfInterest PointOfInterest { get; set; } = null!;
} 