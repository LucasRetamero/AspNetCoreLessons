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
  public class ProductController : Controller
  { 
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Home()
    {
      IQueryable<Product> _product = _context.product.Include(p => p.category);
      IQueryable<Category> _category = _context.category;
       ViewBag.Category = _category;
      return View(_product);
    }

    [HttpGet]
    public IActionResult Save()
    {
       IQueryable<Category> _category = _context.category;
       ViewBag.Category = _category;
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var _product = await _context.product.FirstOrDefaultAsync(c => c.id == id);
      IQueryable<Category> _category = _context.category;
      ViewBag.Category = _category;

      return View("Save", _product); 
    }

    [HttpGet]
    public async Task<IActionResult> Remove(int id)
    {
      var _product = await _context.product.FirstOrDefaultAsync(c => c.id == id);
                     _context.product.Remove(_product);
                     await _context.SaveChangesAsync();
      return RedirectToAction("Home");   
    }

    [HttpPost]
    public async Task<IActionResult> Save(Product  _product)
    {
    
      if(_product.id == 0){
       _context.product.Add(_product);
      }else{
       var product = await _context.product.FirstOrDefaultAsync(c => c.id == _product.id);
       product.name = _product.name;
       product.categoryid = _product.categoryid;
      }
       await _context.SaveChangesAsync();
      
     return RedirectToAction("Home");
    }

  }
  
}
