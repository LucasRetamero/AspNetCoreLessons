using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Dominio.Entity;

namespace Mvc.Controllers
{
  public class CategoryController : Controller
  { 
    
    [HttpGet]
    public IActionResult Save()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Save(Category category)
    {
     return View();
    }

  }
  
}
