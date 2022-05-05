using System.Diagnostics;
using System.Linq;  
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc.Models;
using Dominio.Entity;
using Dados;

namespace Mvc.Controllers
{
  public class CategoryController : Controller
  { 
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Home()
    {
      IQueryable<Category> category = _context.category;
      return View(category);
    }

    [HttpGet]
    public IActionResult Save()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var category = await _context.category.FirstOrDefaultAsync(c => c.id == id);
      return View("Save", category); 
    }

    [HttpGet]
    public async Task<IActionResult> Remove(int id)
    {
      var category = await _context.category.FirstOrDefaultAsync(c => c.id == id);
                     _context.category.Remove(category);
                     await _context.SaveChangesAsync();
      return RedirectToAction("Home");   
    }

    [HttpPost]
    public async Task<IActionResult> Save(Category _category)
    {
      if(_category.id == 0){
       _context.category.Add(_category);
      }else{
       var category = await _context.category.FirstOrDefaultAsync(c => c.id == _category.id);
       category.name = _category.name;
      }
       await _context.SaveChangesAsync();
     return RedirectToAction("Home");
    }

  }
  
}
