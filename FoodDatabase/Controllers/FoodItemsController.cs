using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodDatabase.Models;

namespace FoodDatabase.Controllers
{
    public class FoodItemsController : Controller
    {
        private readonly FoodDatabaseContext _context;

        public FoodItemsController(FoodDatabaseContext context)
        {
            _context = context;
        }

        // GET: FoodItems
        public async Task<IActionResult> Index(double FoodCalories, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<double> genreQuery = from m in _context.FoodItem
                                            orderby m.Calories
                                            select m.Calories;

            var FoodItems = from m in _context.FoodItem
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                FoodItems = FoodItems.Where(s => s.Title.Contains(searchString));
            }

            if (FoodCalories != 0)
            {
                FoodItems = FoodItems.Where(x => x.Calories == FoodCalories);
            }

            var FoodCaloriesVM = new FoodCaloriesViewModel
            { 
                Calories = new SelectList(await genreQuery.Distinct().ToListAsync()),
                FoodItems = await FoodItems.ToListAsync()
            };

            return View(FoodCaloriesVM);
        }

        // GET: FoodItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var FoodItem = await _context.FoodItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (FoodItem == null)
            {
                return NotFound();
            }

            return View(FoodItem);
        }

        // GET: FoodItems/Create
        public IActionResult Create()
        {
            return View(new FoodItem
            {
                Title = "Conan",
                ReleaseDate = DateTime.Now,
                Calories = 100,
                Protein = 200,
                Carbs = 50,
                Lipids = 20
            }
                );
        }

        // POST: FoodItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] FoodItem FoodItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(FoodItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(FoodItem);
        }

        // GET: FoodItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var FoodItem = await _context.FoodItem.FindAsync(id);
            if (FoodItem == null)
            {
                return NotFound();
            }
            return View(FoodItem);
        }

        // POST: FoodItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Calories,Protein,Carbs,Lipids")] FoodItem FoodItem)
        {
            if (id != FoodItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(FoodItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodItemExists(FoodItem.Id))
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
            return View(FoodItem);
        }

        // GET: FoodItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var FoodItem = await _context.FoodItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (FoodItem == null)
            {
                return NotFound();
            }

            return View(FoodItem);
        }

        // POST: FoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var FoodItem = await _context.FoodItem.FindAsync(id);
            _context.FoodItem.Remove(FoodItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItem.Any(e => e.Id == id);
        }
    }
}
