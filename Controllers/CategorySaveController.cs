using FonAnalizi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FonAnalizi.Controllers{

    public class CategorySaveController:Controller{
        private readonly DataContext _context;

        public CategorySaveController(DataContext context){
            _context=context;
        }

         public async Task<IActionResult> index(){
            var CategorySave = await _context.CategoriesSaves.Include(x=>x.Fon).Include(x=>x.Category).ToListAsync();
            return View(CategorySave);
        }

        public async Task<IActionResult> Create(){
            ViewBag.Fons = new SelectList(await _context.Fons.ToListAsync(), "FonId","FonName");
            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "CategoryId","Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> create(CategorySave model){

            _context.CategoriesSaves.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }


    }
}