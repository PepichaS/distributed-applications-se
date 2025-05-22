using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models;

namespace RentACar.Web.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Favorites
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var favorites = await _context.Favorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Vehicle)
                .ToListAsync();

            return View(favorites);
        }

        // POST: Add to Favorites
        [HttpPost]
        public async Task<IActionResult> AddToFavorites(string vehicleId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var existingFavorite = await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.VehicleId == vehicleId);

            if (existingFavorite == null)
            {
                var favorite = new Favorite
                {
                    UserId = userId,
                    VehicleId = vehicleId
                };

                _context.Favorites.Add(favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Vehicles");
        }

        // POST: Remove from Favorites
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null) return NotFound();

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Helper Method to Check if a Favorite Exists
        private bool FavoriteExists(int id)
        {
            return _context.Favorites.Any(f => f.Id == id);
        }
    }
}
