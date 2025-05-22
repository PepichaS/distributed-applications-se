using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.Common;
using RentACar.Data;
using RentACar.Models;
using RentACar.ViewModels.Shared;
using RentACar.ViewModels.VehicleTypes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Web.Controllers
{
	public class VehicleTypesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public VehicleTypesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: VehicleTypes
		public async Task<IActionResult> Index(int page = 1, int itemsPerPage = 10)
		{
			var totalElements = await _context.VehicleTypes.CountAsync();
			var totalPages = (int)Math.Ceiling((double)totalElements / itemsPerPage);

			// Ensure the page number is within valid range
			if (page < 1)
			{
				page = 1;
			}
			else if (page > totalPages && totalPages > 0)
			{
				page = totalPages;
			}

			var vehicleTypes = await _context.VehicleTypes
				.Skip((page - 1) * itemsPerPage)
				.Take(itemsPerPage)
				.Select(vt => new IndexVehicleTypeVM
				{
					Id = vt.Id,
					Name = vt.Name,
					Description = vt.Description
				})
				.ToListAsync();

			var viewModel = new IndexVehicleTypesVM
			{
				Page = page,
				ItemsPerPage = itemsPerPage,
				ElementsCount = totalElements,
				VehicleTypes = vehicleTypes
			};

			return View(viewModel);
		}

		// GET: VehicleTypes/Details/5
		public async Task<IActionResult> Details(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var vehicleType = await _context.VehicleTypes
				.FirstOrDefaultAsync(m => m.Id == id);

			if (vehicleType == null)
			{
				return NotFound();
			}

			return View(vehicleType);
		}

		// GET: VehicleTypes/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: VehicleTypes/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = GlobalConstants.AdminRole)]
		public async Task<IActionResult> Create(CreateVehicleTypeVM model)
		{
			if (ModelState.IsValid)
			{
				// Map ViewModel to Entity
				var vehicleType = new VehicleType
				{
					Name = model.Name,
					Description = model.Description
				};

				// Save to database
				await _context.VehicleTypes.AddAsync(vehicleType);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		// GET: VehicleTypes/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var vehicleType = await _context.VehicleTypes.FindAsync(id);
			if (vehicleType == null)
			{
				return NotFound();
			}
			return View(vehicleType);
		}

		// POST: VehicleTypes/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description")] VehicleType vehicleType)
		{
			if (id != vehicleType.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(vehicleType);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!VehicleTypeExists(vehicleType.Id))
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
			return View(vehicleType);
		}

		// GET: VehicleTypes/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var vehicleType = await _context.VehicleTypes
				.FirstOrDefaultAsync(m => m.Id == id);
			if (vehicleType == null)
			{
				return NotFound();
			}

			return View(vehicleType);
		}

		// POST: VehicleTypes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			var vehicleType = await _context.VehicleTypes.FindAsync(id);
			_context.VehicleTypes.Remove(vehicleType);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool VehicleTypeExists(string id)
		{
			return _context.VehicleTypes.Any(e => e.Id == id);
		}
	}
}
