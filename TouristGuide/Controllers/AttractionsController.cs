using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class AttractionsController : Controller
{
    private readonly ApplicationDbContext _context;

    public AttractionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Details(int id)
    {
        var attraction = await _context.Attractions.Include(a => a.City).FirstOrDefaultAsync(a => a.Id == id);
        if (attraction == null) return NotFound();

        return View(attraction);
    }
}
