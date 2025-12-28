using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _156023_155875.ProgWiz.WEB.Models;

namespace _156023_155875.ProgWiz.WEB.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
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
}
