using FonAnalizi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FonAnalizi.Controllers
{
    public class FonController : Controller
    {
        private readonly DataContext _context;
        public FonController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fons.ToListAsync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        
        
        public async Task<IActionResult> Create(Fon model)
        {
            _context.Fons.Add(model);
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
            var fn = await _context.Fons.Include(o=>o.CategorySaves).ThenInclude(o=>o.Category).FirstOrDefaultAsync(o=>o.FonId ==id);
            
            if (fn == null)
            {
                return NotFound();
            }
            return View(fn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fon model)
        {
            if (id != model.FonId)
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
                    if (!_context.Fons.Any(o => o.FonId == model.FonId))
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
            
            var fon = await _context.Fons.FindAsync(id);
            if(fon == null){
                return NotFound();
            }

            return View(fon);
        }
        [HttpPost]

        public async Task<IActionResult> Delete([FromForm]int id){
            var fon = await _context.Fons.FindAsync(id);

            if(fon ==null){
                return NotFound();
            }
            
            _context.Fons.Remove(fon);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

    }

}