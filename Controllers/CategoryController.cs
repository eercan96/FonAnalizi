using FonAnalizi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FonAnalizi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        
        
        public async Task<IActionResult> Create(Category model)
        {
            _context.Categories.Add(model);
            await _context.SaveChangesAsync();
             return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ctgry = await _context.Categories.Include(c=>c.CategorySaves).ThenInclude(k=>k.Fon).FirstOrDefaultAsync(o=>o.CategoryId==id);
            if (ctgry == null)
            {
                return NotFound();
            }
            return View(ctgry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category model)
        {
            if (id != model.CategoryId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Categories.Any(o => o.CategoryId == model.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("index");
            }
            return View(model);
        }
   

    [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var ctgry = await _context.Categories.FindAsync(id);
            if(ctgry == null){
                return NotFound();
            }

            return View(ctgry);
        }
        [HttpPost]

        public async Task<IActionResult> Delete([FromForm]int id){
            var ctgry = await _context.Categories.FindAsync(id);

            if(ctgry ==null){
                return NotFound();
            }
            
            _context.Categories.Remove(ctgry);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

    }

}