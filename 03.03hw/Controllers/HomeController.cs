using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _03._03hw.Models;

namespace _03._03hw.Controllers;

public class HomeController : Controller
{
    private readonly movie_context _db;


    public HomeController(movie_context context)
    {
        _db = context;
    }

    public IActionResult Index()
    {
        var list = _db.movies.ToList();
        return View(list);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { request_id = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}