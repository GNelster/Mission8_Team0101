using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission8_Team0101.Models;

namespace Mission8_Team0101.Controllers;

public class HomeController : Controller
{
 
    
    public IActionResult Index()
    {
        return View();
    }
    
}
