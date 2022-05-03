using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SecondLesson.Models;

namespace SecondLesson.Controllers;

[Route("product")]
public class ProductController : Controller
{
	
    public IActionResult Index()
    {
      return Content("hello world", "aplicattion/json");
    }
}
