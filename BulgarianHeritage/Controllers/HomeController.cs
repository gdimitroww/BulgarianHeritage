using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BulgarianHeritage.Models;
using BulgarianHeritage.Data;

namespace BulgarianHeritage.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Get featured POIs for the homepage
        var featuredPOIs = await _context.PointsOfInterest
            .Include(p => p.Images)
            .Where(p => p.IsUNESCOSite || p.HasVirtualTour)
            .OrderByDescending(p => p.CreatedAt)
            .Take(6)
            .ToListAsync();

        // Get statistics for the homepage
        var stats = new
        {
            TotalPOIs = await _context.PointsOfInterest.CountAsync(),
            UNESCOSites = await _context.PointsOfInterest.CountAsync(p => p.IsUNESCOSite),
            VirtualTours = await _context.PointsOfInterest.CountAsync(p => p.HasVirtualTour),
            UserContributions = await _context.UserContributions
                .CountAsync(uc => uc.Status == ContributionStatus.Approved)
        };

        ViewBag.FeaturedPOIs = featuredPOIs;
        ViewBag.Stats = stats;

        return View();
    }

    public IActionResult Map()
    {
        ViewBag.Categories = Enum.GetValues<POICategory>();
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
