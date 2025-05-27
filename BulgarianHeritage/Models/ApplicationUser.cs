using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BulgarianHeritage.Models;

public class ApplicationUser : IdentityUser
{
    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual ICollection<Itinerary> Itineraries { get; set; } = new List<Itinerary>();
    public virtual ICollection<UserContribution> UserContributions { get; set; } = new List<UserContribution>();
} 