using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class CitiesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string search)
    {
        var cities = from c in _context.Cities.Include(c => c.Attractions) select c;

        if (!string.IsNullOrEmpty(search))
        {
            cities = cities.Where(c => c.Name.Contains(search));
        }

        return View(await cities.ToListAsync());
    }

    public async Task<IActionResult> Details(int id)
    {
        var city = await _context.Cities.Include(c => c.Attractions).FirstOrDefaultAsync(m => m.Id == id);
        if (city == null) return NotFound();

        return View(city);
    }
}
