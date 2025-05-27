using System.ComponentModel.DataAnnotations;

namespace BulgarianHeritage.Models;

public class UserContribution
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public int PointOfInterestId { get; set; }

    [Required]
    public ContributionType Type { get; set; }

    [MaxLength(200)]
    public string? Title { get; set; }

    [MaxLength(2000)]
    public string? Content { get; set; }

    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public ContributionStatus Status { get; set; } = ContributionStatus.Pending;

    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ApprovedAt { get; set; }

    public string? ApprovedByUserId { get; set; }

    [MaxLength(500)]
    public string? ModerationNotes { get; set; }

    // Navigation properties
    public virtual ApplicationUser User { get; set; } = null!;
    public virtual PointOfInterest PointOfInterest { get; set; } = null!;
    public virtual ApplicationUser? ApprovedByUser { get; set; }
}

public enum ContributionType
{
    Photo = 1,
    Story = 2,
    Review = 3,
    TravelTip = 4
}

public enum ContributionStatus
{
    Pending = 1,
    Approved = 2,
    Rejected = 3
} 