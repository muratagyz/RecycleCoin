using Microsoft.AspNetCore.Mvc;
using RecycleCoin.UI.Models;
using System.Diagnostics;

namespace RecycleCoin.UI.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}