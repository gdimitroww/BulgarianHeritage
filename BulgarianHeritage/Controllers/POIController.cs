using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BulgarianHeritage.Data;
using BulgarianHeritage.Models;
using Microsoft.AspNetCore.Authorization;

namespace BulgarianHeritage.Controllers;

public class POIController : Controller
{
    private readonly ApplicationDbContext _context;

    public POIController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: POI
    public async Task<IActionResult> Index(POICategory? category = null, string? search = null)
    {
        var query = _context.PointsOfInterest
            .Include(p => p.Images)
            .AsQueryable();

        if (category.HasValue)
        {
            query = query.Where(p => p.Category == category.Value);
        }

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name.Contains(search) || 
                                   p.NameBulgarian.Contains(search) ||
                                   p.Description.Contains(search) ||
                                   p.DescriptionBulgarian.Contains(search));
        }

        var pois = await query.OrderBy(p => p.Name).ToListAsync();
        
        ViewBag.Categories = Enum.GetValues<POICategory>();
        ViewBag.SelectedCategory = category;
        ViewBag.SearchTerm = search;

        return View(pois);
    }

    // GET: POI/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var poi = await _context.PointsOfInterest
            .Include(p => p.Images)
            .Include(p => p.UserContributions.Where(uc => uc.Status == ContributionStatus.Approved))
            .ThenInclude(uc => uc.User)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (poi == null)
        {
            return NotFound();
        }

        return View(poi);
    }

    // GET: POI/Create
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        ViewBag.Categories = Enum.GetValues<POICategory>();
        return View();
    }

    // POST: POI/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([Bind("Name,NameBulgarian,Description,DescriptionBulgarian,Latitude,Longitude,Category,MainImageUrl,PanoramicImageUrl,VideoUrl,IsUNESCOSite,HasVirtualTour")] PointOfInterest pointOfInterest)
    {
        if (ModelState.IsValid)
        {
            pointOfInterest.CreatedAt = DateTime.UtcNow;
            pointOfInterest.UpdatedAt = DateTime.UtcNow;
            
            _context.Add(pointOfInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        ViewBag.Categories = Enum.GetValues<POICategory>();
        return View(pointOfInterest);
    }

    // GET: POI/Edit/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pointOfInterest = await _context.PointsOfInterest.FindAsync(id);
        if (pointOfInterest == null)
        {
            return NotFound();
        }
        
        ViewBag.Categories = Enum.GetValues<POICategory>();
        return View(pointOfInterest);
    }

    // POST: POI/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NameBulgarian,Description,DescriptionBulgarian,Latitude,Longitude,Category,MainImageUrl,PanoramicImageUrl,VideoUrl,IsUNESCOSite,HasVirtualTour,CreatedAt")] PointOfInterest pointOfInterest)
    {
        if (id != pointOfInterest.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                pointOfInterest.UpdatedAt = DateTime.UtcNow;
                _context.Update(pointOfInterest);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointOfInterestExists(pointOfInterest.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        
        ViewBag.Categories = Enum.GetValues<POICategory>();
        return View(pointOfInterest);
    }

    // GET: POI/Delete/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pointOfInterest = await _context.PointsOfInterest
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pointOfInterest == null)
        {
            return NotFound();
        }

        return View(pointOfInterest);
    }

    // POST: POI/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var pointOfInterest = await _context.PointsOfInterest.FindAsync(id);
        if (pointOfInterest != null)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // API endpoint for map markers
    [HttpGet]
    public async Task<IActionResult> GetMapData(POICategory? category = null)
    {
        var query = _context.PointsOfInterest.AsQueryable();

        if (category.HasValue)
        {
            query = query.Where(p => p.Category == category.Value);
        }

        var mapData = await query.Select(p => new
        {
            id = p.Id,
            name = p.Name,
            nameBulgarian = p.NameBulgarian,
            latitude = p.Latitude,
            longitude = p.Longitude,
            category = p.Category.ToString(),
            categoryId = (int)p.Category,
            mainImageUrl = p.MainImageUrl,
            isUNESCOSite = p.IsUNESCOSite,
            hasVirtualTour = p.HasVirtualTour
        }).ToListAsync();

        return Json(mapData);
    }

    private bool PointOfInterestExists(int id)
    {
        return _context.PointsOfInterest.Any(e => e.Id == id);
    }
} 