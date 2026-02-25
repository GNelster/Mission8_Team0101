using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_Team0101.Models;
using Task = Mission8_Team0101.Models.Task;

namespace Mission8_Team0101.Controllers;

public class HomeController : Controller
{
    private readonly TaskContext _context;

    public HomeController(TaskContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tasks = _context.Tasks
            .Include(t => t.Quadrant)
            .Include(t => t.Category)
            .Where(t => !t.Completed)
            .ToList();

        return View(tasks);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Quadrants = _context.Quadrants.ToList();
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Mission8_Team0101.Models.Task task)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Quadrants = _context.Quadrants.ToList();
        ViewBag.Categories = _context.Categories.ToList();
        return View(task);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null) return NotFound();

        ViewBag.Quadrants = _context.Quadrants.ToList();
        ViewBag.Categories = _context.Categories.ToList();
        return View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Mission8_Team0101.Models.Task task)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Quadrants = _context.Quadrants.ToList();
        ViewBag.Categories = _context.Categories.ToList();
        return View(task);
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks
            .Include(t => t.Quadrant)
            .Include(t => t.Category)
            .FirstOrDefault(t => t.Id == id);

        if (task == null) return NotFound();

        return View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult MarkComplete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task != null)
        {
            task.Completed = true;
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
