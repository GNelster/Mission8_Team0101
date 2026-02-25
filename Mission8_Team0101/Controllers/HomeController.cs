using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission8_Team0101.Models;

namespace Mission8_Team0101.Controllers;

public class HomeController : Controller
{
    private IHabitRepository _repo; // Abstracted the context file, best practice. Wrapped in a box, can't see it in the class. Industry Standard.

    // Passes the instance of the context file to the class so that it can be used within the class.
    public HomeController(IHabitRepository temp) 
    {
        _repo = temp;
    }
    
    // TODO: Waiting on Models / Database / Views to be configured.
    public IActionResult Index()
    {
        return View();
    }
    
}
